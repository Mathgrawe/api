using api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserModels> _userManager;
        private readonly SignInManager<UserModels> _signInManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ApplicationDbContext context, IConfiguration configuration, UserManager<UserModels> userManager, SignInManager<UserModels> signInManager, ILogger<AuthController> logger)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            _logger.LogInformation("Acessou a página de login.");
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválida no login.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                _logger.LogWarning("Email ou senha nulos no login.");
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _logger.LogWarning("Usuário não encontrado para o email: {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Senha incorreta para o usuário: {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model);
            }

            _logger.LogInformation("Login bem-sucedido para o usuário: {Email}", model.Email);
            return RedirectToAction("Index", "Tarefa");
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            _logger.LogInformation("Acessou a página de registro.");
            return View();
        }

        // Processa o registro
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState inválida no registro.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                _logger.LogWarning("Email ou senha nulos no registro.");
                ModelState.AddModelError(string.Empty, "Preencha todos os campos.");
                return View(model);
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Tentativa de registro com email já existente: {Email}", model.Email);
                ModelState.AddModelError(string.Empty, "Email já registrado.");
                return View(model);
            }

            var user = new UserModels
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Erro ao criar usuário para o email: {Email}", model.Email);
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Erro: {Error}", error.Description);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            _logger.LogInformation("Usuário registrado com sucesso para o email: {Email}", model.Email);

            await _signInManager.SignInAsync(user, isPersistent: false);
            _logger.LogInformation("Usuário autenticado automaticamente após registro: {Email}", model.Email);

            return RedirectToAction("Index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Authorization; 

namespace api.Controllers
{
    
    public class TarefaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tasks.ToList();
            return View(tarefas);
        }

        public IActionResult Create()
        {
            var tarefa = new TarefaModels(); 
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TarefaModels tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();
            return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TarefaModels tarefa)
        {
            if (id != tarefa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) return NotFound();
            return View(tarefa); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                _context.Tasks.Remove(tarefa);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index)); 
        }
    }
}

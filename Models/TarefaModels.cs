namespace api.Models
{
    public class TarefaModels
    {
        public int Id { get; set; }  // Chave primária
        public string? Title { get; set; }  // Pode ser nulo
        public string? Description { get; set; }  // Pode ser nulo
        public string? Status { get; set; }  // Pode ser nulo
    }
}

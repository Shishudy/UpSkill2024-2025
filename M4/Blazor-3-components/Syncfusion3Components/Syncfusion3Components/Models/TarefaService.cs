namespace Syncfusion3Components.Models
{
    public class TarefaService
    {
        private readonly HttpClient _http;

        public TarefaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            return await _http.GetFromJsonAsync<List<Tarefa>>("api/tarefas");
        }

        public async Task AdicionarTarefaAsync(Tarefa tarefa)
        {
            await _http.PostAsJsonAsync("api/tarefas", tarefa);
        }

        public async Task AtualizarTarefaAsync(Tarefa tarefa)
        {
            await _http.PutAsJsonAsync($"api/tarefas/{tarefa.Id}", tarefa);
        }
        
        public async Task RemoverTarefaAsync(Tarefa tarefa)
        {
            await _http.DeleteAsync($"api/tarefas/{tarefa.Id}");
        }
    }
}

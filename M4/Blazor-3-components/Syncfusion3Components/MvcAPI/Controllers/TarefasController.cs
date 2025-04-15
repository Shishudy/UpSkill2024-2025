using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcAPI.Models;
using static MvcAPI.Data.DatabaseContext;

namespace MvcAPI.Controllers
{
	[Route("api/tarefas")]
	[ApiController]
	public class TarefasController: ControllerBase
	{
		private readonly AppDbContext _context;

		public TarefasController(AppDbContext context)
		{
			_context = context;
		}

		// GET: api/tarefas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
		{
			return await _context.Tarefas.ToListAsync();
		}

		// GET: api/tarefas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Tarefa>> GetTarefa(int id)
		{
			var tarefa = await _context.Tarefas.FindAsync(id);

			if (tarefa == null)
			{
				return NotFound();
			}

			return tarefa;
		}

		// POST: api/tarefas
		[HttpPost]
		public async Task<ActionResult<Tarefa>> AdicionarTarefa(Tarefa tarefa)
		{
			_context.Tarefas.Add(tarefa);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
		}

		// PUT: api/tarefas/5
		[HttpPut("{id}")]
		public async Task<IActionResult> AtualizarTarefa(int id, Tarefa tarefaAtualizada)
		{
			if (id != tarefaAtualizada.Id)
			{
				return BadRequest();
			}

			_context.Entry(tarefaAtualizada).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TarefaExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE: api/tarefas/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoverTarefa(int id)
		{
			var tarefa = await _context.Tarefas.FindAsync(id);
			if (tarefa == null)
			{
				return NotFound();
			}

			_context.Tarefas.Remove(tarefa);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TarefaExists(int id)
		{
			return _context.Tarefas.Any(e => e.Id == id);
		}
	}
}

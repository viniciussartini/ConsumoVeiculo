using ConsumoVeiculo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumoVeiculo.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }
    }
}

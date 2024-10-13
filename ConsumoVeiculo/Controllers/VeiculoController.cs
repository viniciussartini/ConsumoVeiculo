using ConsumoVeiculo.Data;
using ConsumoVeiculo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ConsumoVeiculo.Controllers
{
    [Authorize]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Relatorio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var consumos = await _context.Consumos
                .Where(consumo => consumo.VeiculoId == id)
                .OrderByDescending(consumo => consumo.Data)
                .ToListAsync();

            decimal total = consumos.Sum(consumo => consumo.Valor);

            ViewBag.Veiculo = veiculo;
            ViewBag.Total = total;

            return View(consumos);
        }

       /*public JsonResult GetDados() 
        {
            var dados = _context.Veiculos.Select(veiculo => new {
                veiculo.Id,
                veiculo.Nome,
                veiculo.Placa,
                veiculo.AnoFabricacao,
                veiculo.AnoModelo
            }).ToList();
            return Json(dados);
        }*/
    }
}

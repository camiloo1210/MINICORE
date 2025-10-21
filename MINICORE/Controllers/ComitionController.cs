using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MINICORE.Data;
using MINICORE.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MINICORE.Controllers
{
    public class ComitionController : Controller
    {
        private readonly minicore _context;

        public ComitionController(minicore context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calcular(DateTime desde, DateTime hasta)
        {
            var ventas = await _context.Ventas
                .Include(v => v.Seller)
                .Where(v => v.SaleDate >= desde && v.SaleDate <= hasta)
                .ToListAsync();

            var reglas = await _context.Reglas.ToListAsync();

            var resultado = ventas
                .GroupBy(v => v.Seller)
                .Select(g =>
                {
                    var total = g.Sum(v => v.Amount);
                    var regla = reglas
                        .OrderByDescending(r => r.MinimumAmount)
                        .FirstOrDefault(r => total >= r.MinimumAmount);
                    var porcentaje = regla?.CommissionPercentage ?? 0;
                    return new
                    {
                        Nombre = g.Key.Name,
                        TotalVentas = total,
                        Porcentaje = porcentaje,
                        Comision = Math.Round(total * porcentaje / 100, 2)
                    };
                })
                .ToList();

            return View("Resultado", resultado);
        }
    }
}
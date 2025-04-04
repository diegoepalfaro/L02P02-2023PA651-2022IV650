using Microsoft.AspNetCore.Mvc;
using L02P02_2023PA651_2022IV650.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace L02P02_2023PA651_2022IV650.Controllers
{
    public class PedidoDetalleController : Controller
    {
        private readonly libreriaDbContext _context;

        public PedidoDetalleController(libreriaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pedidoId)
        {

            try
            {
                
                var pedidoExiste = await _context.pedido_encabezado
                    .AnyAsync(p => p.id == pedidoId.Value);

                if (!pedidoExiste)
                {
                    TempData["Error"] = "El pedido especificado no existe";
                    return RedirectToAction("Index", "Clientes");
                }

                ViewBag.PedidoId = pedidoId.Value;

                var libros = await _context.Libros
                    .Where(l => l.estado == "A") 
                    .ToListAsync();

                // Calcular total actual del pedido
                var totalPedido = await _context.pedido_encabezado
                    .Where(pd => pd.id == pedidoId.Value)
                    .SumAsync(pd => pd.total);

                ViewBag.TotalPedido = totalPedido;

                return View(libros);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar los libros: {ex.Message}";
                return RedirectToAction("Index", "Clientes");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int libroId, int pedidoId)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(libroId);
                if (libro == null)
                {
                    TempData["Error"] = "El libro seleccionado no existe";
                    return RedirectToAction("Index", new { pedidoId });
                }

                
                var existe = await _context.pedido_detalle
                    .AnyAsync(pd => pd.id_pedido == pedidoId && pd.id_libro == libroId);

                if (existe)
                {
                    TempData["Error"] = "Este libro ya está en tu carrito";
                    return RedirectToAction("Index", new { pedidoId });
                }

                
                var detalle = new pedido_detalle
                {
                    id_pedido = pedidoId,
                    id_libro = libroId,
                    
                    created_at = DateTime.Now
                };

                _context.pedido_detalle.Add(detalle);
                await _context.SaveChangesAsync();

                
                var encabezado = await _context.pedido_encabezado.FindAsync(pedidoId);
                if (encabezado != null)
                {
                    encabezado.cantidad_libros = await _context.pedido_detalle
                        .Where(pd => pd.id_pedido == pedidoId)
                        .CountAsync();

                    encabezado.total = await _context.pedido_encabezado
                        .Where(pe => pe.total == encabezado.total)
                        .CountAsync();
       

                    await _context.SaveChangesAsync();
                }

                TempData["Mensaje"] = "Libro agregado al carrito correctamente";
                return RedirectToAction("Index", new { pedidoId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al agregar libro al carrito: {ex.Message}";
                return RedirectToAction("Index", new { pedidoId });
            }
        }

        [HttpPost]
        public IActionResult CompletarPedido(int pedidoId)
        {
            return RedirectToAction("Index", "CierreVenta", new { pedidoId });
        }
    }
}
using L02P02_2023PA651_2022IV650.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace L02P02_2023PA651_2022IV650.Controllers
{
    
    public class ClientesController : Controller
    {
        private readonly libreriaDbContext _libreriaDbContext;

        public ClientesController(libreriaDbContext libreriaDbContext)
        {
            _libreriaDbContext = libreriaDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCliente(string Nombre, string Apellido, string Email, string Direccion)
        {
            var nuevoCliente = new Clientes
            {
                
                nombre = Nombre,
                apellido = Apellido,
                email = Email,
                direccion = Direccion,
                created_at = DateTime.UtcNow
            };

            _libreriaDbContext.Clientes.Add(nuevoCliente);
            _libreriaDbContext.SaveChanges();

            
            int ultimoId = _libreriaDbContext.pedido_encabezado
                 .OrderByDescending(p => p.id)
                 .Select(p => p.id)
                 .FirstOrDefault();

            int nuevoId = ultimoId + 1;

            int clienteId = nuevoCliente.id;

            var nuevoPedido = new pedido_encabezado
            {
                id = nuevoId,
                id_cliente = nuevoCliente.id,
                cantidad_libros = 0,
                total = 0.00m,
                estado = "P"
            };

            _libreriaDbContext.pedido_encabezado.Add(nuevoPedido);
            _libreriaDbContext.SaveChanges();

            // Redirigir CON el ID del pedido recién creado
            return RedirectToAction("Index", "PedidoDetalle", new { pedidoId = nuevoPedido.id });
        }
    }
    
}

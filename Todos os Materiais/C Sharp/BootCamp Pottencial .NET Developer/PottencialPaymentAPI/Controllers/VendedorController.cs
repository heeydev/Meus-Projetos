using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PottencialPaymentAPI.Context;
using PottencialPaymentAPI.Models;

namespace PottencialPaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public VendedorController(OrganizadorContext context)
        {
            _context = context;
        }

        
        

        [HttpPost]
        public IActionResult CadastrarVendedor(Vendedor cadastro)
        {
            cadastro.Id = ControladorIDSingleton.Instancia.IdVendedor;  

            _context.Add(cadastro);
            _context.SaveChanges();

            return Ok(cadastro);
        }        
    }
}
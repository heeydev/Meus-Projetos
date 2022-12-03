using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PottencialPaymentAPI.Context;
using PottencialPaymentAPI.Models;

namespace PottencialPaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public RegistroController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorIdPedido(int id)
        {
            var registro = _context.Registros.Find(id);

            if (registro == null)
            {
                return NotFound();
            }
            
            return Ok(registro);
        }           

        [HttpPost]
        public IActionResult Criar(Registro registro)
        {
            if (registro.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data do registro não pode ser vazia" });

            if (registro.Quantidade <= 0)
                registro.Quantidade = 1;

            if (registro.Status != 0)
                registro.Status = 0;

            var cadastro = _context.Cadastros.Find(registro.IdVendedor);

            if (cadastro == null)
            {
                return NotFound();
            }

            registro.Id = ControladorIDSingleton.Instancia.IdPedido;

            _context.Add(registro);
            _context.SaveChanges();

            return Ok(registro);
        }

        ///<summary>         
        ///MUDANÇA DE STATUS => Status 0, opções: 1 ou 4 || Status 1, opções: para 2 ou 4 || Status 2, opções: para 3 ou 4 || Status 3, opções: para 4             
        ///</summary>

        [HttpPatch("AlterarStatus")]
        public IActionResult AtualizarParcial(Registro registro)
        {
            var registroBanco = _context.Registros.Find(registro.Id);

            if (registroBanco == null)
                return NotFound();

            if (registro.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data do registro não pode ser vazia" });

            if (registroBanco.Status == (EnumStatusRegistro.AguardandoPagamento))
            {
                bool sucesso = (registro.Status == EnumStatusRegistro.Cancelada) || (registro.Status == EnumStatusRegistro.PagamentoAprovado);

                if (sucesso)
                {
                    registroBanco.Status = registro.Status;
                }
            }
            else if (registroBanco.Status == (EnumStatusRegistro.PagamentoAprovado))
            {
                bool sucesso = (registro.Status == EnumStatusRegistro.Cancelada) || (registro.Status == EnumStatusRegistro.EnviadoParaTransportadora);

                if (sucesso)
                {
                    registroBanco.Status = registro.Status;
                }
            }
            else if (registroBanco.Status == (EnumStatusRegistro.EnviadoParaTransportadora))
            {
                bool sucesso = registro.Status == (EnumStatusRegistro.Entregue);

                if (sucesso)
                {
                    registroBanco.Status = registro.Status;
                }
            }

            _context.Registros.Update(registroBanco);
            _context.SaveChanges();

            return Ok(registroBanco);
        }
    }
}

using ClinicCorporateApp.Core.Domain;
using ClinicCorporateApp.Core.Shared.ModelViews;
using ClinicCorporateApp.Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicCorporateApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;
        private readonly ILogger<ClientesController> logger;

        public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
        {
            this.clienteManager = clienteManager;
            this.logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados na base.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var clientes = await clienteManager.GetClientesAsync();
            if (clientes.Any())
            {
                return Ok(clientes);
            }
            return NotFound();
        }

        /// <summary>
        /// Retorna um cliente consultado pelo id.
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await clienteManager.GetClienteAsync(id);
            if (cliente.Id == 0)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="novoCliente"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            logger.LogInformation("Objeto recebido: {@novoCliente}", novoCliente);

            ClienteView clienteInserido;
            using (Operation.Time("Tempo de adição de um novo cliente."))
            {
                logger.LogInformation("Foi requisitado a inserção de um novo cliente.");
                clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            }
            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
        }

        /// <summary>
        /// Altera um cliente.
        /// </summary>
        /// <param name="alteraCliente"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Put(AlteraCliente alteraCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alteraCliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Exclui um cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExcliudo = await clienteManager.DeleteClienteAsync(id);
            if (clienteExcliudo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

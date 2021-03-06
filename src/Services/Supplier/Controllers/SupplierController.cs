using MediatR;
using Microsoft.AspNetCore.Mvc;
using Supplier.Application.Commands;
using Supplier.Application.Queries;
using Supplier.ViewModels;

namespace Supplier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IMediator _mediator;
        private readonly ISupplierQueries _supplierQueries;

        public SupplierController(
            ILogger<SupplierController> logger,
            IMediator mediator,
            ISupplierQueries supplierQueries)
        {
            _logger = logger;
            _mediator = mediator;
            _supplierQueries = supplierQueries;
        }

        /// <summary>
        /// Create a new supplier.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Get all suppliers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _supplierQueries.GetAllSupplier();
            return Ok(users);
        }

        /// <summary>
        /// Get supplier by Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var supplier = await _supplierQueries.GetSupplier(id);
            return Ok(supplier);
        }

        /// <summary>
        /// Update supplier data.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SupplierUpdateViewModel viewModel)
        {
            return Ok();
        }

        /// <summary>
        /// Delete supplier.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
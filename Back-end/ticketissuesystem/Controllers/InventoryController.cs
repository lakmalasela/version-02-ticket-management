using Microsoft.AspNetCore.Mvc;
using ticketissuesystem.Services.Employeeservice;
using ticketissuesystem.Services.Inventory;

namespace ticketissuesystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {

        public readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetInventoryDto>>>> GetAll()
        {
            return Ok(await _inventoryService.GetAllInventory());

        }
    }
}

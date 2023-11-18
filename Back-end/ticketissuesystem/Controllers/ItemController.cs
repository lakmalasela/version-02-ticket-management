using Microsoft.AspNetCore.Mvc;
using ticketissuesystem.Services.Employeeservice;
using ticketissuesystem.Services.Itemsservice;

namespace ticketissuesystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {


        public readonly IItemService _itemsService;
        public ItemController(IItemService itemservice) {

            _itemsService = itemservice;
        }




        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems()
        {
            return Ok(await _itemsService.GetAllItems());

        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> AddtItems(AddItemDto addItems)
        {
            return Ok(await _itemsService.AddItem(addItems));
        }



        [HttpGet("Getitem/{id}")]
        public async Task<ActionResult<ServiceResponse<GetEmployeeDto>>> GetItem(int id)
        {
            return Ok(await _itemsService.GetItemById(id));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> UpdateItems(int id, UpdateItemDto updateItems)
        {
            var response = await _itemsService.UpdateItem(id, updateItems);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetItemDto>>> DeleteItems(int id)
        {
            var response = await _itemsService.DeleteItem(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpGet("Itemtype")]
        public async Task<ActionResult<ServiceResponse<String>>> GetItemtype()
        {
            var response = await _itemsService.GetItemype();
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }





     
    }
}

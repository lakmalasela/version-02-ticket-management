namespace ticketissuesystem.Services.Itemsservice
{
    public interface IItemService
    {


        Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
        Task<ServiceResponse<GetItemDto>> GetItemById(int id);

        Task<ServiceResponse<GetItemDto>> UpdateItem(int id, UpdateItemDto updateItem);

        Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItems);

        Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);

        Task<ServiceResponse<List<String>>> GetItemype();
    }
}

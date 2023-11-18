namespace ticketissuesystem.Services.Inventory
{
    public interface IInventoryService
    {

        Task<ServiceResponse<List<GetInventoryDto>>> GetAllInventory();
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ticketissuesystem.Data;
using ticketissuesystem.Models;

namespace ticketissuesystem.Services.Itemsservice
{
    public class ItemService : IItemService
    {


        public readonly IMapper _mapper;

        public readonly DataContext _context;
        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItems)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();

            var items = _mapper.Map<Items>(newItems);

           
            _context.Itemms.Add(items);

          

            var newInventory = new Models.Inventory
            {
                Items = items,
               


            };
            _context.Inventory.Add(newInventory);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Itemms.Select(c => _mapper.Map<GetItemDto>(c)).ToListAsync();

          
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                var items = await _context.Itemms.FirstOrDefaultAsync(c => c.Id == id);
                if (items is null)
                    throw new Exception($"Character with Id '{id}'Not found");

                _context.Itemms.Remove(items);

                await _context.SaveChangesAsync();


                //employees.Remove(employee);
                serviceResponse.Data = await _context.Itemms.Select(c => _mapper.Map<GetItemDto>(c)).ToListAsync();


            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
        {

            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var dbItems = await _context.Itemms.ToListAsync();
            serviceResponse.Data = dbItems.Select(c => _mapper.Map<GetItemDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> GetItemById(int id)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            var dbItems = await _context.Itemms.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetItemDto>(dbItems);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> UpdateItem(int id, UpdateItemDto updateItem)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();

            try
            {
                var items =

                  await _context.Itemms.FirstOrDefaultAsync(c => c.Id == id);
                if (items is null)
                {
                    throw new Exception($"Employee with Id '{updateItem.Id}'Not found");
                }


                items.Itemtype = updateItem.Itemtype;
                items.Itemname = updateItem.Itemname;
                items.Inventories = items.Inventories;
                items.Serialno = updateItem.Serialno;
                items.Branch = updateItem.Branch;
               


                //              employee.Civilstatus = _mapper.Map<Civ>(updateEmplyee.Civilstatus);



                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetItemDto>(items);

            }
            catch (Exception ex)
            {
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<string>>> GetEmployeebranch()
        {
            var serviceResponse = new ServiceResponse<List<String>>();

            try
            {
                var enumType = typeof(Branch);
                if (enumType.IsEnum)
                {
                    var enumValues = Enum.GetNames(enumType).ToList();
                    serviceResponse.Data = enumValues;
                    serviceResponse.Sucess = true;
                }
                else
                {
                    serviceResponse.Message = "The provided type is not an enum.";
                    serviceResponse.Sucess = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error: {ex.Message}";
                serviceResponse.Sucess = false;
            }


            return await Task.FromResult(serviceResponse);
        }

        public async Task<ServiceResponse<List<string>>> GetItemype()
        {
            var serviceResponse = new ServiceResponse<List<String>>();

            try
            {
                var enumType = typeof(Itemtype);
                if (enumType.IsEnum)
                {
                    var enumValues = Enum.GetNames(enumType).ToList();
                    serviceResponse.Data = enumValues;
                    serviceResponse.Sucess = true;
                }
                else
                {
                    serviceResponse.Message = "The provided type is not an enum.";
                    serviceResponse.Sucess = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = $"Error: {ex.Message}";
                serviceResponse.Sucess = false;
            }


            return await Task.FromResult(serviceResponse);
        }



    }
}

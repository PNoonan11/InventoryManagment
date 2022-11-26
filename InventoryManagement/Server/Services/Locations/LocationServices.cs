using InventoryManagement.Server.Data;
using InventoryManagement.Server.Models;
using InventoryManagement.Shared.Models.Locations;
using InventoryManagement.Shared.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Server.Services.Locations
{
    public class LocationServices : ILocationServices
            {
        private readonly ApplicationDbContext _context;
        public LocationServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLocationAsync(LocationCreate model)
        {
            if (model == null) return false;
            var locationEntity = new LocationEntity
            {
                Location = model.Location
            };
        _context.Locations.Add(locationEntity);
            return await _context.SaveChangesAsync() == 1;
        }

      

        public async Task<IEnumerable<LocationListItem>> GetAllLocationsAsync()
        {
            var locationQuery = _context.Locations.Select(entity => new LocationListItem
            {
                Id = entity.Id,
                Location = entity.Location
            });
            return await locationQuery.ToListAsync();
        }

        public async Task<LocationDetail> GetLocationByIdAsync(int locationId)
        {
            var locationEntity = await _context.Locations.Include(l => l.ListOfLocations).FirstOrDefaultAsync(r => r.Id == locationId);
            if (locationEntity is null)
                return null;
            var detail = new LocationDetail
            {
                Id = locationEntity.Id,
                Location = locationEntity.Location,
                CountOfProducts = locationEntity.ListOfLocations.Count                
            };
            return detail;
        }

        public async Task<bool> UpdateLocationAsync(LocationEdit model)
        {
            if (model == null)
                return false;
            var entity = await _context.Locations.FindAsync(model.Id);
            entity.Location = model.Location;
            
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteLocationAsync(int locationId)
        {
            var entity = await _context.Locations.FindAsync(locationId);
            _context.Locations.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

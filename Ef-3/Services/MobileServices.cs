using Ef_3.Model;
using Ef_3.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ef_3.Services
{
    public class MobileServices
    {
        private readonly MobileDB _mobile;
        public MobileServices(MobileDB mobile)
        {
            _mobile = mobile;
        }

        public async Task<List<Mobiles>> GetMobilesAsync()
        {
            return await _mobile.MobilesTable.ToListAsync();
        }

        public async Task<string> createMobile(Mobiles entity)
        {
            try
            {
                _mobile.MobilesTable.Add(entity);
                await _mobile.SaveChangesAsync();
                return "Mobile created successfully";
            }
            catch (Exception ex)
            {
                return $"Error creating mobile: {ex.Message}";
            }
        }

        public async Task<string> DeleteMobile(int id)
        {
            try
            {
                var entity = await _mobile.MobilesTable.FirstOrDefaultAsync(x => x.id == id);
                if (entity == null)
                {
                    return "Mobile not found";
                }
                _mobile.MobilesTable.Remove(entity);
                await _mobile.SaveChangesAsync();
                return "Mobile deleted successfully";
            }
            catch (Exception ex)
            {
                return $"Error occured while deleting mobile: {ex.Message}";
            }
        }

        public async Task<string> UpdateMobile (int Id, Mobiles entity)
        {
            try
            {
                var existingMobile = await _mobile.MobilesTable.FindAsync(Id);
                if (existingMobile == null)
                {
                    return "Mobile not found";
                }
                existingMobile.Name = entity.Name;
                existingMobile.Model = entity.Model;
                existingMobile.Price = entity.Price;
                existingMobile.Color = entity.Color;

                _mobile.MobilesTable.Update(existingMobile);
                await _mobile.SaveChangesAsync();
                return "Mobile updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error occured while updating mobile: {ex.Message}";
            }
        }


    }
}

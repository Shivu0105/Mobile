using Ef_3.Repository;
using Microsoft.AspNetCore.Mvc;
using Ef_3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Ef_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly MobileDB _mobile;
        public MobileController(MobileDB mobile)
        {
            _mobile = mobile;
        }



        [HttpGet]
        public async Task<IActionResult> getMobiles()
        {
            try
            {
                var mobileData = await _mobile.MobilesTable.ToListAsync();
                return Ok(mobileData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createMobile([FromBody] Mobiles entity)
        {
            try
            {
                _mobile.MobilesTable.Add(entity);
                await _mobile.SaveChangesAsync();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteMobile(int id)
        {
            try
            {
                var entity = await _mobile.MobilesTable.FindAsync(id);
                if (entity == null)
                {
                    return NotFound("Mobile not found");
                }
                _mobile.MobilesTable.Remove(entity);
                await _mobile.SaveChangesAsync();
                return Ok("Mobile deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateMobile(int id, [FromBody] Mobiles entity)
        {
            try
            {
                var existingMobile = await _mobile.MobilesTable.FindAsync(id);
                if (existingMobile == null)
                {
                    return NotFound("Mobile not found");
                }
                existingMobile.Name = entity.Name;
                existingMobile.Model = entity.Model;
                existingMobile.Price = entity.Price;
                existingMobile.Color = entity.Color;

                _mobile.MobilesTable.Update(existingMobile);
                await _mobile.SaveChangesAsync();
                return Ok("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

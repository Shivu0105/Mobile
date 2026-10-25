using Ef_3.Model;
using Ef_3.Repository;
using Ef_3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ef_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly MobileServices _mobileServices;
        public MobileController(MobileServices mobile)
        {
            _mobileServices = mobile;
        }

        [HttpGet]
        public async Task<IActionResult> getMobiles()
        {
            try
            {
                var mobileData = await _mobileServices.GetMobilesAsync();
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
                var result = await _mobileServices.createMobile(entity);
                return Ok(result);
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
                var result = await _mobileServices.DeleteMobile(id);
                return Ok(result);
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
                var result = await _mobileServices.UpdateMobile(id, entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

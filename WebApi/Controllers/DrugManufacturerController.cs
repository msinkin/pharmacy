using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.DrugManufacturer;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("manufacturers")]
    public class DrugManufacturerController : ControllerBase
    {
        private readonly DataContext _context;

        public DrugManufacturerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrugManufacturerEntity>>> GetDrugManufacturers()
        {
            return await _context.DrugManufacturerEntities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrugManufacturerEntity>> GetDrugManufacturer(Guid id)
        {
            var drugManufacturerEntity = await _context.DrugManufacturerEntities.FindAsync(id);

            if (drugManufacturerEntity == null)
            {
                return NotFound();
            }

            return drugManufacturerEntity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrugManufacturer(Guid id, DrugManufacturerUpdateRequest drugManufacturerUpdateRequest)
        {
            var drugManufacturer = await _context.DrugManufacturerEntities.FindAsync(id);

            if (drugManufacturer == null)
            {
                return NotFound();
            }

            drugManufacturer.Name = drugManufacturerUpdateRequest.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<DrugManufacturerEntity>> CreateDrugManufacturer(DrugManufacturerCreateRequest drugManufacturerCreateDto)
        {
            var newDrugManufacturer = new DrugManufacturerEntity
            {
                Name = drugManufacturerCreateDto.Name
            };

            _context.DrugManufacturerEntities.Add(newDrugManufacturer);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrugManufacturer(Guid id)
        {
            var drugManufacturerEntity = await _context.DrugManufacturerEntities.FindAsync(id);

            if (drugManufacturerEntity == null)
            {
                return NotFound();
            }

            _context.DrugManufacturerEntities.Remove(drugManufacturerEntity);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

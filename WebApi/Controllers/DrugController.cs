using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApi.Data;
using WebApi.Dto.Drug;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("drugs")]
    public class DrugController : ControllerBase
    {
        private readonly IDrugService _drugService;
        private readonly IMapper _mapper;

        public DrugController(IDrugService drugService, IMapper mapper)
        {
            _drugService = drugService;
            _mapper = mapper;
        }

        /// <summary>
        /// Возвращает список препаратов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<DrugResponse>>> GetAllDrugs()
        {
            var drugs = await _drugService.GetDrugsAsync();

            var drugsResponse = _mapper.Map<List<DrugResponse>>(drugs);

            return drugsResponse;
        }

        /// <summary>
        /// Создаёт препарат
        /// </summary>
        /// <param name="drugCreateRequest">Dto создания препарата</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DrugEntity>> CreateDrug([FromBody] DrugCreateRequest drugCreateRequest)
        {
            var newDrug = _mapper.Map<DrugEntity>(drugCreateRequest);
            var created = await _drugService.CreateDrugAsync(newDrug);
            var drugsResponse = _mapper.Map<DrugResponse>(created);

            return Ok(drugsResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DrugResponse>> UpdateDrag(Guid id, DrugUpdateRequest drugUpdateRequest)
        {
            var entity = _mapper.Map<DrugEntity>(drugUpdateRequest);
            entity.Id = id;
            var updated = await _drugService.UpdateDrugAsync(entity);
            var drugsResponse = _mapper.Map<DrugResponse>(updated);

            return Ok(drugsResponse);
        }

        /// <summary>
        /// Удаляет препарат по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrug(Guid id)
        {
            await _drugService.RemoveDrugByIdAsync(id);

            return Ok();
        }
    }
}

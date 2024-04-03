using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Entities;
using MoneyTrackerAPI.Models.CategoryType;
using MoneyTrackerAPI.Services.CategoryTypeServices;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryTypeController : ControllerBase
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;
        private readonly IMapper _mapper;

        public CategoryTypeController(ICategoryTypeRepository categoryTypeRepository,
            IMapper mapper)
        {
            _categoryTypeRepository = categoryTypeRepository ??
                throw new ArgumentNullException(nameof(categoryTypeRepository));

            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTypeDto>>> GetCategoryTypes()
        {
            var categoryTypes = await _categoryTypeRepository.GetCategoryTypesAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryTypeDto>>(categoryTypes));
        }

        [HttpGet("{categoryTypeId}", Name = "GetCategoryType")]
        public async Task<IActionResult> GetCategoryType(int categoryTypeId)
        {
            var categoryType = await _categoryTypeRepository
                .GetCategoryTypeAsync(categoryTypeId);

            if (categoryType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryTypeDto>(categoryType));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryTypeDto>> CreateCategoryType(
            CategoryTypeForCreationDto categoryType)
        {
            var finalCategoryType = _mapper.Map<CategoryType>(categoryType);

            _categoryTypeRepository.AddCategoryType(finalCategoryType);

            await _categoryTypeRepository.SaveChangesAsync();

            var createdCategoryToReturn =
                _mapper.Map<CategoryTypeDto>(finalCategoryType);

            return CreatedAtRoute("GetCategoryType",
                new
                {
                    categoryTypeId = createdCategoryToReturn.Id
                },
                createdCategoryToReturn);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategoryTypeInfo(
            int categoryTypeId,
            CategoryTypeForUpdateDto categoryType)
        {
            var categoryTypeEntity = await _categoryTypeRepository
                .GetCategoryTypeAsync(categoryTypeId);

            if (categoryTypeEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryType, categoryTypeEntity);

            await _categoryTypeRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{categoryTypeId}")]
        public async Task<ActionResult> PartiallyUpdateCategoryTypeInfo(
            int categoryTypeId,
            JsonPatchDocument<CategoryTypeForUpdateDto> patchDocument)
        {
            var categoryTypeEntity = await _categoryTypeRepository
                .GetCategoryTypeAsync(categoryTypeId);

            if (categoryTypeEntity == null)
            {
                return NotFound();
            }

            var categoryTypeToPatch = _mapper.Map<CategoryTypeForUpdateDto>(
                categoryTypeEntity);

            patchDocument.ApplyTo(categoryTypeToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(categoryTypeToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(categoryTypeToPatch, categoryTypeEntity);

            await _categoryTypeRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategoryType(
            int categoryTypeId)
        {
            var categoryEntity = await _categoryTypeRepository
                .GetCategoryTypeAsync(categoryTypeId);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _categoryTypeRepository.DeleteCategoryType(categoryEntity);

            await _categoryTypeRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Entities;
using MoneyTrackerAPI.Models.Category;
using MoneyTrackerAPI.Services.CategoryServices;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{categoryid}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var category = await _categoryRepository
                .GetCategoryAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(
            CategoryForCreationDto category)
        {
            var finalCategory = _mapper.Map<Category>(category);

            _categoryRepository.AddCategory(finalCategory);

            await _categoryRepository.SaveChangesAsync();

            var createdCategoryToReturn =
                _mapper.Map<CategoryDto>(finalCategory);

            return CreatedAtRoute("GetCategory",
                new
                {
                    categoryId = createdCategoryToReturn.Id
                },
                createdCategoryToReturn);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult> UpdateCategoryInfo(
            int categoryId,
            CategoryForUpdateDto category)
        {
            var categoryEntity = await _categoryRepository
                .GetCategoryAsync(categoryId);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(category, categoryEntity);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{categoryid}")]
        public async Task<ActionResult> PartiallyUpdateCategoryInfo(
            int categoryId,
            JsonPatchDocument<CategoryForUpdateDto> patchDocument)
        {
            var categoryEntity = await _categoryRepository
                .GetCategoryAsync(categoryId);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            var categoryToPatch = _mapper.Map<CategoryForUpdateDto>(
                categoryEntity);

            patchDocument.ApplyTo(categoryToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(categoryToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(categoryToPatch, categoryEntity);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{categoryid}")]
        public async Task<ActionResult> DeleteCategory(
            int categoryId)
        {
            var categoryEntity = await _categoryRepository
                .GetCategoryAsync(categoryId);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _categoryRepository.DeleteCategory(categoryEntity);

            await _categoryRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

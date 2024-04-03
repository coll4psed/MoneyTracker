using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoneyTrackerAPI.Entities;
using MoneyTrackerAPI.Models.Operation;
using MoneyTrackerAPI.Services.OperationServices;

namespace MoneyTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public OperationController(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository ??
                throw new ArgumentNullException(nameof(operationRepository));

            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDto>>> GetOperations()
        {
            var operations = await _operationRepository.GetOperationsAsync();

            return Ok(_mapper.Map<IEnumerable<OperationDto>>(operations));
        }

        [HttpGet("{operationId}", Name = "GetOperation")]
        public async Task<ActionResult<OperationDto>> GetOperation(
            int operationId)
        {
            var operation = await _operationRepository
                .GetOperationAsync(operationId);

            if (operation == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OperationDto>(operation));
        }

        [HttpPost]
        public async Task<ActionResult<OperationDto>> CreateOperation(
            OperationForCreationDto operation)
        {
            var finalOperation = _mapper
                .Map<Operation>(operation);

            _operationRepository
                .AddOperation(finalOperation);

            await _operationRepository
                .SaveChangesAsync();

            var createdOperationToReturn =
                _mapper.Map<OperationDto>(finalOperation);

            return CreatedAtRoute("GetOperation",
                new
                {
                    operationid = createdOperationToReturn.Id
                },
                createdOperationToReturn);
        }

        [HttpPatch("{operationid}")]
        public async Task<ActionResult> PartiallyUpdateOperationInfo(
            int operationId,
            JsonPatchDocument<OperationForUpdateDto> patchDocument)
        {
            var operationEntity = await _operationRepository
                .GetOperationAsync(operationId);

            if (operationEntity == null)
            {
                return NotFound();
            }

            var operationToPatch = _mapper
                .Map<OperationForUpdateDto>(operationEntity);

            patchDocument.ApplyTo(operationToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(operationToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(operationToPatch, operationEntity);

            await _operationRepository
                .SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{operationid}")]
        public async Task<ActionResult> DeleteAccount(
            int operationId)
        {
            var operationEntity = await _operationRepository
                .GetOperationAsync(operationId);

            if (operationEntity == null)
            {
                return NotFound();
            }

            _operationRepository
                .DeleteOperation(operationEntity);

            await _operationRepository
                .SaveChangesAsync();

            return NoContent();
        }
    }
}

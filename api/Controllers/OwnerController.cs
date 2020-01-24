using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController: ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public OwnerController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repositoryWrapper.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database.");
                
                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                
                return Ok(ownersResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repositoryWrapper.Owner.GetOwnerById(id);
 
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                
                _logger.LogInfo($"Returned owner with id: {id}");
 
                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById     action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return Ok();
        }
        
    }
}
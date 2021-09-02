using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/vehiclemodels")]
    public class VehicleModelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModels()
        {
            return Ok(await _unitOfWork.VehicleModelRepository.GetModelsAsync());
        }

        [HttpPost()]
        public async Task<ActionResult> AddVehicleModel(AddVehicleModelDto model)
        {
            try
            {
                var vehicleModel = await _unitOfWork.VehicleModelRepository.GetModelByNameAsync(model.Description);
                if (vehicleModel != null) return BadRequest("Model is already in system");

                var newModel = new VehicleModel
                {
                    Description = model.Description
                };

                _unitOfWork.VehicleModelRepository.Add(newModel);

                if (await _unitOfWork.Complete()) return StatusCode(201, newModel);

                return StatusCode(500, "Not able to save model");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVehicleModel(int id, AddVehicleModelDto model)
        {
            try
            {
                var vehicleModel = await _unitOfWork.VehicleModelRepository.GetModelByIdAsync(id);
                if (vehicleModel == null) return NotFound($"No model found with id {id}");

                //var modelName = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Name.ToLower() == model.Name.ToLower());
                //if (modelName == null) return BadRequest("Model is already in the system");

                vehicleModel.Description = model.Description;
                _unitOfWork.VehicleModelRepository.Update(vehicleModel);

                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "Not able to update model");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
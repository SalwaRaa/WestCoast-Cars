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
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return Ok(await _unitOfWork.VehicleRepository.GetVehiclesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleViewModel>> GetVehicle(int id)
        {
            var result = await _unitOfWork.VehicleRepository.GetVehicleByIdAsync(id);
            if (result == null) return NotFound($"No vehicle found with id {id}");

            return Ok(result);
        }

        [HttpGet("find/{regNum}")]
        public async Task<ActionResult<Vehicle>> FindVehicle(string regNum)
        {
            var result = await _unitOfWork.VehicleRepository.GetVehicleByRegNumAsync(regNum);
            if (result == null) return NotFound($"No vehicle found with registration number {regNum}");

            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult> AddVehicle(AddVehicleDto model)
        {
            try
            {
                var brand = await _unitOfWork.BrandRepository.GetBrandByNameAsync(model.Brand);
                if (brand == null) return BadRequest($"Brand {model.Brand} does not excist in system");

                var vehicleModel = await _unitOfWork.VehicleModelRepository.GetModelByNameAsync(model.Model);
                if (vehicleModel == null) return BadRequest($"Model {model.Model} does not excist in system");

                //kolla att regnummer ej finns så bilar ej blir duplicerade
                                
                _unitOfWork.VehicleRepository.Add(model);

                if (await _unitOfWork.Complete()) return StatusCode(201);

                return StatusCode(500, "Not able to save vehicle");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, UpdateVehicleDto model)
        {
            try
            {
                var vehicle = await _unitOfWork.VehicleRepository.GetVehicleByIdAsync(id);
                if (vehicle == null) return NotFound($"No vehicle found with id {id}");

                vehicle.Color = model.Color;
                vehicle.Mileage = model.Mileage;

                _unitOfWork.VehicleRepository.Update(vehicle);
                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "Not able to update vehicle");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            try
            {
                var vehicle = await _unitOfWork.VehicleRepository.GetVehicleForDeleteByIdAsync(id);
                if (vehicle == null) return NotFound($"No vehicle found with id {id}");

                _unitOfWork.VehicleRepository.Delete(vehicle);
                
                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "Not able to delete vehicle");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
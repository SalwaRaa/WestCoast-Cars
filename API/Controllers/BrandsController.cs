using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BrandsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            //flytta mapper till repot
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return Ok(await _unitOfWork.BrandRepository.GetBrandsAsync());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Brand>> GetBrandByName(string name)
        {
            var result = await _unitOfWork.BrandRepository.GetBrandByNameAsync(name);
            if (result == null) return NotFound($"Brand {name} does not excist in system");

            var brand = _mapper.Map<BrandViewModel>(result);

            return Ok(brand);
        }

        [HttpPost()]
        public async Task<ActionResult> AddBrand(AddBrandDto model)
        {
            try
            {
                var brandResult = await _unitOfWork.BrandRepository.GetBrandByNameAsync(model.Name);
                if (brandResult != null) return BadRequest("Brand is already in the system");

                var brand = new Brand
                {
                    Name = model.Name
                };

                _unitOfWork.BrandRepository.Add(brand);

                if (await _unitOfWork.Complete()) return StatusCode(201, brand);

                return StatusCode(500, "Not able to save brand");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBrand(int id, AddBrandDto model)
        {
            try
            {
                var brand = await _unitOfWork.BrandRepository.GetBrandByIdAsync(id);
                if (brand == null) return NotFound($"No brand found with id {id}");

                //var nameResult = await _context.Brands.FirstOrDefaultAsync(c => c.Name.ToLower() == model.Name.ToLower());
                //if (nameResult == null) return BadRequest("Brand is already in the system");

                brand.Name = model.Name;
                _unitOfWork.BrandRepository.Update(brand);

                if (await _unitOfWork.Complete()) return NoContent();

                return StatusCode(500, "Not able to update brand");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
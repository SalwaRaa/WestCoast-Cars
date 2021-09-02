using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Sorry, no user found with id {id}");
            }

            return user;
        }

        /*
        [HttpGet("find/{email}")]
        public async Task<ActionResult<AppUser>> FindUser(string email) 
        {
            var user = await _context.Users.FindAsync(email);

            if (user == null)
            {
                return NotFound($"Sorry, no user found with email {email}");
            }

            return user;
        }
        */

        [HttpPost()]
        public async Task<ActionResult> AddUser(RegisterUserDto model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                Phone = model.Phone
            };

            _context.Users.Add(user);

            var result = await _context.SaveChangesAsync();

            return StatusCode(201, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Sorry, no user found with id {id}");
            }

            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, UpdateUserDto model)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Sorry, no user found with id {id}");
            }

            user.City = model.City;
            user.Email = model.Email;
            user.Phone = model.Phone;            

            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
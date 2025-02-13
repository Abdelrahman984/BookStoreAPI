using BookStoreAPI.DTOs.CustomerDTO;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public CustomerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpPost]
        public IActionResult AddCustomer(AddCustomerDTO customerDTO)
        {
            var cust = new Customer()
            {
                UserName = customerDTO.UserName,
                FullName = customerDTO.FullName,
                Email = customerDTO.Email,
                PhoneNumber = customerDTO.PhoneNumber,
                Address = customerDTO.Address
            };
            var result = userManager.CreateAsync(cust, customerDTO.Password).Result;

            if (result.Succeeded)
            {
                IdentityRole _role = roleManager.FindByNameAsync("Customer").Result;
                if (_role != null)
                {
                    IdentityResult roleResult = userManager.AddToRoleAsync(cust, _role.Name).Result;
                    if (roleResult.Succeeded)
                        return Ok();
                    else
                        return BadRequest(roleResult.Errors);
                }
                else
                {
                    return BadRequest("Role not found");
                }
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpGet]
        public IActionResult SelecAll()
        {
            var customers = userManager.Users.ToList();
            return Ok(customers);
        }
    }
}

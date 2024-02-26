using AutoMapper;
using LibraryProject.Core.DTO;
using LibraryProject.Core.Interface;
using LibraryProject.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;

[Route("v1/api/user")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserRepository _context;
    private readonly IMapper _mapper;

    public UserController(IUserRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> Post(User user)
    {
        var userWasCreated = await _context.Create(user);

        if (userWasCreated)
        {
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
        return NotFound("Error when creating user, check data in payload");
    }


    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        var userRemoved = await _context.Delete(id);

        if (userRemoved)
            Ok("User removed");
        return NotFound("Id invalid or user with book borrowed");
    }

    [HttpPut("{id}")] 
    public async Task<ActionResult> Update([FromBody] User user, int id)
    {
        var userUpdate = await _context.Update(user, id);
        
        if(userUpdate)
            return Ok("User was updated");
        return NotFound("Check the user information send");
    }
}

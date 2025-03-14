using System;
using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();
        return Ok(users);
    }

    [HttpGet("{username}")]  // api/user/1
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberDto(username);

        if(user==null) return NotFound();//

        return user;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto membersUpdatedtos)
    {
        var userame = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if(userame == null) return BadRequest("No username found in token");

        var user = await userRepository.GetUserByUsernameAsync(userame);

        if(user==null) return BadRequest("Could not foind");
         mapper.Map(membersUpdatedtos,user);

        if(await userRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update the user");



    }
}

using System;

namespace API.DTOs;

public class UserDto
{
    public required string Username { get; set; }
    public required string KnownAs { get; set; }
     public required string Token { get; set; }
     public string? PhotUrl{set;get;}

}

﻿using CSharpShared.Exception;
using gateway.DTO;
using gateway.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic _userLogicLogic;
    private readonly DtoMapper _dtoMapper;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;
    private readonly ExceptionHandler _exceptionHandler;

    public UserController(IUserLogic userLogicLogic, DtoMapper dtoMapper)
    {
        _userLogicLogic = userLogicLogic;
        _dtoMapper = dtoMapper;
    }

    [HttpPut]
    [Route("update_user")]
    public async Task<ActionResult<UpdateUserDto>> UpdateUserAsync([FromBody] UpdateUserDto dto)
    {
        try
        {
            await _userLogicLogic.UpdateUserAsync(dto);
            _logger.Log($"PackageController: UpdatePackageLocationAsync of {dto} successful");
            return Ok();
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
    // This method is not used in the current version of the project
    /*
    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDto>> GetByIdAsync([FromRoute] long id)
    {
        try
        {
            var user = await userLogicLogic.GetUserByIdAsync(id);
            GetUserDto dto = _dtoMapper.GetUserDto(user);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }*/
}
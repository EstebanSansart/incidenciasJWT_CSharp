using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class UserController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return Ok(users);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return Ok(user);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(User userPO){
        this._unitOfWork.Users.Add(userPO);
        await _unitOfWork.SaveAsync();
        if (userPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = userPO.Id}, userPO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Post(UserDto userDto){
        var user = _mapper.Map<User>(userDto);
        this._unitOfWork.Users.Add(user);
        await _unitOfWork.SaveAsync();
        if (user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = user.Id}, userDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> Put(int id, [FromBody]User userPU){
        if(userPU == null)
        {
            return NotFound();
        }
        _unitOfWork.Users.Update(userPU);
        await _unitOfWork.SaveAsync();
        return userPU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserDto>> Put(int id, [FromBody]UserDto userDto){
        if(userDto == null)
        {
            return NotFound();
        }
        var users = _mapper.Map<User>(userDto);
        _unitOfWork.Users.Update(users);
        await _unitOfWork.SaveAsync();
        return userDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var userD = await _unitOfWork.Users.GetByIdAsync(id);
        if(userD == null)
        {
            return NotFound();
        }
        _unitOfWork.Users.Remove(userD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
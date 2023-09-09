using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class RoleController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Role>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return Ok(roles);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        return Ok(role);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Post(Role rolePO){
        this._unitOfWork.Roles.Add(rolePO);
        await _unitOfWork.SaveAsync();
        if (rolePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = rolePO.Id}, rolePO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Post(RoleDto roleDto){
        var role = _mapper.Map<Role>(roleDto);
        this._unitOfWork.Roles.Add(role);
        await _unitOfWork.SaveAsync();
        if (role == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = role.Id}, roleDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Put(int id, [FromBody]Role rolePU){
        if(rolePU == null)
        {
            return NotFound();
        }
        _unitOfWork.Roles.Update(rolePU);
        await _unitOfWork.SaveAsync();
        return rolePU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Put(int id, [FromBody]RoleDto roleDto){
        if(roleDto == null)
        {
            return NotFound();
        }
        var roles = _mapper.Map<Role>(roleDto);
        _unitOfWork.Roles.Update(roles);
        await _unitOfWork.SaveAsync();
        return roleDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var roleD = await _unitOfWork.Roles.GetByIdAsync(id);
        if(roleD == null)
        {
            return NotFound();
        }
        _unitOfWork.Roles.Remove(roleD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class RoleController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Role>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return Ok(roles);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var role = await _unitOfWork.Roles.GetByIdAsync(id);
        return Ok(role);
    }

    [HttpPost]
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
    }

    [HttpPut("{id}")]
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
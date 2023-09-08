using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class IncidenceTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceType>>> Get()
    {
        var incidence_types = await _unitOfWork.IncidenceTypes.GetAllAsync();
        return Ok(incidence_types);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var incidence_type = await _unitOfWork.IncidenceTypes.GetByIdAsync(id);
        return Ok(incidence_type);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceType>> Post(IncidenceType incidence_typePO){
        this._unitOfWork.IncidenceTypes.Add(incidence_typePO);
        await _unitOfWork.SaveAsync();
        if (incidence_typePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = incidence_typePO.Id}, incidence_typePO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceType>> Put(int id, [FromBody]IncidenceType incidence_typePU){
        if(incidence_typePU == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceTypes.Update(incidence_typePU);
        await _unitOfWork.SaveAsync();
        return incidence_typePU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence_typeD = await _unitOfWork.IncidenceTypes.GetByIdAsync(id);
        if(incidence_typeD == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceTypes.Remove(incidence_typeD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class IncidenceLevelController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceLevelController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceLevel>>> Get()
    {
        var incidence_levels = await _unitOfWork.IncidenceLevels.GetAllAsync();
        return Ok(incidence_levels);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var incidence_level = await _unitOfWork.IncidenceLevels.GetByIdAsync(id);
        return Ok(incidence_level);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceLevel>> Post(IncidenceLevel incidence_levelPO){
        this._unitOfWork.IncidenceLevels.Add(incidence_levelPO);
        await _unitOfWork.SaveAsync();
        if (incidence_levelPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = incidence_levelPO.Id}, incidence_levelPO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceLevel>> Put(int id, [FromBody]IncidenceLevel incidence_levelPU){
        if(incidence_levelPU == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceLevels.Update(incidence_levelPU);
        await _unitOfWork.SaveAsync();
        return incidence_levelPU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence_levelD = await _unitOfWork.IncidenceLevels.GetByIdAsync(id);
        if(incidence_levelD == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceLevels.Remove(incidence_levelD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
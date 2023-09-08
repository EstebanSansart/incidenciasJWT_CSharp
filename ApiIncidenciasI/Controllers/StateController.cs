using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class StateController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public StateController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<State>>> Get()
    {
        var states = await _unitOfWork.States.GetAllAsync();
        return Ok(states);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var state = await _unitOfWork.States.GetByIdAsync(id);
        return Ok(state);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Post(State statePO){
        this._unitOfWork.States.Add(statePO);
        await _unitOfWork.SaveAsync();
        if (statePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = statePO.Id}, statePO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Put(int id, [FromBody]State statePU){
        if(statePU == null)
        {
            return NotFound();
        }
        _unitOfWork.States.Update(statePU);
        await _unitOfWork.SaveAsync();
        return statePU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var stateD = await _unitOfWork.States.GetByIdAsync(id);
        if(stateD == null)
        {
            return NotFound();
        }
        _unitOfWork.States.Remove(stateD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
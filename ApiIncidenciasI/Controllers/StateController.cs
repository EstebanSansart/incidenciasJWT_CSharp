using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class StateController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public StateController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<State>>> Get()
    {
        var states = await _unitOfWork.States.GetAllAsync();
        return Ok(states);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StateDto>>> Get()
    {
        var states = await _unitOfWork.States.GetAllAsync();
        return _mapper.Map<List<StateDto>>(states);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var state = await _unitOfWork.States.GetByIdAsync(id);
        return Ok(state);
    }

    /*[HttpPost]
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
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Post(StateDto stateDto){
        var state = _mapper.Map<State>(stateDto);
        this._unitOfWork.States.Add(state);
        await _unitOfWork.SaveAsync();
        if (state == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = state.Id}, stateDto);
    }

    /*[HttpPut("{id}")]
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
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StateDto>> Put(int id, [FromBody]StateDto stateDto){
        if(stateDto == null)
        {
            return NotFound();
        }
        var states = _mapper.Map<State>(stateDto);
        _unitOfWork.States.Update(states);
        await _unitOfWork.SaveAsync();
        return stateDto;
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
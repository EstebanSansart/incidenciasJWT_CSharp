using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class IncidenceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IncidenceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    // [GET]
    /* [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Incidence>>> Get()
    {
        var incidences = await _unitOfWork.Incidences.GetAllAsync();
        return Ok(incidences);
    } */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceDto>>> Get()
    {
        var incidences = await _unitOfWork.Incidences.GetAllAsync();
        return _mapper.Map<List<IncidenceDto>>(incidences);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetId(int id)
    {
        var incidences = await _unitOfWork.Incidences.GetByIdAsync(id);
        return Ok(incidences);
    }
    // [POST]
    /* [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Post(Incidence incidence){
        this._unitOfWork.Incidences.Add(incidence);
        await _unitOfWork.SaveAsync();
        if (incidence == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = incidence.Id}, incidence); 
    } */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Post(IncidenceDto incidenceDto){
        var incidence = _mapper.Map<Incidence>(incidenceDto);
        this._unitOfWork.Incidences.Add(incidence);
        await _unitOfWork.SaveAsync();
        if (incidence == null)
        {
            return BadRequest();
        }
        incidenceDto.IncidenceId = incidence.Id;
        return CreatedAtAction(nameof(Post), new {id = incidenceDto.IncidenceId}, incidenceDto); 
    }
    // [PUT]
    /* [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Incidence>> Put(int id, [FromBody]Incidence incidence){
        if(incidence == null)
            return NotFound();
        _unitOfWork.Incidences.Update(incidence);
        await _unitOfWork.SaveAsync();
        return incidence;
    } */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDto>> Put(int id, [FromBody]IncidenceDto incidenceDto){
        if(incidenceDto == null)
            return NotFound();
        var incidences = _mapper.Map<Incidence>(incidenceDto);
        _unitOfWork.Incidences.Update(incidences);
        await _unitOfWork.SaveAsync();
        return incidenceDto;
    }
    // [DELETE]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence = await _unitOfWork.Incidences.GetByIdAsync(id);
        if(incidence == null){
            return NotFound();
        }
        _unitOfWork.Incidences.Remove(incidence);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
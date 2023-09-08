using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class IncidenceDetailController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public IncidenceDetailController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceDetail>>> Get()
    {
        var incidence_details = await _unitOfWork.IncidenceDetails.GetAllAsync();
        return Ok(incidence_details);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceDetailDto>>> Get()
    {
        var incidenceDetails = await _unitOfWork.IncidenceDetails.GetAllAsync();
        return _mapper.Map<List<IncidenceDetailDto>>(incidenceDetails);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var incidence_detail = await _unitOfWork.IncidenceDetails.GetByIdAsync(id);
        return Ok(incidence_detail);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDetail>> Post(IncidenceDetail incidence_detailPO){
        this._unitOfWork.IncidenceDetails.Add(incidence_detailPO);
        await _unitOfWork.SaveAsync();
        if (incidence_detailPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = incidence_detailPO.Id}, incidence_detailPO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDetail>> Post(IncidenceDetailDto incidenceDetailDto){
        var incidenceDetail = _mapper.Map<IncidenceDetail>(incidenceDetailDto);
        this._unitOfWork.IncidenceDetails.Add(incidenceDetail);
        await _unitOfWork.SaveAsync();
        if (incidenceDetail == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = incidenceDetail.Id}, incidenceDetailDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDetail>> Put(int id, [FromBody]IncidenceDetail incidence_detailPU){
        if(incidence_detailPU == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceDetails.Update(incidence_detailPU);
        await _unitOfWork.SaveAsync();
        return incidence_detailPU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidenceDetailDto>> Put(int id, [FromBody]IncidenceDetailDto incidenceDetailDto){
        if(incidenceDetailDto == null)
        {
            return NotFound();
        }
        var incidenceDetails = _mapper.Map<IncidenceDetail>(incidenceDetailDto);
        _unitOfWork.IncidenceDetails.Update(incidenceDetails);
        await _unitOfWork.SaveAsync();
        return incidenceDetailDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var incidence_detailD = await _unitOfWork.IncidenceDetails.GetByIdAsync(id);
        if(incidence_detailD == null)
        {
            return NotFound();
        }
        _unitOfWork.IncidenceDetails.Remove(incidence_detailD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
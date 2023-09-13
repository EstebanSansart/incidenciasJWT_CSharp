using ApiIncidenciasI.Dtos;
using ApiIncidenciasI.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class AreaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Area>>> Get()
    {
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return Ok(areas);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<AreaDto>> Get()
    {
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return _mapper.Map<List<AreaDto>>(areas);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AreaDto>>> Get11([FromQuery] Params _params)
    {
        var areas = await _unitOfWork.Areas.GetAllAsync();
        var areasDto = _mapper.Map<List<AreaDto>>(areas);
        var pager = new Pager<AreaDto>(areasDto, areasDto.Count(),_params.PageIndex, _params.PageSize, _params.Search);
        return CreatedAtAction(nameof(Get), pager);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(Area areaPO){
        this._unitOfWork.Areas.Add(areaPO);
        await _unitOfWork.SaveAsync();
        if (areaPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = areaPO.Id}, areaPO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Post(AreaDto areaDto){
        var area = _mapper.Map<Area>(areaDto);
        this._unitOfWork.Areas.Add(area);
        await _unitOfWork.SaveAsync();
        if (area == null)
        {
            return BadRequest();
        }        
        return CreatedAtAction(nameof(Post),new {id = area.Id}, areaDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Area>> Put(int id, [FromBody]Area areaPU){
        if(areaPU == null)
        {
            return NotFound();
        }
        _unitOfWork.Areas.Update(areaPU);
        await _unitOfWork.SaveAsync();
        return areaPU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> Put(int id, [FromBody]AreaDto areaDto){
        if(areaDto == null)
        {
            return NotFound();
        }
        var areas = _mapper.Map<Area>(areaDto);
        _unitOfWork.Areas.Update(areas);
        await _unitOfWork.SaveAsync();
        return areaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var areaD = await _unitOfWork.Areas.GetByIdAsync(id);
        if(areaD == null)
        {
            return NotFound();
        }
        _unitOfWork.Areas.Remove(areaD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
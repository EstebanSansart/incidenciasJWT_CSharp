using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PlaceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PlaceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Place>>> Get()
    {
        var places = await _unitOfWork.Places.GetAllAsync();
        return Ok(places);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PlaceDto>>> Get()
    {
        var places = await _unitOfWork.Places.GetAllAsync();
        return _mapper.Map<List<PlaceDto>>(places);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var place = await _unitOfWork.Places.GetByIdAsync(id);
        return Ok(place);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Post(Place placePO){
        this._unitOfWork.Places.Add(placePO);
        await _unitOfWork.SaveAsync();
        if (placePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = placePO.Id}, placePO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Post(PlaceDto placeDto){
        var place = _mapper.Map<Place>(placeDto);
        this._unitOfWork.Places.Add(place);
        await _unitOfWork.SaveAsync();
        if (place == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = place.Id}, placeDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Place>> Put(int id, [FromBody]Place placePU){
        if(placePU == null)
        {
            return NotFound();
        }
        _unitOfWork.Places.Update(placePU);
        await _unitOfWork.SaveAsync();
        return placePU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlaceDto>> Put(int id, [FromBody]PlaceDto placeDto){
        if(placeDto == null)
        {
            return NotFound();
        }
        var places = _mapper.Map<Place>(placeDto);
        _unitOfWork.Places.Update(places);
        await _unitOfWork.SaveAsync();
        return placeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var placeD = await _unitOfWork.Places.GetByIdAsync(id);
        if(placeD == null)
        {
            return NotFound();
        }
        _unitOfWork.Places.Remove(placeD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
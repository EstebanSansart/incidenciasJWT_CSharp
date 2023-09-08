using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class PlaceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Place>>> Get()
    {
        var places = await _unitOfWork.Places.GetAllAsync();
        return Ok(places);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var place = await _unitOfWork.Places.GetByIdAsync(id);
        return Ok(place);
    }

    [HttpPost]
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
    }

    [HttpPut("{id}")]
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
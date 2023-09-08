using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class IncidenceDetailController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public IncidenceDetailController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<IncidenceDetail>>> Get()
    {
        var incidence_details = await _unitOfWork.IncidenceDetails.GetAllAsync();
        return Ok(incidence_details);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var incidence_detail = await _unitOfWork.IncidenceDetails.GetByIdAsync(id);
        return Ok(incidence_detail);
    }

    [HttpPost]
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
    }

    [HttpPut("{id}")]
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
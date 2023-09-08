using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class DocTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public DocTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocType>>> Get()
    {
        var doctypes = await _unitOfWork.DocTypes.GetAllAsync();
        return Ok(doctypes);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var doctype = await _unitOfWork.DocTypes.GetByIdAsync(id);
        return Ok(doctype);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocType>> Post(DocType doctypePO){
        this._unitOfWork.DocTypes.Add(doctypePO);
        await _unitOfWork.SaveAsync();
        if (doctypePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = doctypePO.Id}, doctypePO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocType>> Put(int id, [FromBody]DocType doctypePU){
        if(doctypePU == null)
        {
            return NotFound();
        }
        _unitOfWork.DocTypes.Update(doctypePU);
        await _unitOfWork.SaveAsync();
        return doctypePU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var doctypeD = await _unitOfWork.DocTypes.GetByIdAsync(id);
        if(doctypeD == null)
        {
            return NotFound();
        }
        _unitOfWork.DocTypes.Remove(doctypeD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
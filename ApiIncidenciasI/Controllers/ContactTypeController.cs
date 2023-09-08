using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class CategoryTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryTypeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactType>>> Get()
    {
        var contact_types = await _unitOfWork.ContactTypes.GetAllAsync();
        return Ok(contact_types);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact_type = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        return Ok(contact_type);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Post(ContactType contact_typePO){
        this._unitOfWork.ContactTypes.Add(contact_typePO);
        await _unitOfWork.SaveAsync();
        if (contact_typePO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contact_typePO.Id}, contact_typePO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Put(int id, [FromBody]ContactType contact_typePU){
        if(contact_typePU == null)
        {
            return NotFound();
        }
        _unitOfWork.ContactTypes.Update(contact_typePU);
        await _unitOfWork.SaveAsync();
        return contact_typePU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contact_typeD = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if(contact_typeD == null)
        {
            return NotFound();
        }
        _unitOfWork.ContactTypes.Remove(contact_typeD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
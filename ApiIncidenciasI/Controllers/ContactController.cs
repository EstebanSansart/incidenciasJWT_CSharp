using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class CategoryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return Ok(contacts);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        return Ok(contact);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(Contact contactPO){
        this._unitOfWork.Contacts.Add(contactPO);
        await _unitOfWork.SaveAsync();
        if (contactPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contactPO.Id}, contactPO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Put(int id, [FromBody]Contact contactPU){
        if(contactPU == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacts.Update(contactPU);
        await _unitOfWork.SaveAsync();
        return contactPU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contactD = await _unitOfWork.Contacts.GetByIdAsync(id);
        if(contactD == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacts.Remove(contactD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
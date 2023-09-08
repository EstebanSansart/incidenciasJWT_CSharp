using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
public class ContactCategoryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactCategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactCategory>>> Get()
    {
        var contact_categories = await _unitOfWork.ContactCategories.GetAllAsync();
        return Ok(contact_categories);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact_category = await _unitOfWork.ContactCategories.GetByIdAsync(id);
        return Ok(contact_category);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategory>> Post(ContactCategory contact_categoryPO){
        this._unitOfWork.ContactCategories.Add(contact_categoryPO);
        await _unitOfWork.SaveAsync();
        if (contact_categoryPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contact_categoryPO.Id}, contact_categoryPO);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategory>> Put(int id, [FromBody]ContactCategory contact_categoryPU){
        if(contact_categoryPU == null)
        {
            return NotFound();
        }
        _unitOfWork.ContactCategories.Update(contact_categoryPU);
        await _unitOfWork.SaveAsync();
        return contact_categoryPU;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var contact_categoryD = await _unitOfWork.ContactCategories.GetByIdAsync(id);
        if(contact_categoryD == null)
        {
            return NotFound();
        }
        _unitOfWork.ContactCategories.Remove(contact_categoryD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
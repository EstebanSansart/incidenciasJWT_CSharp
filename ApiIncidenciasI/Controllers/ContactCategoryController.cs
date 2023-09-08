using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ContactCategoryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactCategory>>> Get()
    {
        var contact_categories = await _unitOfWork.ContactCategories.GetAllAsync();
        return Ok(contact_categories);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactCategoryDto>>> Get()
    {
        var contact_categories = await _unitOfWork.ContactCategories.GetAllAsync();
        return _mapper.Map<List<ContactCategoryDto>>(contact_categories);
    }
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact_category = await _unitOfWork.ContactCategories.GetByIdAsync(id);
        return Ok(contact_category);
    }

    /*[HttpPost]
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
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategory>> Post(ContactCategoryDto contact_categoryDto){
        var contactCategory = _mapper.Map<ContactCategory>(contact_categoryDto);
        this._unitOfWork.ContactCategories.Add(contactCategory);
        await _unitOfWork.SaveAsync();
        if (contactCategory == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contactCategory.Id}, contactCategory);
    }

    /*[HttpPut("{id}")]
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
    }*/

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactCategoryDto>> Put(int id, [FromBody]ContactCategoryDto contactCategoryDto){
        if(contactCategoryDto == null)
        {
            return NotFound();
        }
        var contact_categories = _mapper.Map<ContactCategory>(contactCategoryDto);
        _unitOfWork.ContactCategories.Update(contact_categories);
        await _unitOfWork.SaveAsync();
        return contactCategoryDto;
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
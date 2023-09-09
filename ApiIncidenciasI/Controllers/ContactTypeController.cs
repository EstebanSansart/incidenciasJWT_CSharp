using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class ContactTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactType>>> Get()
    {
        var contact_types = await _unitOfWork.ContactTypes.GetAllAsync();
        return Ok(contact_types);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get()
    {
        var contact_types = await _unitOfWork.ContactTypes.GetAllAsync();
        return _mapper.Map<List<ContactTypeDto>>(contact_types);
    }
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact_type = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        return Ok(contact_type);
    }

    /*[HttpPost]
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
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Post(ContactTypeDto contactTypeDto){
        var contactType = _mapper.Map<ContactType>(contactTypeDto);
        this._unitOfWork.ContactTypes.Add(contactType);
        await _unitOfWork.SaveAsync();
        if (contactType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contactType.Id}, contactTypeDto);
    }

    /*[HttpPut("{id}")]
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
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactTypeDto>> Put(int id, [FromBody]ContactTypeDto contactTypeDto){
        if(contactTypeDto == null)
        {
            return NotFound();
        }
        var contactTypes = _mapper.Map<ContactType>(contactTypeDto);
        _unitOfWork.ContactTypes.Update(contactTypes);
        await _unitOfWork.SaveAsync();
        return contactTypeDto;
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
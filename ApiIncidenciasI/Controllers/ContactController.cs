using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class CategoryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return Ok(contacts);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactDto>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return _mapper.Map<List<ContactDto>>(contacts);
    }
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        return Ok(contact);
    }

    /*[HttpPost]
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
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(ContactDto contactDto){
        var contact = _mapper.Map<Contact>(contactDto);
        this._unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveAsync();
        if (contact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = contact.Id}, contactDto);
    }

    /*[HttpPut("{id}")]
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
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactDto>> Put(int id, [FromBody]ContactDto contactDto){
        if(contactDto == null)
        {
            return NotFound();
        }
        var contacts = _mapper.Map<Contact>(contactDto);
        _unitOfWork.Contacts.Update(contacts);
        await _unitOfWork.SaveAsync();
        return contactDto;
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
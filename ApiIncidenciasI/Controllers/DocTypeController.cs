using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class DocTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DocTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocType>>> Get()
    {
        var doctypes = await _unitOfWork.DocTypes.GetAllAsync();
        return Ok(doctypes);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocTypeDto>>> Get()
    {
        var doctypes = await _unitOfWork.DocTypes.GetAllAsync();
        return _mapper.Map<List<DocTypeDto>>(doctypes);
    }
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var doctype = await _unitOfWork.DocTypes.GetByIdAsync(id);
        return Ok(doctype);
    }

    /*[HttpPost]
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
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocType>> Post(DocTypeDto docTypeDto){
        var docType = _mapper.Map<DocType>(docTypeDto);
        this._unitOfWork.DocTypes.Add(docType);
        await _unitOfWork.SaveAsync();
        if (docType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = docType.Id}, docTypeDto);
    }

    /*[HttpPut("{id}")]
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
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocTypeDto>> Put(int id, [FromBody]DocTypeDto docTypeDto){
        if(docTypeDto == null)
        {
            return NotFound();
        }
        var docTypes = _mapper.Map<DocType>(docTypeDto);
        _unitOfWork.DocTypes.Update(docTypes);
        await _unitOfWork.SaveAsync();
        return docTypeDto;
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
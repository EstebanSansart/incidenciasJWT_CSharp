/*using System.Data.SqlTypes;
using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers;
[ApiVersion("1.0")]
public class AAAController : BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IMapper _Mapper;

    public AAAController (IUnitOfWork unitOfWork,IMapper mapper){
        _UnitOfWork = unitOfWork;
        _Mapper = mapper;
    }

    [HttpGet]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IEnumerable<SqlAlreadyFilledException>> Get(){
       var records = await _UnitOfWork.Areas.Find();
       return _Mapper.Map<List<SqlAlreadyFilledException>>(records);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SqlAlreadyFilledException>> Get(int id){
       var record = await _UnitOfWork.Areas.FindByIntId(id);
       if (record == null){
           return NotFound();
       }
       return _Mapper.Map<SqlAlreadyFilledException>(record);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<SqlAlreadyFilledException>>> Get11([FromQuery] PageParam param){
       IPager<Area> pager = await _UnitOfWork.Rols.Find(param);
       pager.Records = (IEnumerable<Area>)_Mapper.Map<List<SqlAlreadyFilledException>>(pager.Records);        
       return CreatedAtAction("Area",pager);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SqlAlreadyFilledException>> Post(SqlAlreadyFilledException recordDto){
       var record = _Mapper.Map<Area>(recordDto);
       _UnitOfWork.Areas.Add(record);
       await _UnitOfWork.SaveChanges();
       if (record == null){
           return BadRequest();
       }
       return CreatedAtAction(nameof(Post),new {id= record.Id, recordDto});
    }

    [HttpPut]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SqlAlreadyFilledException>> Put([FromBody]SqlAlreadyFilledException? recordDto){
       if(recordDto == null)
           return NotFound();
       var record = _Mapper.Map<Area>(recordDto);
       _UnitOfWork.Areas.Update(record);
       await _UnitOfWork.SaveChanges();
       return recordDto;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var record = await _UnitOfWork.Areas.FindByIntId(id);
       if(record == null){
           return NotFound();
       }
       _UnitOfWork.Areas.Remove(record);
       await _UnitOfWork.SaveChanges();
       return NoContent();
    }
}*/
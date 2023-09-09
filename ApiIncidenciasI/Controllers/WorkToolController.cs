using ApiIncidenciasI.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class WorkToolController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public WorkToolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<WorkTool>>> Get()
    {
        var work_tools = await _unitOfWork.WorkTools.GetAllAsync();
        return Ok(work_tools);
    }*/
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<WorkToolDto>>> Get()
    {
        var workTools = await _unitOfWork.WorkTools.GetAllAsync();
        return _mapper.Map<List<WorkToolDto>>(workTools);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var work_tool = await _unitOfWork.WorkTools.GetByIdAsync(id);
        return Ok(work_tool);
    }

    /*[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkTool>> Post(WorkTool work_toolPO){
        this._unitOfWork.WorkTools.Add(work_toolPO);
        await _unitOfWork.SaveAsync();
        if (work_toolPO == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = work_toolPO.Id}, work_toolPO);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkTool>> Post(WorkToolDto workToolDto){
        var workTool = _mapper.Map<WorkTool>(workToolDto);
        this._unitOfWork.WorkTools.Add(workTool);
        await _unitOfWork.SaveAsync();
        if (workTool == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = workTool.Id}, workToolDto);
    }

    /*[HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkTool>> Put(int id, [FromBody]WorkTool work_toolPU){
        if(work_toolPU == null)
        {
            return NotFound();
        }
        _unitOfWork.WorkTools.Update(work_toolPU);
        await _unitOfWork.SaveAsync();
        return work_toolPU;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkToolDto>> Put(int id, [FromBody]WorkToolDto workToolDto){
        if(workToolDto == null)
        {
            return NotFound();
        }
        var workTools = _mapper.Map<WorkTool>(workToolDto);
        _unitOfWork.WorkTools.Update(workTools);
        await _unitOfWork.SaveAsync();
        return workToolDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var work_toolD = await _unitOfWork.WorkTools.GetByIdAsync(id);
        if(work_toolD == null)
        {
            return NotFound();
        }
        _unitOfWork.WorkTools.Remove(work_toolD);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
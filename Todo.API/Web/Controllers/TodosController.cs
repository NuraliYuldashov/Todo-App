using Application.Common.Exceptions;
using Application.DTOs.TodoDtos;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TodosController(ITodoService todoService)
    : ControllerBase
{
    private readonly ITodoService _todoService = todoService;

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        try
        {
            var todos = await _todoService.GetTodosAsync(userId);
            var data = todos.Select(t => new
            {
                id = t.Id,
                title = t.Title,
                isCompleted = t.IsCompleted,
                deadLine = t.DeadLine,
                userId = t.UserId,
                expired = t.DeadLine < DateTime.Now && !t.IsCompleted
            });
            return Ok(data);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]  
    public async Task<IActionResult> Post([FromBody] AddTodoDto todoDto)
    {
        try
        {
            var todo = await _todoService.CreateTodoAsync(todoDto);
            return Ok(todo);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] TodoDto todoDto)
    {
        try
        {
            var todo = await _todoService.UpdateTodoAsync(todoDto);
            return Ok(todo);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id)
    {
        try
        {
            await _todoService.UpdateStatusAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _todoService.DeleteTodoAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
using CaWorkshop.Application.TodoItems.Commands.CreateTodoItem;
using CaWorkshop.Application.TodoItems.Commands.DeleteTodoItem;
using CaWorkshop.Application.TodoItems.Commands.UpdateTodoItem;
using Microsoft.AspNetCore.Mvc;

namespace CaWorkshop.WebUI.Controllers;

public class TodoItemsController : ApiControllerBase
{
    // PUT: api/TodoItems/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PutTodoItem(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return BadRequest();

        await Mediator.Send(command);

        return NoContent();
    }

    // POST: api/TodoItems
    [HttpPost]
    public async Task<ActionResult<int>> PostTodoItem(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}

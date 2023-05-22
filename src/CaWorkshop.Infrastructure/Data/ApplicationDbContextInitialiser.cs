using CaWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Infrastructure.Data;

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Initialise()
    {
        //_context.Database.EnsureDeleted();
        //_context.Database.EnsureCreated();
        _context.Database.Migrate();
    }

    public void Seed()
    {
        if (_context.TodoLists.Any())
        {
            return;
        }

        var list = new TodoList
        {
            Title = "Todo List",
            Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
        };

        _context.TodoLists.Add(list);
        _context.SaveChanges();
    }
}

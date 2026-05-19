using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using blog.Data;
using blog.Models;

namespace blog.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public string Name { get; set; } = "";

    public List<Person> Persons { get; set; } = new();

    public void OnGet()
    {
        Persons = _db.Persons.ToList();
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            _db.Persons.Add(new Person
            {
                Name = Name
            });

            _db.SaveChanges();
        }

        return RedirectToPage();
    }
}
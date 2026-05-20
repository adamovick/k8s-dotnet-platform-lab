using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using blog.Data;
using blog.Models;

namespace blog.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(AppDbContext db, ILogger<IndexModel> logger)
    {
        _db = db;
        _logger = logger;
    }

    [BindProperty]
    public string Name { get; set; } = "";

    public List<Person> Persons { get; set; } = new();

    public void OnGet()
    {
        Persons = _db.Persons.ToList();

        _logger.LogInformation("Ana sayfa açıldı. Toplam kayıt sayısı: {Count}", Persons.Count);
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

            _logger.LogInformation("Yeni kayıt eklendi: {Name}", Name);
        }
        else
        {
            _logger.LogWarning("Boş isim gönderilmeye çalışıldı.");
        }

        return RedirectToPage();
    }
}
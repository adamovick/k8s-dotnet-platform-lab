using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string WelcomeMessage { get; set; } = "";
    public string ContactEmail { get; set; } = "";
    public string PodName { get; set; } = "";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        WelcomeMessage =
            Environment.GetEnvironmentVariable("WELCOME_MESSAGE")
            ?? "Hello from default app configuration";
        ContactEmail =
            Environment.GetEnvironmentVariable("CONTACT_EMAIL")
            ?? "contact unavailable";
        PodName =
        Environment.GetEnvironmentVariable("HOSTNAME")
        ?? "unknown pod";
    }
}
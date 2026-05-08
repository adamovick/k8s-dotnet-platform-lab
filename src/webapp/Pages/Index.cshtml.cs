public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string WelcomeMessage { get; set; } = "";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        WelcomeMessage = Environment.GetEnvironmentVariable("WELCOME_MESSAGE") ?? "Hello from default app configuration";
    }
}
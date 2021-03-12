using Employee.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employee.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public AppSettings _appSettings;
        public string Text { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _appSettings = settings.Value;
        }

        [BindProperty]
        public List<EmployeeEntity> Employees { get; set; }
        public async Task<IActionResult>  OnGet()
        {
            JsonSerializerOptions jsonOptions;

            //inside constructor
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_appSettings.ApiUrl}/api/Employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Employees= JsonSerializer.Deserialize<List<EmployeeEntity>>(apiResponse, jsonOptions);
                    return Page();
                }
            }
        }
    }
}

using ECommerce.Contracts.Authors;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.WebSockets;

namespace ECommerce.Web.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IAuthorsService _AuthorsService;
        public Index(ILogger<Index> logger, IAuthorsService AuthorsService)
        {
            _logger = logger;
            _AuthorsService = AuthorsService;
        }

        public void OnGet()
        {
            
           this.Authors = _AuthorsService.GetAll();

        }

        public List<AuthorsDto> Authors { get; set; }
    }
}
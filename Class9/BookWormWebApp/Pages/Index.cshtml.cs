using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookWormWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public async Task<ActionResult> OnGet(int theValue = 10)
        {
            BookService.ServiceClient serviceClient = new BookService.ServiceClient();
            Result = await serviceClient.GetDataAsync(theValue);
            return Page();
        }

        public string Result { get; set; }
    }
}

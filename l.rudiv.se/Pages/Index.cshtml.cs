using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chic.Abstractions;
using l.rudiv.se.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace l.rudiv.se.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Url { get; set; }

        public bool IsGenerated { get; set; }
        public int MyId { get; set; }
        public string MyIdAlpha => AlphaRef.Convert(MyId);

        readonly IRepository<Linkypoo> repo;
        public IndexModel(IRepository<Linkypoo> repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var any = await repo.GetByIdAsync(AlphaRef.Reverse(id));
                if (any != null)
                {
                    return RedirectPermanent(any.Url);
                }
            }

            return Page();
        }

        public async Task OnPostAsync()
        {
            var any = await repo.GetByWhereAsync("Url = @Url", new { Url });
            if (!any.Any())
            {
                await repo.InsertAsync(new Linkypoo
                {
                    Url = Url
                });
                any = await repo.GetByWhereAsync("Url = @Url", new { Url });
            }

            IsGenerated = true;
            MyId = any.First().Id;
        }
    }
}

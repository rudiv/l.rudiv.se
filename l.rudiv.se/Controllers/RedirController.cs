using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chic.Abstractions;
using l.rudiv.se.Pages;
using l.rudiv.se.Services;
using Microsoft.AspNetCore.Mvc;

namespace l.rudiv.se.Controllers
{
    public class RedirController : Controller
    {
        readonly IRepository<Linkypoo> repo;
        public RedirController(IRepository<Linkypoo> repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var any = await repo.GetByIdAsync(AlphaRef.Reverse(id));
                if (any != null)
                {
                    return RedirectPermanent(any.Url);
                }
            }
            return Redirect("/");
        }
    }
}
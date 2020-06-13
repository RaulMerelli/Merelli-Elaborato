using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using imgAPI.Models;

namespace imgAPI.Pages.PCX
{
    public class indexModel : PageModel
    {
        [BindProperty]
        public List<string> imgs { get; set; }

        private readonly PCXcontainerContext _containerContext;
        public indexModel(PCXcontainerContext containerContext)
        {
            _containerContext = containerContext;
        }

        public void OnGet()
        {
            imgs = new List<string>();
            foreach (var item in _containerContext.PCXcontainers)
            {
                imgs.Add(item.convertedImg);
            }
        }
    }
}
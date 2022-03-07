using Kitap.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kitap.Controllers
{
    public class ImageController : Controller
    {
        private readonly KitapContext _context;
        public ImageController(KitapContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            var objfiles = new Kitaplar()
            {

                KitapAdi = "test",
                Ozet = "testas",
                KitapSayfaSayisi = 14,
                YazarAdi = "testasada",

            };
            if (files != null)
            {
                if (files.Length > 0)
                {
                    ////Getting FileName
                    //var fileName = Path.GetFileName(files.FileName);
                    ////Getting file Extension
                    //var fileExtension = Path.GetExtension(fileName);
                    //// concatenating  FileName + FileExtension
                    //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                   

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.Image = target.ToArray();
                    }
                    
                    _context.Add(objfiles);
                    _context.SaveChanges();
                   
                    
                }
                
            }
            
            return File(objfiles.Image,"image/jpeg");
        }
    }
}

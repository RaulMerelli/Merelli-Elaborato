using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using imgAPI.Models;
using MerelliPCX;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace imgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TGAController : ControllerBase
    {
        private readonly TGAcontainerContext _context;

        public TGAController(TGAcontainerContext context)
        {
            _context = context;
        }

        // GET api/tga
        [HttpGet]
        public ActionResult<object> GetLastMine()
        {
            string IPaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var data = _context.TGAcontainers.Where(x => IPaddress == x.IPaddress);
            if (data.Count() > 0)
            {
                return data.OrderByDescending(x => x.dateTime).Select(x => new { FileFormat = x.downloadFormat, width = x.width, height = x.height, ConvertedImg = x.convertedImg }).FirstOrDefault();
            }
            else
            {
                return new { FileFormat = "", width = "", height = "", ConvertedImg = "Non risultano immagini inviate dal tuo indirizzo" };
            }
        }

        // GET api/tga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            var Item = await _context.TGAcontainers.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return new { FileFormat = Item.downloadFormat, width = Item.width, height = Item.height, ConvertedImg = Item.convertedImg };
        }

        // POST api/tga
        [HttpPost]
        public async Task<ActionResult<object>> PostImg()
        {
            string root = "tga/";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            TGAcontainer containerTemp = new TGAcontainer();
            containerTemp.IPaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            ImgUpload temp = new ImgUpload();
            Request.Headers["filename"] = Regex.Replace(Request.Headers["filename"], "[^a-zA-Z0-9% ._]", string.Empty);
            containerTemp.filename = Request.Headers["filename"] + ".tga";
            containerTemp.originalImg = root + DateTime.Now.ToString("dd-MM-yyyy-hh_mm-ss-ffff") + "_" + Request.Headers["filename"] + ".tga";
            temp.FileName = containerTemp.filename;
            using (var fs = new FileStream("wwwroot/" + containerTemp.originalImg, FileMode.Create))
            {
                Request.Body.CopyTo(fs);
            }

            try
            {
                var extension = ImageExtensions.GetImageFormat(Request.Headers["extension"]);
                var stringExtension = Request.Headers["extension"];
                var image = new Paloma.TargaImage("wwwroot/" + containerTemp.originalImg);
                containerTemp.version = image.Format;
                Bitmap convertedImage = new Bitmap(image.Image);
                image.Dispose();

                using (var bitmap = new Bitmap(convertedImage))
                {
                    string filename = root + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss-ffff") + "_" + Request.Headers["filename"] + stringExtension;
                    bitmap.Save("wwwroot/" + filename, extension);
                    containerTemp.convertedImg = filename;
                }
                containerTemp.dateTime = DateTime.Now;
                containerTemp.downloadFormat = stringExtension;
                containerTemp.height = convertedImage.Height;
                containerTemp.width = convertedImage.Width;
                convertedImage.Dispose();
                _context.TGAcontainers.RemoveRange(_context.TGAcontainers.OrderBy(x => x.dateTime).Take(_context.TGAcontainers.Count() - 4));
                _context.TGAcontainers.Add(containerTemp);
                await _context.SaveChangesAsync();
                temp.id = _context.TGAcontainers.Last().id;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return NotFound();
            }
            return temp;
        }
    }
}

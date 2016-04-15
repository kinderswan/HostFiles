using Epam.HostFiles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Epam.HostFiles.Web.Controllers.Api
{
    public class DirectoryController : ApiController
    {
        private readonly IFileMethods _fileMethods;

        public DirectoryController(IFileMethods fileMethods)
        {
            _fileMethods = fileMethods;
        }

        [Route("api/files/{drive}:/{*path}")]
        public IHttpActionResult GetFakeFiles(string drive, string path)
        {
            var filesPath = drive + "\\" + path;
            return Json(_fileMethods.GetFiles(filesPath));
        }

        [Route("api/files/")]
        public IHttpActionResult GetFakeDrives()
        {
            var drives = DriveInfo.GetDrives();
            return Json(drives);
        }

        [HttpPost]
        [Route("api/files/{drive}:/{*path}")]
        public async Task GetFakePaths(string drive, string path)
        {
            var file = HttpContext.Current.Request.Files[0];
            string filepath;
            if (path != null)
            {
                filepath = drive + ":\\" + path + "\\" + file.FileName;
            }
            else
            {
                filepath = drive + ":\\" + file.FileName;
            }
            await _fileMethods.AddFile(file.InputStream, filepath);
        }
    }
}

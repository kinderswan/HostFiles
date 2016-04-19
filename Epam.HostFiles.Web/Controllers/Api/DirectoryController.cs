using Epam.HostFiles.IO.Interfaces;
using Newtonsoft.Json;
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
        private readonly IDirectoryMethods _dirMethods;

        public DirectoryController(IFileMethods fileMethods, IDirectoryMethods dirMethods)
        {
            _fileMethods = fileMethods;
            _dirMethods = dirMethods;
        }

        [Route("api/files/{drive}:/{*path}")]
        public IHttpActionResult GetFiles(string drive, string path)
        {
            var filesPath = drive + ":\\" + path;
            var parseList = new List<dynamic>();
            foreach (var x in _fileMethods.GetFiles(filesPath))
            {
                parseList.Add(new { fileName = x.Name, path = x.FullName, size = x.Length });
            }
            return Json(parseList);
        }

        [Route("api/dirs/{drive}:/{*path}")]
        public IHttpActionResult GetDrives(string drive, string path)
        {
            var drivesPath = drive + ":\\" + path;

            var parseList = new List<dynamic>();
            foreach (var x in _dirMethods.GetDirectories(drivesPath))
            {
                parseList.Add(new { directoryName = x });
            }
            return Json(parseList);
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

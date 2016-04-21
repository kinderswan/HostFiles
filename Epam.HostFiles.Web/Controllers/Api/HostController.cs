using Epam.HostFiles.IO.Interfaces;
using Epam.HostFiles.Web.Global.Helpers;
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
    public class HostController : ApiController
    {
        private readonly IFileMethods _fileMethods;
        private readonly IDirectoryMethods _dirMethods;

        public HostController(IFileMethods fileMethods, IDirectoryMethods dirMethods)
        {
            _fileMethods = fileMethods;
            _dirMethods = dirMethods;
        }

        #region directories
        [HttpGet]
        [Route("api/dirs/{drive}:/{*path}")]
        public IHttpActionResult GetDrives(string drive, string path)
        {
            var drivesPath = (drive + ":\\" + path).Replace(@"/", @"\");
            var parseList = new List<dynamic>();
            foreach (var x in _dirMethods.GetDirectories(drivesPath))
            {
                parseList.Add(new { directoryName = x });
            }
            return Json(parseList);
        }
        [HttpPost]
        [Route("api/dirs/{drive}:/{*path}")]
        public IHttpActionResult AddDirectory(string drive, string path)
        {
            var dirName = HttpContext.Current.Request.Form[0];
            string dirpath = path == null ?
                drive + ":\\" + dirName :
                drive + ":\\" + path.Replace(@"/", @"\") + "\\" + dirName;
            return Json(_dirMethods.AddDirectory(dirpath));
        }
        #endregion

        #region files

        [Route("api/files/{drive}:/{*path}")]
        public IHttpActionResult GetFiles(string drive, string path)
        {
            var filesPath = (drive + ":\\" + path).Replace(@"/", @"\");
            var parseList = new List<dynamic>();
            foreach (var x in _fileMethods.GetFiles(filesPath))
            {
                parseList.Add(new { fileName = x.Name, path = x.FullName, size = x.Length });
            }
            return Json(parseList);
        }

        [HttpGet]
        [Route("api/files/download/{drive}:/{*path}")]
        public IHttpActionResult Download(string drive, string path)
        {
            var filesPath = (drive + ":\\" + path).Replace(@"/", @"\");
            var fileInfo = new FileInfo(filesPath);
            return !fileInfo.Exists
                ? (IHttpActionResult)NotFound()
                : new HttpFileResult(fileInfo.FullName);
        }

        [HttpPost]
        [Route("api/files/{drive}:/{*path}")]
        public async Task UploadFile(string drive, string path)
        {
            var file = HttpContext.Current.Request.Files[0];
            string filepath = path == null ?
                drive + ":\\" + file.FileName :
                drive + ":\\" + path.Replace(@"/", @"\") + "\\" + file.FileName;
            await _fileMethods.AddFile(file.InputStream, filepath);
        }
        #endregion
    }
}

using Epam.HostFiles.IO.Interfaces;
using Epam.HostFiles.Web.Global.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Epam.HostFiles.Web.Mapping;
using Epam.HostFiles.Web.Global.Auth;

namespace Epam.HostFiles.Web.Controllers.Api
{
    public class HostController : ApiController
    {
        private readonly IFileMethods _fileMethods;
        private readonly IDirectoryMethods _dirMethods;
        private readonly IDriveMethods _driveMethods;
        private readonly IAuthentication _auth;

        public HostController(IFileMethods fileMethods, IDirectoryMethods dirMethods, IDriveMethods driveMethods)
        {
            _fileMethods = fileMethods;
            _dirMethods = dirMethods;
            _driveMethods = driveMethods;
            _auth = (IAuthentication)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthentication));
        }

        #region drives
        [HttpGet]
        [Route("api/drives")]
        public IHttpActionResult GetDrives()
        {
            return Json(_driveMethods.GetDrives().Select(x => x.ToDriveViewModel()));
        }
        #endregion

        #region directories
        [HttpGet]
        [Route("api/dirs/{drive}:/{*path}")]
        public IHttpActionResult GetDrives(string drive, string path)
        {
            var drivesPath = (drive + ":\\" + path).Replace(@"/", @"\");
            return Json(_dirMethods.GetDirectories(drivesPath).Select(x => x.ToDirectoryViewModel()));
        }

        [HostFilesAuthorize(Roles ="Admin")]
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
            return Json(_fileMethods.GetFiles(filesPath).Select(x => x.ToFileViewModel()));
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

        [HostFilesAuthorize(Roles = "Admin")]
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

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Epam.HostFiles.Web.Global.Helpers
{
    public class HttpFileResult : IHttpActionResult
    {
        private readonly string _filePath;
        private readonly string _contentType;

        public HttpFileResult(string filePath, string contentType = null)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");

            _filePath = filePath;
            _contentType = contentType;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            try
            {
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(File.OpenRead(_filePath))
                };
            }
            catch (IOException ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(ex.Message)
                };
                return Task.FromResult(response);
            }
            var contentType = _contentType ?? MimeMapping.GetMimeMapping(Path.GetExtension(_filePath));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return Task.FromResult(response);
        }
    }
}
using Epam.HostFiles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace Epam.HostFiles.IO
{
    public class FileMethods : IFileMethods
    {

        public async Task<FileInfo> AddFile(Stream contentStream, string path)
        {
            using (Stream file = File.Create(path))
            {
               await CopyStream(contentStream, file);
            }
            return new FileInfo(path);
        }

        public Stream DownloadFile(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                return fs;
            }
        }

        public IEnumerable<FileInfo> GetFiles(string path)
        {
            return new DirectoryInfo(path).GetFiles();
        }

        private async Task CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
               await output.WriteAsync(buffer, 0, len);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using log4net;

namespace TalBrody
{
    public class PageMethodExceptionLogger : Stream
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // http://stackoverflow.com/a/24222240/11236

        private readonly HttpResponse _response;
        private readonly Stream _baseStream;
        private readonly MemoryStream _capturedStream = new MemoryStream();

        public PageMethodExceptionLogger(HttpResponse response)
        {
            _response = response;
            _baseStream = response.Filter;
        }

        public override void Close()
        {
            if (_response.StatusCode == 500 && _response.Headers["jsonerror"] == "true")
            {
                _capturedStream.Position = 0;
                string responseJson = new StreamReader(_capturedStream).ReadToEnd();
                log.Error("Caught WebMethod Exception: " + responseJson);
            }

            _baseStream.Close();
            base.Close();
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _baseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _baseStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _baseStream.Write(buffer, offset, count);
            _capturedStream.Write(buffer, offset, count);
        }

        public override bool CanRead { get { return _baseStream.CanRead; } }
        public override bool CanSeek { get { return _baseStream.CanSeek; } }
        public override bool CanWrite { get { return _baseStream.CanWrite; } }
        public override long Length { get { return _baseStream.Length; } }

        public override long Position
        {
            get { return _baseStream.Position; }
            set { _baseStream.Position = value; }
        }
    }
}
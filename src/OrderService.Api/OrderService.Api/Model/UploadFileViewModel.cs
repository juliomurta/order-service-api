using System;
using System.Formats.Tar;

namespace OrderService.Api.Model
{
    public class UploadFileViewModel
    {
        private string fileAsBase64;

        public Guid EmployeeId { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public long LastModifiedTime { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string FileAsBase64 
        { 
            get
            {
                if (string.IsNullOrEmpty(this.fileAsBase64))
                {
                    return string.Empty;
                }

                var index = this.fileAsBase64.IndexOf(",");
                if (index >= 0)
                {
                    return this.fileAsBase64.Substring(index + 1);
                }
                else
                {
                    return this.fileAsBase64;
                }
            }

            set 
            { 
                this.fileAsBase64 = value;
            } 
        }

        public byte[] FileAsByteArray 
        { 
            get
            {
                if (string.IsNullOrEmpty(this.FileAsBase64))
                {
                    return null;
                }                                   
                
                return Convert.FromBase64String(this.FileAsBase64);
              
            }
        }
    }
}

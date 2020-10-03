using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUploadData;
using FileUploadData.Model;
using FileUploadDataAccess;
using System.IO;

namespace FileUploadBusiness
{
    public class FileUploadBIL : IFileUploadService
    {
        public IEnumerable<FileUploadModel> getByCurrency(string currencyCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileUploadModel> getByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public bool insert(IEnumerable<FileUpload> fileuploads)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileUploadModel> getAll()
        {
            FileUploadDataAccess.IFileUploadService service = new FileUploadDAL();
            return service.getAll();
        }

        public String validateFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if(((fi.Length / 1024f) / 1024f) >1)
            {
                return "";
            }
            else if(fi.Extension!="CSV" && fi.Extension!="XML")
            {
                return "Unknown format.";
            }
            else
            {
                return "HTTP Code 200.";
            }
        }
    }
}

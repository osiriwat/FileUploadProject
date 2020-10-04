using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUploadData;
using FileUploadData.Model;
using FileUploadDataAccess;
using System.IO;
using FileUploadCommon;
using static FileUploadCommon.UploadEnum;

namespace FileUploadBusiness
{
    public class FileUploadBIL : IFileUploadService
    {
        FileUploadDataAccess.IFileUploadService service = null;
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

        public bool insert(string filePath)
        {
            var result = false;
            var validMsg = validateFile(filePath);
            if (validMsg == "HTTP Code 200.")
            {
                service = new FileUploadDAL();

                if (Path.GetExtension(filePath).Contains(FileType.CSV.ToString()))
                {
                    result = service.insert(CsvHelper.convertCsvToModel(filePath));
                }
                else
                {
                    result = service.insert(XmlHelper.convertXmlToModel(filePath));
                }
            }
            return result;
        }

        public IEnumerable<FileUploadModel> getAll()
        {
            service = new FileUploadDAL();
            return service.getAll();
        }

        public String validateFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (((fi.Length / 1024f) / 1024f) > 1)
            {
                return "File size is max 1 MB.";
            }
            else if (fi.Extension.ToUpper().Contains(FileType.CSV.ToString()) && fi.Extension.ToUpper().Contains(FileType.XML.ToString()))
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

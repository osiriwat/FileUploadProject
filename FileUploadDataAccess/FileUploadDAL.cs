using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUploadData;
using FileUploadData.Model;

namespace FileUploadDataAccess
{
    public class FileUploadDAL : IFileUploadService
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
    }
}

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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        FileUploadDataAccess.IFileUploadService service = null;
        public ResultModel<FileUploadModel> getByCurrency(string currencyCode)
        {
            ResultModel<FileUploadModel> result = new ResultModel<FileUploadModel>();
            try
            {
                service = new FileUploadDAL();
                result.Status = true;
                result.Objects = service.getByCurrency(currencyCode);
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultModel<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate)
        {
            ResultModel<FileUploadModel> result = new ResultModel<FileUploadModel>();
            try
            {
                service = new FileUploadDAL();
                result.Status = true;
                result.Objects = service.getByDateRange(startTranDate, endTranDate);
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultModel<FileUploadModel> getByStatus(string status)
        {
            ResultModel<FileUploadModel> result = new ResultModel<FileUploadModel>();
            try
            {
                service = new FileUploadDAL();            
                var mol= service.getByStatus(status);
                result.TotalRecord = mol.Count();
                result.Status = true;
                result.Objects = mol;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultModel<FileUploadModel> insert(string filePath)
        {
            log.Info("Start");
            ResultModel<FileUploadModel> result = new ResultModel<FileUploadModel>();
            var validMsg = validateFile(filePath);
            if (validMsg == "HTTP Code 200.")
            {
                try
                {
                    service = new FileUploadDAL();
                    if (Path.GetExtension(filePath.ToUpper()).Contains(FileType.CSV.ToString()))
                    {
                        result.Status = service.insert(CsvHelper.convertCsvToModel(filePath));
                    }
                    else
                    {
                        result.Status = service.insert(XmlHelper.convertXmlToModel(filePath));
                    }
                    result.Message = validMsg;
                    log.Info("End");
                }
                catch (Exception ex)
                {
                    log.Error(ex.StackTrace);
                    result.Status = false;
                    result.Message = ex.Message;
                }
            }
            else
            {
                result.Status = false;
                result.Message = validMsg;
            }
            return result;
        }

        public ResultModel<FileUploadModel> getAll()
        {
            ResultModel<FileUploadModel> result = new ResultModel<FileUploadModel>();           
            try
            {
                service = new FileUploadDAL();
                result.Status = true;
                result.Objects = service.getAll();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public String validateFile(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (((fi.Length / 1024f) / 1024f) > 1)
            {
                return "File size is max 1 MB.";
            }
            else if (!fi.Extension.ToUpper().Contains(FileType.CSV.ToString()) && !fi.Extension.ToUpper().Contains(FileType.XML.ToString()))
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

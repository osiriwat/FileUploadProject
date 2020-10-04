using FileUploadData;
using FileUploadData.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileUploadDataAccess
{
    public class FileUploadDAL : IFileUploadService
    {
        #region IEnumerable<FileUploadModel> getByCurrency(string currencyCode)

        public IEnumerable<FileUploadModel> getByCurrency(string currencyCode)
        {
            IEnumerable<FileUploadModel> result = null;
            try
            {
                using (var ctx = new FileUploadDbEntities())
                {
                    result = (from f in ctx.FileUpload
                              where f.CurrencyCode == currencyCode
                              select new FileUploadModel { Id = f.TransactionId, Payment = f.Amount.ToString() + " " + f.CurrencyCode, Status = ((f.Status == "Finished" || f.Status == "Done") ? "D" : ((f.Status == "Failed" || f.Status == "Rejected") ? "R" : "A")) }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion 

        #region IEnumerable<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate)

        public IEnumerable<FileUploadModel> getByDateRange(DateTime startTranDate, DateTime endTranDate)
        {
            IEnumerable<FileUploadModel> result = null;
            try
            {
                using (var ctx = new FileUploadDbEntities())
                {
                    result = (from f in ctx.FileUpload
                              where f.TransactionDate >= startTranDate && f.TransactionDate <= endTranDate
                              select new FileUploadModel { Id = f.TransactionId, Payment = f.Amount.ToString() + " " + f.CurrencyCode, Status = ((f.Status == "Finished" || f.Status == "Done") ? "D" : ((f.Status == "Failed" || f.Status == "Rejected") ? "R" : "A")) }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion 

        #region IEnumerable<FileUploadModel> getByStatus(string status)

        public IEnumerable<FileUploadModel> getByStatus(string status)
        {
            IEnumerable<FileUploadModel> result = null;
            try
            {
                using (var ctx = new FileUploadDbEntities())
                {
                    result = (from f in ctx.FileUpload
                              where f.Status == status
                              select new FileUploadModel { Id = f.TransactionId, Payment = f.Amount.ToString() + " " + f.CurrencyCode, Status = ((f.Status == "Finished" || f.Status == "Done") ? "D" : ((f.Status == "Failed" || f.Status == "Rejected") ? "R" : "A")) }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        #endregion 

        #region IEnumerable<FileUploadModel> getAll()

        public IEnumerable<FileUploadModel> getAll()
        {
            IEnumerable<FileUploadModel> result = null;
            try
            {
                using (var ctx = new FileUploadDbEntities())
                {
                    result = (from f in ctx.FileUpload
                              select new FileUploadModel { Id = f.TransactionId, Payment = f.Amount.ToString() + " " + f.CurrencyCode, Status = ((f.Status == "Finished" || f.Status == "Done") ? "D" : ((f.Status == "Failed" || f.Status == "Rejected") ? "R" : "A")) }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }


        #endregion 

        #region bool insert(IEnumerable<FileUpload> fileuploads)

        public bool insert(IEnumerable<FileUpload> fileuploads)
        {
            bool result = false;
            try
            {
                using (var ctx = new FileUploadDbEntities())
                {
                    ctx.FileUpload.AddRange(fileuploads);
                    ctx.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        #endregion 
    }
}
using FileUploadData;
using FileUploadData.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileUploadCommon
{
    public class XmlHelper
    {
        #region static List<FileUpload> convertXmlToModel(string xmlFilePath)
        public static List<FileUpload> convertXmlToModel(string xmlFilePath)
        {
            List<FileUpload> results = new List<FileUpload>();
            DateTime now = DateTime.Now;
            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Transactions));
                Transactions transactions = (Transactions)serializer.Deserialize(fileStream);
     
                foreach (var tran in transactions.Transaction)
                {
                    FileUpload fileUpload = new FileUpload();
                    fileUpload.TransactionId=tran.id;
                    fileUpload.Amount = Convert.ToDecimal(tran.PaymentDetails.Amount);
                    fileUpload.CurrencyCode = tran.PaymentDetails.CurrencyCode;
                    fileUpload.TransactionDate = Convert.ToDateTime(tran.TransactionDate);
                    fileUpload.Status = tran.Status;
                    fileUpload.CreatedDate = now;
                    fileUpload.FileType = UploadEnum.FileType.XML.ToString();
                    results.Add(fileUpload);
                }
            }
            return results;
        }
        #endregion 
    }
}

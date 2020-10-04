using FileUploadData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileUploadCommon
{
    public class CsvHelper
    {
        #region static List<FileUpload> convertCsvToModel(string csvFilePath)
        public static List<FileUpload> convertCsvToModel(string csvFilePath)
        {
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            List<FileUpload> results = new List<FileUpload>();
            var reader = new StreamReader(File.OpenRead(csvFilePath));
            DateTime now = DateTime.Now;
            while (!reader.EndOfStream)
            {               
                var line = reader.ReadLine();
                var values = CSVParser.Split(line);

                FileUpload fileUpload = new FileUpload();
                fileUpload.TransactionId = removeSpecialCharacter(values[0]);
                fileUpload.Amount = Convert.ToDecimal(removeSpecialCharacter(values[1]));
                fileUpload.CurrencyCode = removeSpecialCharacter(values[2]);
                fileUpload.TransactionDate = Convert.ToDateTime(removeSpecialCharacter(values[3]));
                fileUpload.Status = removeSpecialCharacter(values[4]);
                fileUpload.CreatedDate = now;
                fileUpload.FileType = UploadEnum.FileType.CSV.ToString();
                results.Add(fileUpload);
            }
            return results;
        }
        public static string removeSpecialCharacter(string s)
        {
            return s.Replace("\"", "");
        }
        #endregion
    }

}
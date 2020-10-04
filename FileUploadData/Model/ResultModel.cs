using System.Collections.Generic;

namespace FileUploadData.Model
{
    public class ResultModel<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public IEnumerable<T> Objects { get; set; }

        public int TotalRecord { get; set; }
    }
}
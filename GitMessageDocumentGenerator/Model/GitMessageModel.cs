using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitMessageDocumentGenerator.Model
{
    public class GitMessageModel
    {

        public required string Commit { get; set; }
        public required string Merge { get; set; }
        public required string Author { get; set; }
        public required DateTime Date { get; set; }
        public string DateTimeString => Date.ToString("yyyy/MM/dd HH:mm:ss");
        public required string Message { get; set; }
        public required string Tag { get; set; }
        public required string Issue { get; set; }
    }
}

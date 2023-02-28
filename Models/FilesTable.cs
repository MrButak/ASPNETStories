using System.ComponentModel.DataAnnotations;

namespace Stories.Models
{
    public class FilesTable
    {
        [Key] public int FileId { get; set; }
        public byte[] PdfFile { get; set; }
    }
}

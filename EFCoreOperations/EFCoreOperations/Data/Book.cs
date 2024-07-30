using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreOperations.Data
{
    public class Book
    {
         public int Id { get; set; }
         public string Title { get; set; }
         public string Description { get; set; }
         public int NoOfPages{ get; set; }  
         public bool IsActive { get; set; }
         public DateTime CreatedOn { get; set; }
         public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
         public Language Language { get; set; }
    }
}

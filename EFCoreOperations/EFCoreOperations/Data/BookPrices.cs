using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace EFCoreOperations.Data
{
    public class BookPrices
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CurrencyId { get; set; }
        public int Amount { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currencies Currency { get; set; }
    }
}

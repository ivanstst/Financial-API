using System.ComponentModel.DataAnnotations;

namespace Financial.Data.Models
{
    public class View
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SymbolId { get; set; }
        public Symbol Symbol { get; set; }
        public string Interval { get; set; }
    }
}

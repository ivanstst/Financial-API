using System.ComponentModel.DataAnnotations;

namespace Financial.Data.Models
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Symbol(string name)
        {
            this.Name = name;
        }
    }
}

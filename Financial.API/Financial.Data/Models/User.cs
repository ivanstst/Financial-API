using System.ComponentModel.DataAnnotations;

namespace Financial.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            this.Name = name;
        }
    }
}

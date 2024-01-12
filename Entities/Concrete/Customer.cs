using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key] // Anahtar olduğunu belirtmek için kullanılır
        public int UserID { get; set; }
        public string CompanyName { get; set; }
    }
}

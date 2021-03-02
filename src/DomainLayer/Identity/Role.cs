using System.ComponentModel.DataAnnotations;


namespace DomainLayer
{
   public class Role
    {
 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

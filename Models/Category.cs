using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEf.Models
{
    //[Table("Category")]
    public class Category
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[MinLength(3)]
        //[MaxLength(80)]
        //[Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        //[Required]
        //[MinLength(3)]
        //[MaxLength(80)]
        //[Column("Slug", TypeName = "NVARCHAR")]
        public string Slug { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
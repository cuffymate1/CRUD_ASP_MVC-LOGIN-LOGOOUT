using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key] // กำหนด primary key
        public int Id { get; set; }

        [Required] // ระบุว่าห้ามเป็นค่าว่าง
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("DisplayOrder")]
        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}

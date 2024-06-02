using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace donetCore_beginner.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="請輸入商品名稱")]
        [MaxLength(30)]
        [DisplayName("商品名稱")]
        public string? Name { get; set; }

        [Range(1,100, ErrorMessage ="請輸入1~100的整數數字")]
		[DisplayName("商品數量")]
		public int DisplayOrder { get; set; }
    }
}

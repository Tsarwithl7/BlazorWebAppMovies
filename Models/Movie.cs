using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAppMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "电影名称是必须的")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "电影分级是必须的")]
        [RegularExpression(@"^(G|PG|PG-13|R|NC-17)$")]
        public string? Rating { get; set; }


        public DateOnly ReleaseDate { get; set; }

        [Required(ErrorMessage = "电影类型是必须的")]
        [StringLength(35, ErrorMessage = "电影类型不能超过35个字符")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$",ErrorMessage = "Genre must be in capital letters with no special characters")]
        public string? Genre { get; set; }

        [Range(0,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


    }
}

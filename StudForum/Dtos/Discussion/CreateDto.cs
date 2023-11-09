using System.ComponentModel.DataAnnotations;

namespace StudForum.Dtos.Discussion
{
    public class CreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20)]
        public string Text { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        public string Hashtags { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

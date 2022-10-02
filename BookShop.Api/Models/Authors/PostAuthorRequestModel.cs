namespace BookShop.Api.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    public class PostAuthorRequestModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}

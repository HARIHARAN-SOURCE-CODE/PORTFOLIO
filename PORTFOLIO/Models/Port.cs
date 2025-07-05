using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PORTFOLIO.Models
{
    public class Port
    {

        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ProjectLink { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}

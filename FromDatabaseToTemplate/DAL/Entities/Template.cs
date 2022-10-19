using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FromDatabaseToTemplate.Entities
{
    public class Template
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Content { get; set; }
        public string ContentType { get; set; }
    }
}

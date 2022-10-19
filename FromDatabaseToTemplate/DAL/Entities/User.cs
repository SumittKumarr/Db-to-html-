using System.ComponentModel.DataAnnotations;

namespace FromDatabaseToTemplate.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PolicyNumber { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public string Occupation { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public string Tenure { get; set; }
        public DateTime PolicyExpiryDate { get; set; }



    }
}

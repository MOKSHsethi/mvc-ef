using System.ComponentModel.DataAnnotations;

namespace Assesment_MVC_EF.Models
{
    public class Request
    {

        [Key]
        public int RequestId { get; set; }



        public int UserId { get; set; }



        public int BatchId { get; set; }



        public string Status { get; set; } = "pending";




        public string? Comments { get; set; }



        public int CourseId { get; set; }



        public Course course { get; set; }
    }
}

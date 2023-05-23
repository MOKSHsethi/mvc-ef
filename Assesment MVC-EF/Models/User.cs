namespace Assesment_MVC_EF.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }    

        public string Address { get; set; }

        public string Phone { get; set; }
        public Role UserRole { get; set; }
        public string? ManagerName { get; set; }

        public int ? ManagerId { get; set; }

        public bool IsActive { get; set; }
    }

    public enum Role
        {
            Employee,
            Manager, 
           
        }
     
}

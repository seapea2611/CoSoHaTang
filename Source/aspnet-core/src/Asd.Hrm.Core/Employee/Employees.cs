namespace Asd.Hrm.Employee
{
    [Table("Employees")]
    public class Employees : Entity
    {
        public virtual string EmployeeID { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Role { get; set; }
    }
}
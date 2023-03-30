using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Web.Data
{
    public class MyControlAllocation : BaseEntity
    {
        
        public int NumberOfDays { get; set; }

        [ForeignKey("MyControlTypeID")]
        public MyControlType? MyControlType { get; set; }
        public int MyControlTypeID { get; set; }

        public string? EmployeeId { get; set; }
       
    }
}

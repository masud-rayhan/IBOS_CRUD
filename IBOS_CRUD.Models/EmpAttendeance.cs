using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBOS_CRUD.Models
{
    public class EmpAttendeance
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public DateTime AttendanceDate { get; set; }
        public Boolean isPresent { get; set; }
        public Boolean isAbsent { get; set; }
        public Boolean isOffday { get; set; }


    }
}

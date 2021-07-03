using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity
{
    public class TblEmployeeMaster
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateofBirth { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryMaster CountryMaster { get; set; }

        public int? StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual StateMaster StateMaster { get; set; }

        public int? Cityid { get; set; }

        [ForeignKey("Cityid")]
        public virtual CityMaster CityMaster { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }



    }
}

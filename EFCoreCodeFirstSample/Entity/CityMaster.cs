using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity
{
    public class CityMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cityid { get; set; }

        public string CityName { get; set; }

        public int? StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual StateMaster StateMaster { get; set; }
        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryMaster CountryMaster { get; set; }


      

    }
}

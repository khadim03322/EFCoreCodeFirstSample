using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity
{
    public class StateMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        public string StateName { get; set; }


        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryMaster CountryMaster { get; set; }


      

    }
}

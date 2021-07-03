using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity
{
    public class Post
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PostId { get; set; }
        public string Title { get; set; }
   
        public DateTime Date_posted { get; set; }
        public int Position { get; set; }
        public string Body { get; set; }

        public long CategorieId { get; set; }
        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

    }
}

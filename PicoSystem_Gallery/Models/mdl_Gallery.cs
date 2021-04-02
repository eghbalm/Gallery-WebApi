namespace PicoSystem_Gallery.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class mdl_Gallery : DbContext
    {
        public mdl_Gallery()
            : base("name=mdl_Gallery1")
        {
        }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }
        public virtual DbSet<tbl_Photo> tbl_Photos { get; set; }
    }
}

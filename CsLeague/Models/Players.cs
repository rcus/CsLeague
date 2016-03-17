namespace CsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Players
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public int? ClanId { get; set; }

        [Display(Name = "Points")]
        public int Score { get; set; }

        public virtual Clans Clans { get; set; }

    }
}

namespace CsLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Matches
    {
        public int Id { get; set; }

        public int ClanHomeId { get; set; }

        public int? ClanHomeScore { get; set; }

        public int ClanAwayId { get; set; }

        public int? ClanAwayScore { get; set; }

        public DateTime? MatchDate { get; set; }

        public bool IsPlayed { get; set; }

        public virtual Clans Clans { get; set; }

        public virtual Clans Clans1 { get; set; }
    }
}

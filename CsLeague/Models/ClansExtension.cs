namespace CsLeague.Models
{
    using System.Linq;

    public partial class Clans
    {
        public int Played
        {
            get
            {
                return Matches.Count(m => m.IsPlayed == true) + Matches1.Count(m => m.IsPlayed == true);
            }
        }

        public int Won
        {
            get
            {
                return Matches.Count(m => m.ClanHomeScore < m.ClanAwayScore && m.IsPlayed == true) + Matches1.Count(m => m.ClanHomeScore > m.ClanAwayScore && m.IsPlayed == true);
            }
        }

        public int Draw
        {
            get
            {
                return Matches.Count(m => m.ClanHomeScore == m.ClanAwayScore && m.IsPlayed == true) + Matches1.Count(m => m.ClanHomeScore == m.ClanAwayScore && m.IsPlayed == true);
            }
        }

        public int Lost
        {
            get
            {
                return Matches.Count(m => m.ClanHomeScore > m.ClanAwayScore && m.IsPlayed == true) + Matches1.Count(m => m.ClanHomeScore < m.ClanAwayScore && m.IsPlayed == true);
            }
        }

        public string Rounds
        {
            get
            {
                var won = Matches.Where(m => m.ClanAwayScore != null && m.IsPlayed == true).Sum(m => (int) m.ClanAwayScore) + Matches1.Where(m => m.ClanHomeScore != null && m.IsPlayed == true).Sum(m => (int)m.ClanHomeScore);
                var lost = Matches.Where(m => m.ClanHomeScore != null && m.IsPlayed == true).Sum(m => (int) m.ClanHomeScore) + Matches1.Where(m => m.ClanAwayScore != null && m.IsPlayed == true).Sum(m => (int)m.ClanAwayScore);
                return won.ToString() + " - " + lost.ToString();
            }
        }

        public int Points
        {
            get
            {
                return Won * 3 + Draw;
            }
        }

    }
}
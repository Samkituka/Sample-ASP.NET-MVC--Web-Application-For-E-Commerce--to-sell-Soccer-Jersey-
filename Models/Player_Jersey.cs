namespace SoccerJerseyPass.Models
{
    public class Player_Jersey
    {
        public int Soccer_JerseyId { get; set; }

        public int PlayerId { get; set; }

        public Soccer_Jersey Soccer_Jersey { get; set; }

        public Player Player { get; set; }
    }
}

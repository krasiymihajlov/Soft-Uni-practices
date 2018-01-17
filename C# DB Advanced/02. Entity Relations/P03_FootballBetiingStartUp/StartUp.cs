namespace P03_FootballBetiingStartUp
{
    using P03_FootballBetting.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (FootballBettingContext db = new FootballBettingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}

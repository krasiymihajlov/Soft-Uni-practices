namespace AsteroidsGame.Scores
{
    public class ScoreCount
    {
        private static int score = 0;

        public static int IncreaseScore()
        {
            return score++;
        }

    }
}

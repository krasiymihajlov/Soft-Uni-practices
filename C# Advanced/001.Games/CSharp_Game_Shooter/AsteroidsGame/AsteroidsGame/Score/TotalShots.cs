namespace AsteroidsGame.Scores
{
    public class TotalShots
    {
        private static int totalShots = 0;
        private static int score = 0;

        public  void ShotFunction()
        {
            score++;
            //label3.Text = "Score = " + score;
            totalShots++;
            //label1.Text = "Total Shots = " + TotalShots;

        }

        public void SetTextForLabel(string myText)
        {
            this.myLabel.Text = myText;
        }



    }
}

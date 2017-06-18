namespace AsteroidsGame.Sounds
{
    using System.Media;

    public class PlaySound
    {
        /// <summary>
        /// Get path to the sorce files in sonds.
        /// </summary>
        private const string RocketSoundPath = "../../Resources/Rocket.wav";
        private const string BombSoundPath = "../../Resources/Bomb.wav";

        /// <summary>
        /// Declared new SoundPlayer with sound path
        /// </summary>
        public static SoundPlayer mouseSound = new SoundPlayer(RocketSoundPath);
        public static SoundPlayer explodeSound = new SoundPlayer(BombSoundPath);

        /// <summary>
        /// Get and set the mouseSound outside of the class.
        /// </summary>
        public static SoundPlayer MouseSound
        {
            get => mouseSound;
            set => mouseSound = value;
        }

        /// <summary>
        /// Get and set the mouseSound outside of the class.
        /// </summary>
        public static SoundPlayer ExplodeSound
        {
            get => explodeSound;
            set => explodeSound = value;
        }

        /// <summary>
        /// Play mouse sound outside of the class
        /// </summary>
        public static void PlayMouseSound()
        {
            mouseSound.Play();
        }

        /// <summary>
        /// Play explode sound outside of the class
        /// </summary>
        public static void PlayExplodeSound()
        {
            explodeSound.Play();
        }
    }
}

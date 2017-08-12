namespace Engine
{
    public static class Sound
    {
        public static void MakeSound(string filePath)
        {
            System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer(filePath);
            gameOver.PlaySync();
        }
    }
}
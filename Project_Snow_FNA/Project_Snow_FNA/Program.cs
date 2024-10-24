namespace Project_Snow_FNA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using ( SnowFall game = new SnowFall()) // возможно game нельзя менять из-за ссылки на библ
            {
                game.Run();
            }
        }
    }
}

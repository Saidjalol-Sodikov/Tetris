namespace Game

{
    class Program
    {
        static void Main(string[] args)
        {
            bool endGameTotal = true;

            while (endGameTotal)
            {
                //Loading
                while (endGameTotal)
                {
                    int choisInt = -1;
                    Menu menu = new Menu();



                    string choisStr = Console.ReadLine()!;
                    if (Int32.TryParse(choisStr, out choisInt)){
                    choisInt = int.Parse(choisStr);
                    }
                    if (choisInt == 0)
                    {
                        endGameTotal = false;
                    }
                }
            }

        }
    }
}
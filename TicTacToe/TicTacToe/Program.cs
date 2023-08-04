namespace TicTacToe
{
    internal class Program
    {

        //CREATE THE PLAY FIELD
        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'},
        };



        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // PLAYER 1
            int input = 0;
            bool correctInput = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    GeneratePlayerMove('O', input);
                }
                else if (player == 1) 
                { 
                    player = 2;
                    GeneratePlayerMove('X', input);
                }

                SetField();

                #region
                // CHECK WINNING CONDITION
                char[] playerChars = { 'X', 'O' };

                foreach(char c in playerChars)
                {
                    if (
                        ((playField[0,0] == c) && (playField[0,1] == c) && (playField[0, 2] == c))
                        || ((playField[1,0] == c) && (playField[1,1] == c) && (playField[1, 2] == c))
                        || ((playField[2,0] == c) && (playField[2,1] == c) && (playField[2, 2] == c))
                        || ((playField[0, 0] == c) && (playField[1, 0] == c) && (playField[2, 0] == c))
                        || ((playField[0, 1] == c) && (playField[1, 1] == c) && (playField[2, 1] == c))
                        || ((playField[0, 2] == c) && (playField[1, 2] == c) && (playField[2, 2] == c))
                        || ((playField[0, 0] == c) && (playField[1, 1] == c) && (playField[2, 2] == c))
                        || ((playField[0, 2] == c) && (playField[1, 1] == c) && (playField[2, 0] == c))
                        )
                    {
                        if (c == 'X') Console.WriteLine("PLAYER 2 HAS WON!");
                        else Console.WriteLine("PLAYER 1 HAS WON!");

                        Console.WriteLine("PRESS ANY KEY TO RESET THE GAME...");
                        Console.ReadKey();
                        ResetField();
                        break;

                    } else if (turns == 10)
                    {
                        Console.WriteLine("MATCH DRAWN!");
                        Console.WriteLine("PRESS ANY KEY TO RESET THE GAME...");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }
                #endregion

                do
                {
                    Console.Write("\n[PLAYER {0}] CHOOSE YOUR FIELD: ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("[ERROR] PLEASE ENTER A NUMBER!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1')) correctInput = true;
                    else if ((input == 2) && (playField[0,1] == '2')) correctInput = true;
                    else if ((input == 3) && (playField[0,2] == '3')) correctInput = true;
                    else if ((input == 4) && (playField[1,0] == '4')) correctInput = true;
                    else if ((input == 5) && (playField[1,1] == '5')) correctInput = true;
                    else if ((input == 6) && (playField[1,2] == '6')) correctInput = true;
                    else if ((input == 7) && (playField[2,0] == '7')) correctInput = true;
                    else if ((input == 8) && (playField[2,1] == '8')) correctInput = true;
                    else if ((input == 9) && (playField[2,2] == '9')) correctInput = true;
                    else
                    {
                        Console.WriteLine("[ERROR] INCORRECT FIELD! PLEASE ENTER ANOTHER FIELD!");
                        correctInput = false;
                    }

                } while (!correctInput);

            } while (true);
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void ResetField()
        {
             char[,] playFieldInit =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'},
            };

            playField = playFieldInit;
            SetField();
            turns = 0;
        }

        public static void GeneratePlayerMove(char playerSign, int input)
        {
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }
        }
    }
}
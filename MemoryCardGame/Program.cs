using System;

namespace MemoryCardGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO YOUR DEATH MATCH IN MEMORRRRYYY CARDSSSS!!//********\\");
            int B = CreateBoard();
            char[,] Arr = new char[B, B];
            int Cards = B * B;
            int cards2 = Cards / 2;
            Random rnd = new Random();
            Random rnd2 = new Random();
            Console.WriteLine(" what is your name?!");
            string p1 = Console.ReadLine();
            Console.WriteLine("welcome " + p1 + "! and whats your second player name?");
            string p2 = Console.ReadLine();
            Console.WriteLine("welcome " + p1 + "! and " + p2 + " lets start THE CARD GAME DEATTHHH MATCHHH~~");
            string turn = p1;
            string turn2 = p2;
            int points_p1 = 0;
            int points_p2 = 0;
            for (int i = 1; i <= cards2; i++)
            {
                char words = (char)rnd2.Next(65, 90);
                int Counter = 0;
                while (Counter != 2)
                {
                    int Line = rnd.Next(0, Arr.GetLength(0));
                    int Paragraph = rnd.Next(0, Arr.GetLength(1));
                    if (Arr[Line, Paragraph] == '\0')
                    {
                        Arr[Line, Paragraph] = words;
                        Counter++;
                    }

                }
            }

            int Row, Page, Row2, Page2;
            int counter2;
            int points = 0;
            while (points < cards2)
            {
                PrintBoard(Arr);
                do
                {
                    Console.WriteLine(turn + " please insert your first Row:");
                    Row = int.Parse(Console.ReadLine());
                    Console.WriteLine(turn + " please insert your first Page:");
                    Page = int.Parse(Console.ReadLine());
                    counter2 = 0;
                    if (Row <= 0 || Page <= 0 || Row > Arr.GetLength(0) || Page > Arr.GetLength(1))
                    {
                        Console.WriteLine("not in ranged try again");
                        counter2++;
                    }
                    else if (Arr[Row - 1, Page - 1] == (char)48)
                    {
                        Console.WriteLine("you already you found those cards");
                        counter2++;
                    }
                } while (counter2 > 0);
                PrintBoard2(Arr,Row -1 , Page -1);
                Console.WriteLine("Card 1:" + Arr[Row - 1, Page - 1]);
                do
                {
                    counter2 = 0;
                    Console.WriteLine(turn + " please insert your second Row:");
                    Row2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(turn + " please insert your second Page");
                    Page2 = int.Parse(Console.ReadLine());
                    if (Row2 <= 0 || Page2 <= 0 || Row2 > Arr.GetLength(0) || Page2 > Arr.GetLength(1))
                    {
                        Console.WriteLine("not in ranged try again");
                        counter2++;
                    }
                    else if (Arr[Row2 - 1, Page2 - 1] == (char)48)
                    {
                        Console.WriteLine("you already you found those cards");
                        counter2++;
                    }
                    else if (Row2 == Row && Page2 == Page)
                    {
                        Console.WriteLine("this card is already taken");
                        counter2++;
                    }

                } while (counter2 > 0);
                PrintBoard3(Arr, Row - 1, Page - 1, Row2 -1 , Page2 -1);
                Console.WriteLine("card 2:" + Arr[Row2 - 1, Page2 - 1]);

                if (Arr[Row - 1, Page - 1] == Arr[Row2 - 1, Page2 - 1])
                {
                    Console.WriteLine("DOMINATING!");
                    Arr[Row - 1, Page - 1] = (char)48;
                    Arr[Row2 - 1, Page2 - 1] = (char)48;
                    if (turn == p1)
                    {
                        points_p1++;

                    }
                    else
                    {
                        points_p2++;
                    }
                    points++;
                    continue;

                }
                else
                {
                    Console.WriteLine("WRONGGGG try again!");
                    if (turn == p1)
                    {
                        turn = p2;
                        turn2 = p1;
                    }
                    else
                    {
                        turn = p1;
                        turn2 = p2;
                    }

                }
                continue;
            }
            Console.WriteLine(turn + " CoNgRaTuLaTiOnS!!! YoU WiN!~ " + turn2 + " YoU LoSe!~~~@@XXX@@~~~");
            Console.WriteLine("the result of ThiS DEATH MATCH!:" + p1 + ":" + points_p1 + " "+ p2 + ":" + points_p2);


        }
        public static int CreateBoard()
        {
            Console.WriteLine("Enter the size of cards you wish to play;2x2,4x4,6x6,8x8?\n >> ");
            int Board = int.Parse(Console.ReadLine());
            if (Board > 0 && Board <= 8 && Board % 2 == 0)
            {
                return Board;
            }
            else
            {
                return CreateBoard();
            }
        }
        public static void PrintBoard(char[,] BoardShape)
        {
            for (int i = 0; i < BoardShape.GetLength(0); i++)
            {
                for (int j = 0; j < BoardShape.GetLength(1); j++)
                {
                    if (BoardShape[i, j] == (char) 48)
                    {
                        Console.Write(BoardShape[i, j] + "\t");
                    }
                    else
                    {
                        Console.Write("*" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void PrintBoard2(char[,] BoardShape2, int row, int page)
        {
            for (int i = 0; i < BoardShape2.GetLength(0); i++)
            {
                for (int j = 0; j < BoardShape2.GetLength(1); j++)
                {
                    if (BoardShape2[i, j] == '\0')
                    {
                        Console.Write("0" + "\t");
                    }
                    else if (i == row && j == page)
                    {
                        Console.Write(BoardShape2[row,page] + "\t");
                    }
                    else
                    {
                        Console.Write("*" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void PrintBoard3(char[,] BoardShape3, int row1, int page1, int row2, int page2)
        {
            for (int i = 0; i < BoardShape3.GetLength(0); i++)
            {
                for (int j = 0; j < BoardShape3.GetLength(1); j++)
                {
                    if (BoardShape3[i, j] == '\0')
                    {
                        Console.Write("0" + "\t");
                    }
                    else if (i == row1 && j == page1)
                    {
                        Console.Write(BoardShape3[row1,page1] + "\t");
                    }
                    else if (i == row2 && j == page2)
                    {
                        Console.Write(BoardShape3[row2, page2] + "\t");
                    }
                    else
                    {
                        Console.Write("*" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

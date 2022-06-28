using System;
namespace Chess
{
    public partial class Form1
    {
        public class Queen : piece
        {
            public Queen(string a, string c, string d, string e)
            {
                piece_name = a;
                side = c;
                piece_background_colour = d;
                position = e;
                occupied_for_white = new bool[8, 8];
                occupied_for_black = new bool[8, 8];

            }
            public override void valid_moves(string side, string position, bool[,] for_black, bool[,] for_white)
            {
                if (status != "out")
                {

                    valid_move = new string[28];
                    int x;
                    if (position == "g_4")
                        x = position[2] - 49;
                    else
                        x = position[1] - 49;
                    int y = position[0] - 97;
                    char ch = position[0];
                    int count = 0, count1 = 0, count2 = 0;
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 8; ++j)
                        {
                            occupied_for_black[i, j] = for_black[i, j];
                            occupied_for_white[i, j] = for_white[i, j];
                        }

                    }
                    if (side == "black")
                    {
                        if (position[0] == 'a')
                        {

                            for (int i = 1; i <= 7; ++i)             //rightwards
                            {
                                if (!occupied_for_black[x, i + y])
                                {
                                    if (occupied_for_white[x, i + y])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)      //upwards
                            {
                                if (!occupied_for_black[x + i, y])
                                {
                                    if (occupied_for_white[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }

                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                    count1++;

                                }
                                else
                                    break;
                            }
                            count = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_black[x - i, y])
                                {
                                    if (occupied_for_white[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count++;
                                        break;
                                    }

                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                    count++;

                                }
                                else
                                    break;
                            }
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7; ++i)            //top-right
                                {
                                    if (!occupied_for_black[x + i, y + i])
                                    {
                                        if (occupied_for_white[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7; ++i)        //down-right
                                {
                                    if (!occupied_for_black[x - i, i + y])
                                    {
                                        if (occupied_for_white[x - i, i + y])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                            else
                            {
                                count1 = count;
                                for (int i = 1; i <= 7 - x; ++i)
                                {
                                    if (!occupied_for_black[x + i, y + i])      //top-right
                                    {
                                        if (occupied_for_white[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;
                                }
                                for (int i = 1; i <= 7; ++i)
                                {
                                    if (!occupied_for_black[Math.Abs(x - i), i + y])      //down-right
                                    {
                                        if (occupied_for_white[Math.Abs(x - i), i + y])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                        }
                        else if (position[0] == 'h')
                        {
                            for (int i = 1; i <= 7; ++i)        //leftwards
                            {
                                if (!occupied_for_black[x, y - i])
                                {
                                    if (occupied_for_white[x, y - i])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch - i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch - i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)            //upwards
                            {
                                if (!occupied_for_black[x + i, y])
                                {
                                    if (occupied_for_white[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }
                                    count1++;
                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);

                                }
                                else
                                    break;
                            }
                            count2 = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_black[x - i, y])
                                {
                                    if (occupied_for_white[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count2++;
                                        break;
                                    }

                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                    count2++;

                                }
                                else
                                    break;
                            }
                            count = count2;
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7 - x; ++i)        //top-left
                                {
                                    if (!occupied_for_black[x + i, y - i])
                                    {
                                        if (occupied_for_white[x + i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7; ++i)        //down-left
                                {
                                    if (!occupied_for_black[x - i, y - i])
                                    {
                                        if (occupied_for_white[x - i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                            else
                            {
                                for (int i = 1; i <= 7 - x; ++i)
                                {
                                    if (!occupied_for_black[x + i, y - i])
                                    {
                                        if (occupied_for_white[x + i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count++;
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count++;
                                    }
                                    else
                                        break;
                                }
                                for (int i = 1; i <= 7; ++i)
                                {
                                    if (!occupied_for_black[Math.Abs(x - i), Math.Abs(y - i)])
                                    {
                                        if (occupied_for_white[Math.Abs(x - i), Math.Abs(y - i)])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 1; i <= 7 - y; ++i)             //rightwards
                            {
                                if (!occupied_for_black[x, i + y])
                                {
                                    if (occupied_for_white[x, i + y])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)      //upwards
                            {
                                if (!occupied_for_black[x + i, y])
                                {
                                    if (occupied_for_white[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }

                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                    count1++;

                                }
                                else
                                    break;
                            }
                            count2 = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_black[x - i, y])
                                {
                                    if (occupied_for_white[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count2++;
                                        break;
                                    }
                                    count2++;
                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);

                                }
                                else
                                    break;
                            }
                            count = count2;
                            for (int i = 1; i <= y; ++i)        //leftwards
                            {
                                if (!occupied_for_black[x, y - i])
                                {
                                    if (occupied_for_white[x, y - i])
                                    {
                                        count++;
                                        valid_move[count2 + i - 1] = (char)(ch - i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[count2 + i - 1] = (char)(ch - i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_black[x + i, y + i])
                                    {
                                        if (occupied_for_white[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;

                                }
                                count2 = count1;
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_black[x + i, y - i])
                                    {
                                        if (occupied_for_white[x + i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count2++;
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count2++;
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_black[x - i, i + y])
                                    {
                                        if (occupied_for_white[x - i, i + y])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            count1++;
                                            break;
                                        }
                                        count1++;
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else

                                        break;
                                }
                                count2 = count1;
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_black[x - i, y - i])
                                    {
                                        if (occupied_for_white[x - i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            count2++;

                                            break;
                                        }
                                        count2++;
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                            else
                            {
                                for (int i = 1; i <= 7 - y && i <= 7 - x; ++i)
                                {
                                    if (!occupied_for_black[x + i, y + i ])
                                    {
                                        if (occupied_for_white[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;

                                }
                                count2 = count1;
                                for (int i = 1; i <= y && i <= 7-x; ++i)
                                {
                                    if (!occupied_for_black[x + i, y - i])
                                    {
                                        if (occupied_for_white[x + i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count2++;
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count2++;
                                    }
                                    else
                                        break;

                                }
                                count = count2;
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_black[Math.Abs(x - i), i + y])
                                    {
                                        if (occupied_for_white[Math.Abs(x - i), i + y])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            count++;
                                            break;
                                        }
                                        count++;
                                        valid_move[count2 + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else

                                        break;
                                }
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_black[Math.Abs(x - i), Math.Abs(y - i)])
                                    {
                                        if (occupied_for_white[Math.Abs(x - i), Math.Abs(y - i)])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }

                                        valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                        }
                    }
                    if (side == "white")
                    {
                        if (position[0] == 'a')
                        {

                            for (int i = 1; i <= 7; ++i)             //rightwards
                            {
                                if (!occupied_for_white[x, i + y])
                                {
                                    if (occupied_for_black[x, i + y])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)      //upwards
                            {
                                if (!occupied_for_white[x + i, y])
                                {
                                    if (occupied_for_black[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }

                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                    count1++;

                                }
                                else
                                    break;
                            }
                            count = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_white[x - i, y])
                                {
                                    if (occupied_for_black[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count++;
                                        break;
                                    }

                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                    count++;

                                }
                                else
                                    break;
                            }
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7; ++i)            //top-right
                                {
                                    if (!occupied_for_white[x + i, y + i])
                                    {
                                        if (occupied_for_black[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7; ++i)        //down-right
                                {
                                    if (!occupied_for_white[x - i, i + y])
                                    {
                                        if (occupied_for_black[x - i, i + y])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                            else
                            {
                                count1 = count;
                                for (int i = 1; i <= 7 - x; ++i)
                                {
                                    if (!occupied_for_white[x + i, y + i])      //top-right
                                    {
                                        if (occupied_for_black[x + i, y + i])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;
                                }
                                for (int i = 1; i <= 7; ++i)
                                {
                                    if (!occupied_for_white[Math.Abs(x - i), i + y])      //down-right
                                    {
                                        if (occupied_for_black[Math.Abs(x - i), i + y])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                        }
                        else if (position[0] == 'h')
                        {
                            for (int i = 1; i <= 7; ++i)        //leftwards
                            {
                                if (!occupied_for_white[x, y - i])
                                {
                                    if (occupied_for_black[x, y - i])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch - i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch - i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)            //upwards
                            {
                                if (!occupied_for_white[x + i, y])
                                {
                                    if (occupied_for_black[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }
                                    count1++;
                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);

                                }
                                else
                                    break;
                            }
                            count2 = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_white[x - i, y])
                                {
                                    if (occupied_for_black[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count2++;
                                        break;
                                    }

                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                    count2++;

                                }
                                else
                                    break;
                            }
                            count = count2;
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7 - x; ++i)        //top-left
                                {
                                    if (!occupied_for_white[x + i, y - i])
                                    {
                                        if (occupied_for_black[x + i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7; ++i)        //down-left
                                {
                                    if (!occupied_for_white[x - i, y - i])
                                    {
                                        if (occupied_for_black[x - i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;


                                }
                            }
                            else
                            {
                                for (int i = 1; i <= 7 - x - 1; ++i)
                                {
                                    if (!occupied_for_white[x + i, y - i])  //
                                    {
                                        if (occupied_for_black[x + i, y - i])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count++;
                                            break;
                                        }
                                        valid_move[count2 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count++;
                                    }
                                    else
                                        break;
                                }
                                for (int i = 1; i <= 7; ++i)
                                {
                                    if (!occupied_for_white[Math.Abs(x - i), Math.Abs(y - i)])
                                    {
                                        if (occupied_for_black[Math.Abs(x - i), Math.Abs(y - i)])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 1; i <= 7 - y; ++i)             //rightwards
                            {
                                if (!occupied_for_white[x, i + y])
                                {
                                    if (occupied_for_black[x, i + y])
                                    {
                                        count++;
                                        valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[i - 1] = (char)(ch + i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            for (int i = 1; i <= 7 - x; ++i)      //upwards
                            {
                                if (!occupied_for_white[x + i, y])
                                {
                                    if (occupied_for_black[x + i, y])
                                    {

                                        valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                        count1++;
                                        break;
                                    }

                                    valid_move[count + i - 1] = (char)(ch) + "" + (x + i + 1);
                                    count1++;

                                }
                                else
                                    break;
                            }
                            count2 = count1;
                            for (int i = 1; i <= x; ++i)      //downwards
                            {
                                if (!occupied_for_white[x - i, y])
                                {
                                    if (occupied_for_black[x - i, y])
                                    {

                                        valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);
                                        count2++;
                                        break;
                                    }
                                    count2++;
                                    valid_move[count1 + i - 1] = (char)(ch) + "" + (x - i + 1);

                                }
                                else
                                    break;
                            }
                            count = count2;
                            for (int i = 1; i <= y; ++i)        //leftwards
                            {
                                if (!occupied_for_white[x, y - i])
                                {
                                    if (occupied_for_black[x, y - i])
                                    {
                                        count++;
                                        valid_move[count2 + i - 1] = (char)(ch - i) + "" + (x + 1);
                                        break;
                                    }
                                    count++;
                                    valid_move[count2 + i - 1] = (char)(ch - i) + "" + (x + 1);

                                }
                                else
                                    break;
                            }
                            count1 = count;
                            if (position[1] == '1')
                            {
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_white[x + i, y + i - 1])
                                    {
                                        if (occupied_for_black[x + i, y + i - 1])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;

                                }
                                count2 = count1;
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_white[x + i, y - i])
                                    {
                                        if (occupied_for_black[x + i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count2++;
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count2++;
                                    }
                                    else
                                        break;

                                }
                            }
                            else if (position[1] == '8')
                            {
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_white[x - i, i + y])
                                    {
                                        if (occupied_for_black[x - i, i + y])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            count1++;
                                            break;
                                        }
                                        count1++;
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else

                                        break;
                                }
                                count2 = count1;
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_white[x - i, y - i])
                                    {
                                        if (occupied_for_black[x - i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            count2++;

                                            break;
                                        }
                                        count2++;
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;
                                }

                            }
                            else
                            {
                                for (int i = 1; i <= 7 - x && i <= 7 - y; ++i)// FIX
                                {
                                    if (!occupied_for_white[x + i, y + i - 1])
                                    {
                                        if (occupied_for_black[x + i, y + i - 1])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                            count1++;
                                            break;
                                        }
                                        valid_move[count + i - 1] = (char)(position[0] + i) + "" + (x + i + 1);
                                        count1++;
                                    }
                                    else
                                        break;

                                }
                                count2 = count1;
                                for (int i = 1; i <= y && i <= (7 - x); ++i)
                                {
                                    if (!occupied_for_white[x + i, y - i])
                                    {
                                        if (occupied_for_black[x + i, y - i])
                                        {
                                            valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                            count2++;
                                            break;
                                        }
                                        valid_move[count1 + i - 1] = (char)(position[0] - i) + "" + (x + i + 1);
                                        count2++;
                                    }
                                    else
                                        break;

                                }
                                count = count2;
                                for (int i = 1; i <= 7 - y; ++i)
                                {
                                    if (!occupied_for_white[x - i, i + y])
                                    {
                                        if (occupied_for_black[x - i, i + y])
                                        {
                                            valid_move[count2 + i - 1] = (char)(position[0] + i) + "" + (x + 1 - i);
                                            count++;
                                            break;
                                        }
                                        count++;
                                        valid_move[count2 + i - 1] = (char)(position[0] + i) + "" + (x - i + 1);
                                    }
                                    else

                                        break;
                                }
                                for (int i = 1; i <= y; ++i)
                                {
                                    if (!occupied_for_white[Math.Abs(x - i), Math.Abs(y - i)])
                                    {
                                        if (occupied_for_black[Math.Abs(x - i), Math.Abs(y - i)])
                                        {
                                            valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x + 1 - i);
                                            break;
                                        }

                                        valid_move[count + i - 1] = (char)(position[0] - i) + "" + (x - i + 1);
                                    }
                                    else
                                        break;

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

using System;

namespace Chess
{
    public partial class Form1
    {
        public class Horse : piece
        {
            public Horse(string a, string c, string d, string e)
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


                    valid_move = new string[8];
                    int x;
                    if (position == "g_4")
                        x = position[2] - 48;
                    else
                        x = position[1] - 48;
                    char ch = position[0];
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 8; ++j)
                        {
                            occupied_for_black[i, j] = for_black[i, j];
                            occupied_for_white[i, j] = for_white[i, j];
                        }

                    }
                    if (side == "white")
                    {
                        if (position[0] == 'a')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_white[1, 2] == false)
                                        valid_move[0] = "c2";
                                    if (occupied_for_white[2, 1] == false)
                                        valid_move[1] = "b3";
                                }
                                else
                                {
                                    if (occupied_for_white[6, 2] == false)
                                        valid_move[0] = "c7";
                                    if (occupied_for_white[5, 1] == false)
                                        valid_move[1] = "b6";
                                }

                            }
                            else if (position[1] == '7' || position[1] == '2')
                            {

                                if (position[1] == '7')
                                {
                                    if (occupied_for_white[7, 2] == false)
                                        valid_move[0] = "c8";
                                    if (occupied_for_white[4, 1] == false)
                                        valid_move[1] = "b5";
                                    if (occupied_for_white[5, 2] == false)
                                        valid_move[2] = "c6";
                                }
                                else
                                {
                                    if (occupied_for_white[0, 2] == false)
                                        valid_move[0] = "c1";

                                    if (occupied_for_white[3, 1] == false)
                                        valid_move[1] = "b4";

                                    if (occupied_for_white[2, 2] == false)
                                        valid_move[2] = "c3";
                                }

                            }
                            else
                            {


                                if (occupied_for_white[x + 1, 1] == false)
                                    valid_move[0] = "b" + (x + 2);

                                if (occupied_for_white[x - 3, 1] == false)
                                    valid_move[1] = "b" + (x - 2);

                                if (occupied_for_white[x - 2, 2] == false)
                                    valid_move[2] = "c" + (x - 1);

                                if (occupied_for_white[x, 2] == false)
                                    valid_move[3] = "c" + (x + 1);

                            }

                        }
                        if (position[0] == 'h')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_white[1, 5] == false)
                                        valid_move[0] = "f2";
                                    if (occupied_for_white[2, 6] == false)
                                        valid_move[1] = "g3";
                                }
                                else
                                {
                                    if (occupied_for_white[6, 5] == false)
                                        valid_move[0] = "f7";
                                    if (occupied_for_white[5, 6] == false)
                                        valid_move[1] = "g6";
                                }

                            }
                            else if (position[1] == '7' || position[1] == '2')
                            {

                                if (position[1] == '7')
                                {
                                    if (occupied_for_white[7, 5] == false)
                                        valid_move[0] = "f8";
                                    if (occupied_for_white[4, 6] == false)
                                        valid_move[1] = "g5";
                                    if (occupied_for_white[5, 5] == false)
                                        valid_move[2] = "f6";
                                }
                                else
                                {
                                    if (occupied_for_white[0, 5] == false)
                                        valid_move[0] = "f1";
                                    if (occupied_for_white[3, 6] == false)
                                        valid_move[1] = "g4";
                                    if (occupied_for_white[2, 5] == false)
                                        valid_move[2] = "f3";
                                }

                            }
                            else
                            {


                                if (occupied_for_white[x + 1, 6] == false)
                                    valid_move[0] = "g" + (x + 2);

                                if (occupied_for_white[x - 3, 6] == false)
                                    valid_move[1] = "g" + (x - 2);

                                if (occupied_for_white[x - 2, 5] == false)
                                    valid_move[2] = "f" + (x - 1);

                                if (occupied_for_white[x, 5] == false)
                                    valid_move[3] = "f" + (x + 1);

                            }
                        }
                        if (position[0] == 'b')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_white[1, 3] == false)
                                        valid_move[0] = "d2";

                                    if (occupied_for_white[2, 2] == false)
                                        valid_move[1] = "c3";

                                    if (occupied_for_white[2, 0] == false)
                                        valid_move[2] = "a3";
                                }
                                else
                                {
                                    if (occupied_for_white[6, 3] == false)
                                        valid_move[0] = "d7";

                                    if (occupied_for_white[5, 2] == false)
                                        valid_move[1] = "c6";
                                    if (occupied_for_white[5, 0] == false)
                                        valid_move[2] = "a6";
                                }

                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_white[0, 3] == false)
                                        valid_move[0] = "d1";

                                    if (occupied_for_white[2, 3] == false)
                                        valid_move[1] = "d3";

                                    if (occupied_for_white[3, 0] == false)
                                        valid_move[2] = "a4";

                                    if (occupied_for_white[3, 2] == false)
                                        valid_move[3] = "c4";
                                }
                                else
                                {
                                    if (occupied_for_white[5, 3] == false)
                                        valid_move[0] = "d6";

                                    if (occupied_for_white[7, 3] == false)
                                        valid_move[1] = "d8";

                                    if (occupied_for_white[4, 0] == false)
                                        valid_move[2] = "a5";

                                    if (occupied_for_white[4, 2] == false)
                                        valid_move[3] = "c5";
                                }
                            }
                            else
                            {



                                if (occupied_for_white[x - 3, 0] == false)
                                    valid_move[0] = "a" + (x - 2);

                                if (occupied_for_white[x + 1, 0] == false)
                                    valid_move[1] = "a" + (x + 2);

                                if (occupied_for_white[x - 3, 2] == false)
                                    valid_move[2] = "c" + (x - 2);

                                if (occupied_for_white[x + 1, 2] == false)
                                    valid_move[3] = "c" + (x + 2);

                                if (occupied_for_white[x - 2, 3] == false)
                                    valid_move[4] = "d" + (x - 1);

                                if (occupied_for_white[x, 3] == false)
                                    valid_move[5] = "d" + (x + 1);
                            }
                        }
                        if (position[0] == 'g')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_white[1, 4] == false)
                                        valid_move[0] = "e2";

                                    if (occupied_for_white[2, 7] == false)
                                        valid_move[1] = "h3";

                                    if (occupied_for_white[2, 5] == false)
                                        valid_move[2] = "f3";
                                }
                                else
                                {
                                    if (occupied_for_white[6, 4] == false)
                                        valid_move[0] = "e7";

                                    if (occupied_for_white[5, 7] == false)
                                        valid_move[1] = "h6";

                                    if (occupied_for_white[5, 5] == false)
                                        valid_move[2] = "f6";
                                }

                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_white[0, 4] == false)
                                        valid_move[0] = "e1";

                                    if (occupied_for_white[2, 4] == false)
                                        valid_move[1] = "e3";

                                    if (occupied_for_white[3, 5] == false)
                                        valid_move[2] = "f4";

                                    if (occupied_for_white[3, 7] == false)
                                        valid_move[3] = "h4";
                                }
                                else
                                {
                                    if (occupied_for_white[5, 4] == false)
                                        valid_move[0] = "e6";

                                    if (occupied_for_white[7, 4] == false)
                                        valid_move[1] = "e8";

                                    if (occupied_for_white[4, 5] == false)
                                        valid_move[2] = "f5";

                                    if (occupied_for_white[4, 7] == false)
                                        valid_move[3] = "h5";
                                }
                            }
                            else
                            {


                                if (occupied_for_white[x - 3, 5] == false)
                                    valid_move[0] = "f" + (x - 2);

                                if (occupied_for_white[x + 1, 5] == false)
                                    valid_move[1] = "f" + (x + 2);

                                if (occupied_for_white[x - 3, 7] == false)
                                    valid_move[2] = "h" + (x - 2);

                                if (occupied_for_white[x + 1, 7] == false)
                                    valid_move[3] = "h" + (x + 2);

                                if (occupied_for_white[x - 2, 4] == false)
                                    valid_move[4] = "e" + (x - 1);

                                if (occupied_for_white[x, 4] == false)
                                    valid_move[5] = "e" + (x + 1);
                            }
                        }
                        if (position[0] == 'c' || position[0] == 'd' || position[0] == 'e' || position[0] == 'f')
                        {


                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_white[x + 1, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x + 2));

                                    if (occupied_for_white[x + 1, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x + 2));

                                    if (occupied_for_white[x, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_white[x, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x + 1));
                                }
                                else
                                {
                                    if (occupied_for_white[x - 3, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x - 2));

                                    if (occupied_for_white[x - 3, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x - 2));

                                    if (occupied_for_white[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_white[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x - 1));
                                }
                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_white[x + 1, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x + 2));

                                    if (occupied_for_white[x + 1, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x + 2));

                                    if (occupied_for_white[x, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_white[x, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x + 1));

                                    if (occupied_for_white[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[4] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_white[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[5] = ((ch - 2) + "" + (x - 1));
                                }
                                else
                                {
                                    if (occupied_for_white[x - 3, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x - 2));

                                    if (occupied_for_white[x - 3, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x - 2));

                                    if (occupied_for_white[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_white[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x - 1));

                                    if (occupied_for_white[x, (int)ch - 47 - 48] == false)
                                        valid_move[4] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_white[x, (int)ch - 51 - 48] == false)
                                        valid_move[5] = ((ch - 2) + "" + (x + 1));
                                }

                            }
                            else
                            {
                                if (occupied_for_white[x + 1, (int)ch - 48 - 48] == false)
                                    valid_move[0] = (char)(ch + 1) + "" + (x + 2);

                                if (occupied_for_white[x - 3, (int)ch - 48 - 48] == false)
                                    valid_move[1] = (char)(ch + 1) + "" + (x - 2);

                                if (occupied_for_white[x, (int)ch - 47 - 48] == false)
                                    valid_move[2] = (char)(ch + 2) + "" + (x + 1);

                                if (occupied_for_white[x - 2, (int)ch - 47 - 48] == false)
                                    valid_move[3] = (char)(ch + 2) + "" + (x - 1);

                                if (occupied_for_white[x + 1, (int)ch - 50 - 48] == false)
                                    valid_move[4] = (char)(ch - 1) + "" + (x + 2);

                                if (occupied_for_white[x, (int)ch - 51 - 48] == false)
                                    valid_move[5] = (char)(ch - 2) + "" + (x + 1);

                                if (occupied_for_white[x - 3, (int)ch - 50 - 48] == false)
                                    valid_move[6] = (char)(ch - 1) + "" + (x - 2);

                                if (occupied_for_white[x - 2, (int)ch - 51 - 48] == false)
                                    valid_move[7] = (char)(ch - 2) + "" + (x - 1);
                            }
                        }
                    }
                    if(side == "black")
                    {
                        if (position[0] == 'a')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_black[1, 2] == false)
                                        valid_move[0] = "c2";
                                    if (occupied_for_black[2, 1] == false)
                                        valid_move[1] = "b3";
                                }
                                else
                                {
                                    if (occupied_for_black[6, 2] == false)
                                        valid_move[0] = "c7";
                                    if (occupied_for_black[5, 1] == false)
                                        valid_move[1] = "b6";
                                }

                            }
                            else if (position[1] == '7' || position[1] == '2')
                            {

                                if (position[1] == '7')
                                {
                                    if (occupied_for_black[7, 2] == false)
                                        valid_move[0] = "c8";
                                    if (occupied_for_black[4, 1] == false)
                                        valid_move[1] = "b5";
                                    if (occupied_for_black[5, 2] == false)
                                        valid_move[2] = "c6";
                                }
                                else
                                {
                                    if (occupied_for_black[0, 2] == false)
                                        valid_move[0] = "c1";

                                    if (occupied_for_black[3, 1] == false)
                                        valid_move[1] = "b4";

                                    if (occupied_for_black[2, 2] == false)
                                        valid_move[2] = "c3";
                                }

                            }
                            else
                            {


                                if (occupied_for_black[x + 1, 1] == false)
                                    valid_move[0] = "b" + (x + 2);

                                if (occupied_for_black[x - 3, 1] == false)
                                    valid_move[1] = "b" + (x - 2);

                                if (occupied_for_black[x - 2, 2] == false)
                                    valid_move[2] = "c" + (x - 1);

                                if (occupied_for_black[x, 2] == false)
                                    valid_move[3] = "c" + (x + 1);

                            }

                        }
                        if (position[0] == 'h')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_black[1, 5] == false)
                                        valid_move[0] = "f2";
                                    if (occupied_for_black[2, 6] == false)
                                        valid_move[1] = "g3";
                                }
                                else
                                {
                                    if (occupied_for_black[6, 5] == false)
                                        valid_move[0] = "f7";
                                    if (occupied_for_black[5, 6] == false)
                                        valid_move[1] = "g6";
                                }

                            }
                            else if (position[1] == '7' || position[1] == '2')
                            {

                                if (position[1] == '7')
                                {
                                    if (occupied_for_black[7, 5] == false)
                                        valid_move[0] = "f8";
                                    if (occupied_for_black[4, 6] == false)
                                        valid_move[1] = "g5";
                                    if (occupied_for_black[5, 5] == false)
                                        valid_move[2] = "f6";
                                }
                                else
                                {
                                    if (occupied_for_black[0, 5] == false)
                                        valid_move[0] = "f1";
                                    if (occupied_for_black[3, 6] == false)
                                        valid_move[1] = "g4";
                                    if (occupied_for_black[2, 5] == false)
                                        valid_move[2] = "f3";
                                }

                            }
                            else
                            {


                                if (occupied_for_black[x + 1, 6] == false)
                                    valid_move[0] = "g" + (x + 2);

                                if (occupied_for_black[x - 3, 6] == false)
                                    valid_move[1] = "g" + (x - 2);

                                if (occupied_for_black[x - 2, 5] == false)
                                    valid_move[2] = "f" + (x - 1);

                                if (occupied_for_black[x, 5] == false)
                                    valid_move[3] = "f" + (x + 1);

                            }
                        }
                        if (position[0] == 'b')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_black[1, 3] == false)
                                        valid_move[0] = "d2";

                                    if (occupied_for_black[2, 2] == false)
                                        valid_move[1] = "c3";

                                    if (occupied_for_black[2, 0] == false)
                                        valid_move[2] = "a3";
                                }
                                else
                                {
                                    if (occupied_for_black[6, 3] == false)
                                        valid_move[0] = "d7";

                                    if (occupied_for_black[5, 2] == false)
                                        valid_move[1] = "c6";

                                    if (occupied_for_black[5, 0] == false)
                                        valid_move[2] = "a6";
                                }

                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_black[0, 3] == false)
                                        valid_move[0] = "d1";

                                    if (occupied_for_black[2, 3] == false)
                                        valid_move[1] = "d3";

                                    if (occupied_for_black[3, 0] == false)
                                        valid_move[2] = "a4";

                                    if (occupied_for_black[3, 2] == false)
                                        valid_move[3] = "c4";
                                }
                                else
                                {
                                    if (occupied_for_black[5, 3] == false)
                                        valid_move[0] = "d6";

                                    if (occupied_for_black[7, 3] == false)
                                        valid_move[1] = "d8";

                                    if (occupied_for_black[4, 0] == false)
                                        valid_move[2] = "a5";

                                    if (occupied_for_black[4, 2] == false)
                                        valid_move[3] = "c5";
                                }
                            }
                            else
                            {



                                if (occupied_for_black[x - 3, 0] == false)
                                    valid_move[0] = "a" + (x - 2);

                                if (occupied_for_black[x + 1, 0] == false)
                                    valid_move[1] = "a" + (x + 2);

                                if (occupied_for_black[x - 3, 2] == false)
                                    valid_move[2] = "c" + (x - 2);

                                if (occupied_for_black[x + 1, 2] == false)
                                    valid_move[3] = "c" + (x + 2);

                                if (occupied_for_black[x - 2, 3] == false)
                                    valid_move[4] = "d" + (x - 1);

                                if (occupied_for_black[x, 3] == false)
                                    valid_move[5] = "d" + (x + 1);
                            }
                        }
                        if (position[0] == 'g')
                        {
                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_black[1, 4] == false)
                                        valid_move[0] = "e2";

                                    if (occupied_for_black[2, 7] == false)
                                        valid_move[1] = "h3";

                                    if (occupied_for_black[2, 5] == false)
                                        valid_move[2] = "f3";
                                }
                                else
                                {
                                    if (occupied_for_black[6, 4] == false)
                                        valid_move[0] = "e7";

                                    if (occupied_for_black[5, 7] == false)
                                        valid_move[1] = "h6";

                                    if (occupied_for_black[5, 5] == false)
                                        valid_move[2] = "f6";
                                }

                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_black[0, 4] == false)
                                        valid_move[0] = "e1";

                                    if (occupied_for_black[2, 4] == false)
                                        valid_move[1] = "e3";

                                    if (occupied_for_black[3, 5] == false)
                                        valid_move[2] = "f4";

                                    if (occupied_for_black[3, 7] == false)
                                        valid_move[3] = "h4";
                                }
                                else
                                {
                                    if (occupied_for_black[5, 4] == false)
                                        valid_move[0] = "e6";

                                    if (occupied_for_black[7, 4] == false)
                                        valid_move[1] = "e8";

                                    if (occupied_for_black[4, 5] == false)
                                        valid_move[2] = "f5";

                                    if (occupied_for_black[4, 7] == false)
                                        valid_move[3] = "h5";
                                }
                            }
                            else
                            {


                                if (occupied_for_black[x - 3, 5] == false)
                                    valid_move[0] = "f" + (x - 2);

                                if (occupied_for_black[x + 1, 5] == false)
                                    valid_move[1] = "f" + (x + 2);

                                if (occupied_for_black[x - 3, 7] == false)
                                    valid_move[2] = "h" + (x - 2);

                                if (occupied_for_black[x + 1, 7] == false)
                                    valid_move[3] = "h" + (x + 2);

                                if (occupied_for_black[x - 2, 4] == false)
                                    valid_move[4] = "e" + (x - 1);

                                if (occupied_for_black[x, 4] == false)
                                    valid_move[5] = "e" + (x + 1);
                            }
                        }
                        if (position[0] == 'c' || position[0] == 'd' || position[0] == 'e' || position[0] == 'f')
                        {

                            if (position[1] == '1' || position[1] == '8')
                            {

                                if (position[1] == '1')
                                {
                                    if (occupied_for_black[x + 1, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x + 2));

                                    if (occupied_for_black[x + 1, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x + 2));

                                    if (occupied_for_black[x, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_black[x, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x + 1));
                                }
                                else
                                {
                                    if (occupied_for_black[x - 3, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x - 2));

                                    if (occupied_for_black[x - 3, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x - 2));

                                    if (occupied_for_black[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_black[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x - 1));
                                }
                            }
                            else if (position[1] == '2' || position[1] == '7')
                            {

                                if (position[1] == '2')
                                {
                                    if (occupied_for_black[x + 1, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x + 2));

                                    if (occupied_for_black[x + 1, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x + 2));

                                    if (occupied_for_black[x, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_black[x, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x + 1));

                                    if (occupied_for_black[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[4] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_black[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[5] = ((ch - 2) + "" + (x - 1));
                                }
                                else
                                {
                                    if (occupied_for_black[x - 3, (int)ch - 48 - 48] == false)
                                        valid_move[0] = ((ch + 1) + "" + (x - 2));

                                    if (occupied_for_black[x - 3, (int)ch - 50 - 48] == false)
                                        valid_move[1] = ((ch - 1) + "" + (x - 2));

                                    if (occupied_for_black[x - 2, (int)ch - 47 - 48] == false)
                                        valid_move[2] = ((ch + 2) + "" + (x - 1));

                                    if (occupied_for_black[x - 2, (int)ch - 51 - 48] == false)
                                        valid_move[3] = ((ch - 2) + "" + (x - 1));

                                    if (occupied_for_black[x, (int)ch - 47 - 48] == false)
                                        valid_move[4] = ((ch + 2) + "" + (x + 1));

                                    if (occupied_for_black[x, (int)ch - 51 - 48] == false)
                                        valid_move[5] = ((ch - 2) + "" + (x + 1));
                                }

                            }
                            else
                            {
                                if (occupied_for_black[x + 1, (int)ch - 48 - 48] == false)
                                    valid_move[0] = (char)(ch + 1) + "" + (x + 2);

                                if (occupied_for_black[x - 3, (int)ch - 48 - 48] == false)
                                    valid_move[1] = (char)(ch + 1) + "" + (x - 2);

                                if (occupied_for_black[x, (int)ch - 47 - 48] == false)
                                    valid_move[2] = (char)(ch + 2) + "" + (x + 1);

                                if (occupied_for_black[x - 2, (int)ch - 47 - 48] == false)
                                    valid_move[3] = (char)(ch + 2) + "" + (x - 1);

                                if (occupied_for_black[x + 1, (int)ch - 50 - 48] == false)
                                    valid_move[4] = (char)(ch - 1) + "" + (x + 2);

                                if (occupied_for_black[x, (int)ch - 51 - 48] == false)
                                    valid_move[5] = (char)(ch - 2) + "" + (x + 1);

                                if (occupied_for_black[x - 3, (int)ch - 50 - 48] == false)
                                    valid_move[6] = (char)(ch - 1) + "" + (x - 2);

                                if (occupied_for_black[x - 2, (int)ch - 51 - 48] == false)
                                    valid_move[7] = (char)(ch - 2) + "" + (x - 1);
                            }
                        }
                    }
                }

            }
        }
    }
}

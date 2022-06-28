using System;

namespace Chess
{
    public partial class Form1
    {
        public class pawn : piece
        {
            public pawn(string a, string c, string d, string e)
            {
                piece_name = a;
                side = c;
                piece_background_colour = d;
                position = e;
                occupied_for_black = new bool[8, 8];
                occupied_for_white = new bool[8, 8];

            }
            public override void valid_moves(string side, string position, bool[,] for_black, bool[,] for_white)
            {
                


                    valid_move = new string[5];
                    int y = position[0] - 97;
                    int x;
                    if (position == "g_4")
                        x = position[2] - 49;
                    else
                        x = position[1] - 49;
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

                        if (position[1] == '2')
                        {
                            if (position[0] == 'a')
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                    if (!occupied_for_black[x + 2, y] && !occupied_for_white[x + 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x + 3);
                                }
                                if (occupied_for_white[x + 1, y + 1] && !occupied_for_black[x + 1, y + 1])
                                    valid_move[2] = (char)(y + 98) + "" + (x + 2);


                            }
                            else if (position[0] == 'h')
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                    if (!occupied_for_black[x + 2, y] && !occupied_for_white[x + 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x + 3);
                                }
                                if (occupied_for_white[x + 1, y - 1] && !occupied_for_black[x + 1, y - 1])
                                    valid_move[2] = (char)(y + 96) + "" + (x + 2);
                            }
                            else
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                    if (!occupied_for_black[x + 2, y] && !occupied_for_white[x + 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x + 3);
                                }
                                if (occupied_for_white[x + 1, y + 1] && !occupied_for_black[x + 1, y + 1])
                                    valid_move[2] = (char)(y + 98) + "" + (x + 2);

                                if (occupied_for_white[x + 1, y - 1] && !occupied_for_black[x + 1, y - 1])
                                    valid_move[3] = (char)(y + 96) + "" + (x + 2);
                            }

                        }
                        else if (position[1] == '8')
                        {
                            //ask user to change to a piece...
                        }
                        else
                        {
                            if (position[0] == 'a')
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                if (!occupied_for_black[x + 1, y + 1] && occupied_for_white[x + 1, y + 1])
                                    valid_move[1] = (char)(y + 98) + "" + (x + 2);
                            }
                            else if (position[0] == 'h')
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                if (!occupied_for_black[x + 1, y - 1] && occupied_for_white[x + 1, y - 1])
                                    valid_move[1] = (char)(y + 96) + "" + (x + 2);
                            }
                            else
                            {
                                if (!occupied_for_black[x + 1, y] && !occupied_for_white[x + 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x + 2);
                                if (!occupied_for_black[x + 1, y + 1] && occupied_for_white[x + 1, y + 1])
                                    valid_move[1] = (char)(y + 98) + "" + (x + 2);
                                if (!occupied_for_black[x + 1, y - 1] && occupied_for_white[x + 1, y - 1])
                                    valid_move[2] = (char)(y + 96) + "" + (x + 2);
                            }
                        }
                    }
                    if (side == "white")
                    {
                        if (position[1] == '7')
                        {
                            if (position[0] == 'a')
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                    if (!occupied_for_black[x - 2, y] && !occupied_for_white[x - 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x - 1);
                                }
                                if (!occupied_for_white[x - 1, y + 1] && occupied_for_black[x - 1, y + 1])
                                    valid_move[2] = (char)(y + 98) + "" + (x);


                            }
                            else if (position[0] == 'h')
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                    if (!occupied_for_black[x - 2, y] && !occupied_for_white[x - 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x - 1);
                                }
                                if (!occupied_for_white[x - 1, y - 1] && occupied_for_black[x - 1, y - 1])
                                    valid_move[2] = (char)(y + 96) + "" + (x);
                            }
                            else
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                {
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                    if (!occupied_for_black[x - 2, y] && !occupied_for_white[x - 2, y])
                                        valid_move[1] = (char)(y + 97) + "" + (x - 1);
                                }
                                if (!occupied_for_white[x - 1, y + 1] && occupied_for_black[x - 1, y + 1])
                                    valid_move[2] = (char)(y + 98) + "" + (x);

                                if (!occupied_for_white[x - 1, y - 1] && occupied_for_black[x - 1, y - 1])
                                    valid_move[3] = (char)(y + 96) + "" + (x);
                            }
                        }
                        else if (position[1] == '1')
                        {
                            //ask user to change to a piece...
                        }
                        else
                        {
                            if (position[0] == 'a')
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                if (occupied_for_black[x - 1, y + 1] && !occupied_for_white[x - 1, y + 1])
                                    valid_move[1] = (char)(y + 98) + "" + (x);
                            }
                            else if (position[0] == 'h')
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                if (occupied_for_black[x - 1, y - 1] && !occupied_for_white[x - 1, y - 1])
                                    valid_move[1] = (char)(y + 96) + "" + (x);
                            }
                            else
                            {
                                if (!occupied_for_black[x - 1, y] && !occupied_for_white[x - 1, y])
                                    valid_move[0] = (char)(y + 97) + "" + (x);
                                if (occupied_for_black[x - 1, y + 1] && !occupied_for_white[x - 1, y + 1])
                                    valid_move[1] = (char)(y + 98) + "" + (x);
                                if (occupied_for_black[x - 1, y - 1] && !occupied_for_white[x - 1, y - 1])
                                    valid_move[2] = (char)(y + 96) + "" + (x);
                            
                        }
                    }

                }

            }

        }
    }
}

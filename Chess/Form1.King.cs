using System;
using System.Collections.Generic;
namespace Chess
{
    public partial class Form1
    {
        public class King: piece
        {
            public List<string> moves = new List<string>();
            public King(string a, string c, string d, string e)
            {
                piece_name = a;
                side = c;
                piece_background_colour = d;
                position =e;
                
                occupied_for_black = new bool[8, 8];
                occupied_for_white = new bool[8, 8];
            }
            public override void valid_moves(string a, string b, bool[,] c, bool[,] d) { }
            public void valid_moves(string side, string position, Rook r, Rook r2, pawn p, pawn p2, Queen q, bishop b, bishop b2, Horse h, Horse h2, bool[,] for_black, bool[,] for_white)
            {
                moves = new List<string>();
                string[] temp_moves = new string[8];
                string top_left = (char)(position[0] - 1) + "" + (char)(position[1] + 1);
                string bottom_left = (char)(position[0] - 1) + "" + (char)(position[1] - 1);
                string bottom_right = (char)(position[0] + 1) + "" + (char)(position[1] - 1);
                string top_right = (char)(position[0] + 1) + "" + (char)(position[1] + 1);
                string top = (char)(position[0]) + "" + (char)(position[1] + 1);
                string bottom = (char)position[0] + "" + (char)(position[1] - 1);
                string right = (char)(position[0] + 1) + "" + (char)position[1];
                string left = (char)(position[0] - 1) + "" + (char)position[1];


                temp_moves[0] = top;
                temp_moves[1] = bottom;
                temp_moves[2] = right;
                temp_moves[3] = left;
                temp_moves[4] = top_right;
                temp_moves[5] = bottom_left;
                temp_moves[6] = bottom_right;
                temp_moves[7] = top_left;

                int x;
                if (position == "g_4")
                    x = position[2] - 49;
                else
                    x = position[1] - 49;
                int y = position[0] - 97;

                for (int i = 0; i < 8; i++)
                {
                    if (temp_moves[i][1] == '9' || temp_moves[i][0] == 'i' || temp_moves[i][0] == 96 || temp_moves[i][1] == '0')
                    {
                        continue;
                    }
                    else
                        moves.Add(temp_moves[i]);
                }
               
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
                    if (position[1] != '8')
                    {
                        if (position[0] != 'h')
                        {
                            if (occupied_for_black[x + 1, y + 1])
                                moves.Remove(top_right);
                        }


                        if (occupied_for_black[x + 1, y])
                            moves.Remove(top);

                        if (position[0] != 'a')
                        {
                            if (occupied_for_black[x + 1, y - 1])
                                moves.Remove(top_left);
                        }

                    }
                    if (position[0] != 'a')
                    {
                        if (occupied_for_black[ Math.Abs(1-x), y])
                            moves.Remove(bottom);
                        if (occupied_for_black[Math.Abs(1-x), y + 1])
                            moves.Remove(bottom_right);
                        if (occupied_for_black[Math.Abs(1-x), y - 1])
                            moves.Remove(bottom_left);
                        if (occupied_for_black[x, y - 1])
                            moves.Remove(left);
                    }
                    if (position[1] != '1')
                    {
                        if (occupied_for_black[x, Math.Abs(y - 1)])
                            moves.Remove(left);
                    }
                    if (position[1] != '7')
                    {
                        if (occupied_for_black[x, y + 1])
                            moves.Remove(right);
                    }
                    p.valid_moves(p.Side, p.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        if (temp_moves[i] == p.Valid_move[2])
                            moves.Remove(temp_moves[i]);
                        if (temp_moves[i] == p.Valid_move[3])
                            moves.Remove(temp_moves[i]);

                    }
                    r.valid_moves(r.Side, r.Position,for_black,for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in r.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {
                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    q.valid_moves(q.Side, q.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in q.Valid_move)
                        {
                            if (str == temp_moves[i])
                            {

                                moves.Remove(str);
                            }

                        }

                    }
                    h.valid_moves(h.Side, h.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in h.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    b.valid_moves(b.Side, b.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in b.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }

                    }

                }
                if (side == "white")
                {
                    if (position[1] != '8')
                    {
                        if (position[0] != 'h')
                        {
                            if (occupied_for_white[x + 1, y + 1])
                                moves.Remove(top_right);
                        }


                        if (occupied_for_white[x + 1, y])
                            moves.Remove(top);

                        if (position[0] != 'a')
                        {
                            if (occupied_for_white[x + 1, y - 1])
                                moves.Remove(top_left);
                        }

                    }
                    if (position[1] != '1')
                    {
                        if (position[0] != 'a')
                        {
                            if (occupied_for_white[x - 1, y - 1])
                                moves.Remove(bottom_left);

                        }
                        if (position[0] != 'h')
                        {
                            if (occupied_for_white[x - 1, y + 1])
                                moves.Remove(bottom_right);
                        }
                        if (occupied_for_white[x - 1, y])
                            moves.Remove(bottom);


                    }
                    if (position[0] != 'a')
                    {
                        if (occupied_for_white[x, y - 1])
                            moves.Remove(left);
                    }
                    if (position[0] != 'h')
                    {
                        if (occupied_for_white[x, y + 1])
                            moves.Remove(right);
                    }
                    p.valid_moves(p.Side, p.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        if (temp_moves[i] == p.Valid_move[2])
                            moves.Remove(temp_moves[i]);
                        if (temp_moves[i] == p.Valid_move[3])
                            moves.Remove(temp_moves[i]);

                    }
                    p2.valid_moves(p2.Side, p2.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        if (temp_moves[i] == p2.Valid_move[2])
                            moves.Remove(temp_moves[i]);
                        if (temp_moves[i] == p2.Valid_move[3])
                            moves.Remove(temp_moves[i]);

                    }
                    r.valid_moves(r.Side, r.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in r.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    r2.valid_moves(r2.Side, r2.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in r2.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    q.valid_moves(q.Side, q.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in q.Valid_move)
                        {
                            if (str == temp_moves[i])
                            {

                                moves.Remove(str);
                            }

                        }

                    }
                   
                    h.valid_moves(h.Side, h.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in h.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    h2.valid_moves(h2.Side, h2.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in h2.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }
                    }
                    b.valid_moves(b.Side, b.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in b.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }

                    }
                    b2.valid_moves(b2.Side, b2.Position, for_black, for_white);
                    for (int i = 0; i < 8; i++)
                    {
                        foreach (string str in b2.Valid_move)
                        {
                            if (temp_moves[i] == str)
                            {

                                moves.Remove(temp_moves[i]);
                            }

                        }

                    }

                }
            }
        }
    }
    
}

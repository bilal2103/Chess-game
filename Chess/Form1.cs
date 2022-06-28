using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        HashSet<string> moves = new HashSet<string>();
        bool check = false, AI_mode = false;
        string piece_name, from, piece_description, king_pos;
        bool[,] occupied_for_black = new bool[8, 8];
        bool[,] occupied_for_white = new bool[8, 8];
        public Form1()
        {
            InitializeComponent();
        }
        public void _AI_or1_v_1(bool flag)
        {
            if (flag)
            {
                AI_mode = true;
            }
        }
        int count = 0;
        private pawn pawnn = new pawn("pawn", "black", "black", "b2");
        private Horse horse = new Horse("horse", "black", "black", "g1");
        private Queen queen = new Queen("queen", "black", "black", "d1");
        private Rook rook = new Rook("rook", "black", "black", "a1");
        private bishop bishopp = new bishop("bishop", "black", "black", "c1");
        private King king = new King("king", "black", "black", "e1");
    
        private King king_w = new King("king", "white", "white", "e8");
        private bishop bishop_w = new bishop("bishop", "white", "white", "c8");
        private Rook rook_w = new Rook("rook", "white", "white", "a8");
        private pawn pawn_w = new pawn("pawn", "white", "white", "a7");
        private Horse horse_w = new Horse("horse", "white", "white", "g8");
        private Queen queen_w = new Queen("queen", "white", "white", "d8");
       
        private bishop bishop_b_w = new bishop("bishop", "black", "white", "f1");
        private Rook rook_b_w = new Rook("rook", "black", "white", "h1");
        private pawn pawn_b_w = new pawn("pawn", "black", "white", "a2");
        private Horse horse_b_w = new Horse("horse", "black", "white", "b1");
        
        private bishop bishop_w_b = new bishop("bishop", "white", "black", "f8");
        private Horse horse_w_b = new Horse("horse", "white", "black", "b8");
        private pawn pawn_w_b = new pawn("pawn", "white", "black", "a7");
        private Rook rook_w_b = new Rook("rook", "white", "black", "h8");
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    occupied_for_black[i, j] = true;
                }
            }
            
            for (int i = 6; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    occupied_for_white[i, j] = true;
                }
            }
            
            g4.Visible = false;

        }
        private void update_king_pos(PictureBox temp)
        {
            if (temp.AccessibleDescription == "black")
                king.Position = temp.Name;
            else
                king_w.Position = temp.Name;
        }       //to update the position of king
        private void refresh()
        {
            a1.BackColor = Color.Black;
            a3.BackColor = Color.Black;
            a5.BackColor = Color.Black;
            a7.BackColor = Color.Black;

            c1.BackColor = Color.Black;
            c3.BackColor = Color.Black;
            c5.BackColor = Color.Black;
            c7.BackColor = Color.Black;

            e1.BackColor = Color.Black;
            e3.BackColor = Color.Black;
            e5.BackColor = Color.Black;
            e7.BackColor = Color.Black;

            g1.BackColor = Color.Black;
            g3.BackColor = Color.Black;
            g5.BackColor = Color.Black;
            g7.BackColor = Color.Black;

            a2.BackColor = Color.White;
            a4.BackColor = Color.White;
            a6.BackColor = Color.White;
            a8.BackColor = Color.White;

            c2.BackColor = Color.White;
            c4.BackColor = Color.White;
            c6.BackColor = Color.White;
            c8.BackColor = Color.White;

            e2.BackColor = Color.White;
            e4.BackColor = Color.White;
            e6.BackColor = Color.White;
            e8.BackColor = Color.White;

            g2.BackColor = Color.White;
            g_4.BackColor = Color.White;
            g6.BackColor = Color.White;
            g8.BackColor = Color.White;

            b1.BackColor = Color.White;
            b3.BackColor = Color.White;
            b5.BackColor = Color.White;
            b7.BackColor = Color.White;

            d1.BackColor = Color.White;
            d3.BackColor = Color.White;
            d5.BackColor = Color.White;
            d7.BackColor = Color.White;

            f1.BackColor = Color.White;
            f3.BackColor = Color.White;
            f5.BackColor = Color.White;
            f7.BackColor = Color.White;

            h1.BackColor = Color.White;
            h3.BackColor = Color.White;
            h5.BackColor = Color.White;
            h7.BackColor = Color.White;

            b2.BackColor = Color.Black;
            b4.BackColor = Color.Black;
            b6.BackColor = Color.Black;
            b8.BackColor = Color.Black;

            d2.BackColor = Color.Black;
            d4.BackColor = Color.Black;
            d6.BackColor = Color.Black;
            d8.BackColor = Color.Black;

            f2.BackColor = Color.Black;
            f4.BackColor = Color.Black;
            f6.BackColor = Color.Black;
            f8.BackColor = Color.Black;

            h2.BackColor = Color.Black;
            h4.BackColor = Color.Black;
            h6.BackColor = Color.Black;
            h8.BackColor = Color.Black;
        }       //to call after evry move is made incase anyblock does'nt highlights back to its original colour
        private void change(string str, bool flag)  //to call the function highlight to highlight possible moves and also highlight em back
        {
            if (flag)
            {
                switch (str)
                {
                    case "b3":
                        highlight(b3);
                        break;
                    case "b4":

                        highlight(b4);
                        break;
                    case "f3":

                        highlight(f3);
                        break;

                    case "h3":
                        highlight(h3);
                        break;
                    case "a1":
                        highlight(a1);
                        break;
                    case "a2":
                        highlight(a2);
                        break;
                    case "a3":
                        highlight(a3);
                        break;
                    case "a4":
                        highlight(a4);
                        break;
                    case "a5":
                        highlight(a5);
                        break;
                    case "a6":
                        highlight(a6);
                        break;
                    case "a7":
                        highlight(a7);
                        break;
                    case "a8":
                        highlight(a8);
                        break;
                    case "b8":
                        highlight(b8);
                        break;
                    case "b7":
                        highlight(b7);
                        break;
                    case "b6":
                        highlight(b6);
                        break;
                    case "b5":
                        highlight(b5);
                        break;
                    case "b2":
                        highlight(b2);
                        break;
                    case "b1":
                        highlight(b1);
                        break;
                    case "c1":
                        highlight(c1);
                        break;
                    case "c2":
                        highlight(c2);
                        break;
                    case "c3":
                        highlight(c3);
                        break;
                    case "c4":
                        highlight(c4);
                        break;
                    case "c5":
                        highlight(c5);
                        break;
                    case "c6":
                        highlight(c6);
                        break;
                    case "c7":
                        highlight(c7);
                        break;
                    case "c8":
                        highlight(c8);
                        break;
                    case "d1":
                        highlight(d1);
                        break;
                    case "d2":
                        highlight(d2);
                        break;
                    case "d3":
                        highlight(d3);
                        break;
                    case "d4":
                        highlight(d4);
                        break;
                    case "d5":
                        highlight(d5);
                        break;
                    case "d6":
                        highlight(d6);
                        break;
                    case "d7":
                        highlight(d7);
                        break;
                    case "d8":
                        highlight(d8);
                        break;
                    case "e1":
                        highlight(e1);
                        break;
                    case "e2":
                        highlight(e2);
                        break;
                    case "e3":
                        highlight(e3);
                        break;
                    case "e4":
                        highlight(e4);
                        break;
                    case "e5":
                        highlight(e5);
                        break;
                    case "e6":
                        highlight(e6);
                        break;
                    case "e7":
                        highlight(e7);
                        break;
                    case "e8":
                        highlight(e8);
                        break;
                    case "f1":
                        highlight(f1);
                        break;
                    case "f2":
                        highlight(f2);
                        break;
                    case "f4":
                        highlight(f4);
                        break;
                    case "f5":
                        highlight(f5);
                        break;
                    case "f6":
                        highlight(f6);
                        break;
                    case "f7":
                        highlight(f7);
                        break;
                    case "f8":
                        highlight(f8);
                        break;
                    case "g1":
                        highlight(g1);
                        break;
                    case "g2":
                        highlight(g2);
                        break;
                    case "g3":
                        highlight(g3);
                        break;
                    case "g4":
                        highlight(g_4);
                        break;
                    case "g5":
                        highlight(g5);
                        break;
                    case "g6":
                        highlight(g6);
                        break;
                    case "g7":
                        highlight(g7);
                        break;
                    case "g8":
                        highlight(g8);
                        break;
                    case "h1":
                        highlight(h1);
                        break;
                    case "h2":
                        highlight(h2);
                        break;
                    case "h4":
                        highlight(h4);
                        break;
                    case "h5":
                        highlight(h5);
                        break;
                    case "h6":
                        highlight(h6);
                        break;
                    case "h7":
                        highlight(h7);
                        break;
                    case "h8":
                        highlight(h8);
                        break;
                }
            }
            else
            {
                refresh();
            }
        }
        private void highlight(PictureBox temp, bool flag = false)
        {
            if (flag)
                temp.BackColor = Color.Red;
            else
                temp.BackColor = Color.DarkGray;
        }       //highlighting the pictureboxes
        private void update_occupied(string to, string from, string side)
        {
            int x1, x2;
            int y1 = to[0] - 97;
            if (to == "g_4")
                x1 = to[2] - 49;
            else
                x1 = to[1] - 49;
            if (from == "g_4")
                x2 = from[2] - 49;
            else
                x2 = from[1] - 49;
            int y2 = from[0] - 97;

            if (side == "black")
            {
                occupied_for_black[x1, y1] = true;
                occupied_for_black[x2, y2] = false;
            }
            if (side == "white")
            {

                occupied_for_white[x1, y1] = true;
                occupied_for_white[x2, y2] = false;
            }
        }      //updating the occupied blocks
        void change_bg(string str)
        {
            switch (str)
            {
                case "b3":
                    b3.Image = null;
                    break;
                case "b4":
                    b4.Image = null;
                    break;
                case "f3":
                     f3 .Image = null;
                    break;
                case "h3":
                     h3 .Image = null;
                    break;
                case "a1":
                    a1.Image = null;
                    break;
                case "a2":
                     a2.Image = null;
                    break;
                case "a3":
                     a3 .Image = null;
                    break;
                case "a4":
                     a4.Image = null;
                    break;
                case "a5":
                     a5.Image = null;
                    break;
                case "a6":
                     a6.Image = null;
                    break;
                case "a7":
                     a7.Image = null;
                    break;
                case "a8":
                     a8.Image = null;
                    break;
                case "b8":
                     b8.Image = null;
                    break;
                case "b7":
                     b7.Image = null;
                    break;
                case "b6":
                     b6.Image = null;
                    break;
                case "b5":
                     b5.Image = null;
                    break;
                case "b2":
                     b2.Image = null;
                    break;
                case "b1":
                     b1.Image = null;
                    break;
                case "c1":
                     c1.Image = null;
                    break;
                case "c2":
                     c2.Image = null;
                    break;
                case "c3":
                     c3 .Image = null;
                    break;
                case "c4":
                     c4.Image = null;
                    break;
                case "c5":
                     c5.Image = null;
                    break;
                case "c6":
                     c6.Image = null;
                    break;
                case "c7":
                     c7.Image = null;
                    break;
                case "c8":
                     c8.Image = null;
                    break;
                case "d1":
                     d1.Image = null;
                    break;
                case "d2":
                     d2.Image = null;
                    break;
                case "d3":
                     d3 .Image = null;
                    break;
                case "d4":
                     d4.Image = null;
                    break;
                case "d5":
                     d5.Image = null;
                    break;
                case "d6":
                     d6.Image = null;
                    break;
                case "d7":
                     d7.Image = null;
                    break;
                case "d8":
                     d8.Image = null;
                    break;
                case "e1":
                     e1.Image = null;
                    break;
                case "e2":
                     e2.Image = null;
                    break;
                case "e3":
                     e3 .Image = null;
                    break;
                case "e4":
                     e4.Image = null;
                    break;
                case "e5":
                     e5.Image = null;
                    break;
                case "e6":
                     e6.Image = null;
                    break;
                case "e7":
                     e7.Image = null;
                    break;
                case "e8":
                     e8.Image = null;
                    break;
                case "f1":
                     f1.Image = null;
                    break;
                case "f2":
                     f2.Image = null;
                    break;
                case "f4":
                     f4.Image = null;
                    break;
                case "f5":
                     f5.Image = null;
                    break;
                case "f6":
                     f6.Image = null;
                    break;
                case "f7":
                     f7.Image = null;
                    break;
                case "f8":
                     f8.Image = null;
                    break;
                case "g1":
                     g1.Image = null;
                    break;
                case "g2":
                     g2.Image = null;
                    break;
                case "g3":
                     g3 .Image = null;
                    break;
                case "g4":
                     g_4.Image = null;
                    break;
                case "g5":
                     g5.Image = null;
                    break;
                case "g6":
                     g6.Image = null;
                    break;
                case "g7":
                     g7.Image = null;
                    break;
                case "g8":
                     g8.Image = null;
                    break;
                case "h1":
                     h1.Image = null;
                    break;
                case "h2":
                     h2.Image = null;
                    break;
                case "h4":
                     h4.Image = null;
                    break;
                case "h5":
                     h5.Image = null;
                    break;
                case "h6":
                     h6.Image = null;
                    break;
                case "h7":
                     h7.Image = null;
                    break;
                case "h8":
                     h8.Image = null;
                    break;
            }
        }
        private void make_move(PictureBox tempp)
        {
            ++count;
            tempp.AccessibleDescription = piece_description;
            tempp.AccessibleName = piece_name;
            tempp.Image = temp.Image;
            if (tempp.AccessibleDescription == "black")
                update_occupied(tempp.Name, from, "black");
            if (tempp.AccessibleDescription == "white")
                update_occupied(tempp.Name, from, "white");
            validate_last_move(tempp);
            change_bg(from);
            refresh();
            moves.Clear();
        }       //to make a move, swap the positions, accessible description, accessible name.  
        void delete_object(string str , string side)
        {
            if(side == "white")
            {
                if (pawn_w.Position == str)
                    pawn_w.Status = "out";
                if(pawn_w_b.Position == str)
                    pawn_w_b.Status = "out";
                if(horse_w.Position == str)
                   horse_w.Status = "out";
              if(horse_w_b.Position == str)
                 horse_w_b.Status = "out";
               if(bishop_w.Position == str)
                  bishop_w.Status = "out";
             if(bishop_w_b.Position == str)
                bishop_w_b.Status= "out";
                 if(rook_w.Position ==str)
                    rook_w.Status = "out";
              if (rook_w_b.Position == str) 
                  rook_w_b.Status = "out";
                if(queen_w.Position == str)
                   queen_w.Status = "out";
            }
            else
            {
                if (pawnn.Position == str)
                    pawnn.Status = "out";
                if (pawn_b_w.Position == str)
                    pawn_b_w.Status = "out";
                if (horse.Position == str)
                    horse.Status = "out";
                if (horse_b_w.Position == str)
                    horse_b_w.Status = "out";
                if (bishopp.Position == str)
                    bishopp.Status = "out";
                if (bishop_b_w.Position == str)
                    bishop_b_w.Status = "out";
                if (rook.Position == str)
                    rook.Status = "out";
                if (rook_b_w.Position == str)
                    rook_b_w.Status = "out";
                if (queen.Position == str)
                    queen.Status = "out";
            }
        }       //to set the Status of an object to "out" once it is beaten by opponent.
        private void validate_last_move(PictureBox Temp)
        {
            int x;
            if (Temp.Name == "g_4")
                x = Temp.Name[2] - 49;
            else
                x = Temp.Name[1] - 49;
            int y = Temp.Name[0] - 97;
            if (occupied_for_black[x, y] && occupied_for_white[x, y])
            {

                if (Temp.AccessibleDescription == "black")
                {
                    occupied_for_white[x, y] = false;
                    delete_object(Temp.Name,"white");
                }
                if (Temp.AccessibleDescription == "white")
                {
                    occupied_for_black[x, y] = false;
                    delete_object(Temp.Name, "black");
                }
            }


        }   //to deal with players beating pieces of eachother 
        private void prepare_to_move(PictureBox tempp, bool flag = false)
        {
            refresh();
            temp.Image = tempp.Image;
            piece_name = tempp.AccessibleName;
            piece_description = tempp.AccessibleDescription;
            if (!flag)
                add_move(tempp.AccessibleName);
        }   //when a user clicks on a piece, this move is used to calculate its valid moves.
        private void add_move(string piec, bool flag = false)
        {
            moves.Clear();
            if (piec == "pawn_black_black")
            {
                pawnn.Position = from;
                pawnn.valid_moves(pawnn.Side, pawnn.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in pawnn.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }

            }
            if (piec == "pawn_black_white")
            {
                pawn_b_w.Position = from;
                pawn_b_w.valid_moves(pawn_b_w.Side, pawn_b_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in pawn_b_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "horse_black_black")
            {
                horse.Position = from;
                horse.valid_moves(horse.Side, horse.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in horse.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "horse_black_white")
            {
                horse_b_w.Position = from;
                horse_b_w.valid_moves(horse_b_w.Side, horse_b_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in horse_b_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "pawn_white_white")
            {
                pawn_w.Position = from;
                pawn_w.valid_moves(pawn_w.Side, pawn_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in pawn_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "pawn_white_black")
            {
                pawn_w_b.Position = from;
                pawn_w_b.valid_moves(pawn_w_b.Side, pawn_w_b.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in pawn_w_b.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "horse_white_black")
            {
                horse_w_b.Position = from;
                horse_w_b.valid_moves(horse_w_b.Side, horse_w_b.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in horse_w_b.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "horse_white_white")
            {
                horse_w.Position = from;
                horse_w.valid_moves(horse_w.Side, horse_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in horse_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "bishop_white_black")
            {
                bishop_w_b.Position = from;
                bishop_w_b.valid_moves(bishop_w_b.Side, bishop_w_b.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in bishop_w_b.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "bishop_white_white")
            {
                bishop_w.Position = from;
                bishop_w.valid_moves(bishop_w.Side, bishop_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in bishop_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "bishop_black_black")
            {
                bishopp.Position = from;
                bishopp.valid_moves(bishopp.Side, bishopp.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in bishopp.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "bishop_black_white")
            {
                bishop_b_w.Position = from;
                bishop_b_w.valid_moves(bishop_b_w.Side, bishop_b_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in bishop_b_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "queen_white")
            {
                queen_w.Position = from;
                queen_w.valid_moves(queen_w.Side, queen_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in queen_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "queen_black")
            {
                queen.Position = from;
                queen.Side = "black";
                queen.valid_moves(queen.Side, queen.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in queen.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "rook_black_black")
            {
                rook.Position = from;
                rook.Side = "black";
                rook.valid_moves(rook.Side, rook.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in rook.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "rook_black_white")
            {
                rook_b_w.Position = from;
                rook_b_w.Side = "black";
                rook_b_w.valid_moves(rook_b_w.Side, rook_b_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in rook_b_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }

            }
            if (piec == "rook_white_black")
            {
                rook_w_b.Position = from;
                rook_w_b.valid_moves(rook_w_b.Side, rook_w_b.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in rook_w_b.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "rook_white_white")
            {
                rook_w.Position = from;
                rook_w.valid_moves(rook_w.Side, rook_w.Position, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in rook_w.Valid_move)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "king_black")
            {
                king.Position = from;
                king.valid_moves(king.Side, king.Position, rook_w, rook_w_b, pawn_w, pawn_w_b, queen_w, bishop_w, bishop_w_b, horse_w, horse_w_b, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in king.moves)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
            if (piec == "king_white")
            {
                king_w.Position = from;
                king_w.valid_moves(king_w.Side, king_w.Position, rook, rook_b_w, pawnn, pawn_b_w, queen, bishopp, bishop_b_w, horse, horse_b_w, occupied_for_black, occupied_for_white);
                moves.Clear();
                foreach (string str in king_w.moves)
                {
                    if (!flag)
                        change(str, true);
                    moves.Add(str);
                }
            }
        }       //adding valid moves in a list
        private void change_names(string str)       //changing the description of block from which a piece moved.
        {
            switch (str)
            {
                case "a1":
                    a1.AccessibleDescription = "empty";
                    a1.AccessibleName = "empty";
                    break;
                case "a2":
                    a2.AccessibleDescription = "empty";
                    a2.AccessibleName = "empty";
                    break;
                case "a4":
                    a4.AccessibleDescription = "empty";
                    a4.AccessibleName = "empty";
                    break;
                case "a6":
                    a6.AccessibleDescription = "empty";
                    a6.AccessibleName = "empty";
                    break;
                case "a8":
                    a8.AccessibleDescription = "empty";
                    a8.AccessibleName = "empty";
                    break;
                case "a3":
                    a3.AccessibleDescription = "empty";
                    a3.AccessibleName = "empty";
                    break;
                case "a5":
                    a5.AccessibleDescription = "empty";
                    a5.AccessibleName = "empty";
                    break;
                case "a7":
                    a7.AccessibleDescription = "empty";
                    a7.AccessibleName = "empty";
                    break;

                case "b1":
                    b1.AccessibleDescription = "empty";
                    b1.AccessibleName = "empty";
                    break;
                case "b2":
                    b2.AccessibleDescription = "empty";
                    b2.AccessibleName = "empty";
                    break;
                case "b3":
                    b3.AccessibleDescription = "empty";
                    b3.AccessibleName = "empty";
                    break;
                case "b4":
                    b4.AccessibleDescription = "empty";
                    b4.AccessibleName = "empty";
                    break;
                case "b5":
                    b5.AccessibleDescription = "empty";
                    b5.AccessibleName = "empty";
                    break;
                case "b6":
                    b6.AccessibleDescription = "empty";
                    b6.AccessibleName = "empty";
                    break;
                case "b7":
                    b7.AccessibleDescription = "empty";
                    b7.AccessibleName = "empty";
                    break;
                case "b8":
                    b8.AccessibleDescription = "empty";
                    b8.AccessibleName = "empty";
                    break;

                case "c1":
                    c1.AccessibleDescription = "empty";
                    c1.AccessibleName = "empty";
                    break;
                case "c2":
                    c2.AccessibleDescription = "empty";
                    c2.AccessibleName = "empty";
                    break;
                case "c4":
                    c4.AccessibleDescription = "empty";
                    c4.AccessibleName = "empty";
                    break;
                case "c6":
                    c6.AccessibleDescription = "empty";
                    c6.AccessibleName = "empty";
                    break;
                case "c8":
                    c8.AccessibleDescription = "empty";
                    c8.AccessibleName = "empty";
                    break;
                case "c3":
                    c3.AccessibleDescription = "empty";
                    c3.AccessibleName = "empty";
                    break;
                case "c5":
                    c5.AccessibleDescription = "empty";
                    c5.AccessibleName = "empty";
                    break;
                case "c7":
                    c7.AccessibleDescription = "empty";
                    c7.AccessibleName = "empty";
                    break;

                case "d1":
                    d1.AccessibleDescription = "empty";
                    d1.AccessibleName = "empty";
                    break;
                case "d2":
                    d2.AccessibleDescription = "empty";
                    d2.AccessibleName = "empty";
                    break;
                case "d3":
                    d3.AccessibleDescription = "empty";
                    d3.AccessibleName = "empty";
                    break;
                case "d4":
                    d4.AccessibleDescription = "empty";
                    d4.AccessibleName = "empty";
                    break;
                case "d5":
                    d5.AccessibleDescription = "empty";
                    d5.AccessibleName = "empty";
                    break;
                case "d6":
                    d6.AccessibleDescription = "empty";
                    d6.AccessibleName = "empty";
                    break;
                case "d7":
                    d7.AccessibleDescription = "empty";
                    d7.AccessibleName = "empty";
                    break;
                case "d8":
                    d8.AccessibleDescription = "empty";
                    d8.AccessibleName = "empty";
                    break;

                case "e1":
                    e1.AccessibleDescription = "empty";
                    e1.AccessibleName = "empty";
                    break;
                case "e2":
                    e2.AccessibleDescription = "empty";
                    e2.AccessibleName = "empty";
                    break;
                case "e4":
                    e4.AccessibleDescription = "empty";
                    e4.AccessibleName = "empty";
                    break;
                case "e6":
                    e6.AccessibleDescription = "empty";
                    e6.AccessibleName = "empty";
                    break;
                case "e8":
                    e8.AccessibleDescription = "empty";
                    e8.AccessibleName = "empty";
                    break;
                case "e3":
                    e3.AccessibleDescription = "empty";
                    e3.AccessibleName = "empty";
                    break;
                case "e5":
                    e5.AccessibleDescription = "empty";
                    e5.AccessibleName = "empty";
                    break;
                case "e7":
                    e7.AccessibleDescription = "empty";
                    e7.AccessibleName = "empty";
                    break;


                case "f1":
                    f1.AccessibleDescription = "empty";
                    f1.AccessibleName = "empty";
                    break;
                case "f2":
                    f2.AccessibleDescription = "empty";
                    f2.AccessibleName = "empty";
                    break;
                case "f3":
                    f3.AccessibleDescription = "empty";
                    f3.AccessibleName = "empty";
                    break;
                case "f4":
                    f4.AccessibleDescription = "empty";
                    f4.AccessibleName = "empty";
                    break;
                case "f5":
                    f5.AccessibleDescription = "empty";
                    f5.AccessibleName = "empty";
                    break;
                case "f6":
                    f6.AccessibleDescription = "empty";
                    f6.AccessibleName = "empty";
                    break;
                case "f7":
                    f7.AccessibleDescription = "empty";
                    f7.AccessibleName = "empty";
                    break;
                case "f8":
                    f8.AccessibleDescription = "empty";
                    f8.AccessibleName = "empty";
                    break;

                case "g1":
                    g1.AccessibleDescription = "empty";
                    g1.AccessibleName = "empty";
                    break;
                case "g2":
                    g2.AccessibleDescription = "empty";
                    g2.AccessibleName = "empty";
                    break;
                case "g4":
                    g_4.AccessibleDescription = "empty";
                    g_4.AccessibleName = "empty";
                    break;
                case "g6":
                    g6.AccessibleDescription = "empty";
                    g6.AccessibleName = "empty";
                    break;
                case "g8":
                    g8.AccessibleDescription = "empty";
                    g8.AccessibleName = "empty";
                    break;
                case "g3":
                    g3.AccessibleDescription = "empty";
                    g3.AccessibleName = "empty";
                    break;
                case "g5":
                    g5.AccessibleDescription = "empty";
                    g5.AccessibleName = "empty";
                    break;
                case "g7":
                    g7.AccessibleDescription = "empty";
                    g7.AccessibleName = "empty";
                    break;

                case "h1":
                    h1.AccessibleDescription = "empty";
                    h1.AccessibleName = "empty";
                    break;
                case "h2":
                    h2.AccessibleDescription = "empty";
                    h2.AccessibleName = "empty";
                    break;
                case "h3":
                    h3.AccessibleDescription = "empty";
                    h3.AccessibleName = "empty";
                    break;
                case "h4":
                    h4.AccessibleDescription = "empty";
                    h4.AccessibleName = "empty";
                    break;
                case "h5":
                    h5.AccessibleDescription = "empty";
                    h5.AccessibleName = "empty";
                    break;
                case "h6":
                    h6.AccessibleDescription = "empty";
                    h6.AccessibleName = "empty";
                    break;
                case "h7":
                    h7.AccessibleDescription = "empty";
                    h7.AccessibleName = "empty";
                    break;
                case "h8":
                    h8.AccessibleDescription = "empty";
                    h8.AccessibleName = "empty";
                    break;
            }
        }
        private bool check_for_turn(string b)
        {
            if (b == "empty")
            {
                MessageBox.Show("Invalid");
            }
            if (count == 0 || count % 2 == 0)
            {
                if (b == "black")
                    return true;
            }
            else
            {
                if (b == "white")
                    return true;
            }
            return false;
        }             //checks for the turn by comparing count.
        private void change_king_colour(string str)      //to make king's position red
        {
            switch (str)
            {
                case "a1":
                    a1.BackColor = Color.Red;
                    break;
                case "a2":
                    a2.BackColor = Color.Red;
                    break;
                case "a3":
                    a3.BackColor = Color.Red;
                    break;
                case "a4":
                    a4.BackColor = Color.Red;
                    break;
                case "a5":
                    a5.BackColor = Color.Red;
                    break;
                case "a8":
                    a8.BackColor = Color.Red;
                    break;
                case "a7":
                    a7.BackColor = Color.Red;
                    break;
                case "a6":
                    a6.BackColor = Color.Red;
                    break;

                case "b1":
                    b1.BackColor = Color.Red;
                    break;
                case "b2":
                    b2.BackColor = Color.Red;
                    break;
                case "b3":
                    b3.BackColor = Color.Red;
                    break;
                case "b4":
                    b4.BackColor = Color.Red;
                    break;
                case "b5":
                    b5.BackColor = Color.Red;
                    break;
                case "b8":
                    b8.BackColor = Color.Red;
                    break;
                case "b7":
                    b7.BackColor = Color.Red;
                    break;
                case "b6":
                    b6.BackColor = Color.Red;
                    break;

                case "c1":
                    c1.BackColor = Color.Red;
                    break;
                case "c2":
                    c2.BackColor = Color.Red;
                    break;
                case "c3":
                    c3.BackColor = Color.Red;
                    break;
                case "c4":
                    c4.BackColor = Color.Red;
                    break;
                case "c5":
                    b5.BackColor = Color.Red;
                    break;
                case "c8":
                    c8.BackColor = Color.Red;
                    break;
                case "c7":
                    c7.BackColor = Color.Red;
                    break;
                case "c6":
                    c6.BackColor = Color.Red;
                    break;


                case "d1":
                    d1.BackColor = Color.Red;
                    break;
                case "d2":
                    d2.BackColor = Color.Red;
                    break;
                case "d3":
                    d3.BackColor = Color.Red;
                    break;
                case "d4":
                    d4.BackColor = Color.Red;
                    break;
                case "d5":
                    d5.BackColor = Color.Red;
                    break;
                case "d8":
                    d8.BackColor = Color.Red;
                    break;
                case "d7":
                    d7.BackColor = Color.Red;
                    break;
                case "d6":
                    d6.BackColor = Color.Red;
                    break;

                case "e1":
                    e1.BackColor = Color.Red;
                    break;
                case "e2":
                    e2.BackColor = Color.Red;
                    break;
                case "e3":
                    e3.BackColor = Color.Red;
                    break;
                case "e4":
                    e4.BackColor = Color.Red;
                    break;
                case "e5":
                    e5.BackColor = Color.Red;
                    break;
                case "e8":
                    e8.BackColor = Color.Red;
                    break;
                case "e7":
                    e7.BackColor = Color.Red;
                    break;
                case "e6":
                    e6.BackColor = Color.Red;
                    break;

                case "f1":
                    f1.BackColor = Color.Red;
                    break;
                case "f2":
                    f2.BackColor = Color.Red;
                    break;
                case "f3":
                    f3.BackColor = Color.Red;
                    break;
                case "f4":
                    f4.BackColor = Color.Red;
                    break;
                case "f5":
                    f5.BackColor = Color.Red;
                    break;
                case "f8":
                    f8.BackColor = Color.Red;
                    break;
                case "f7":
                    f7.BackColor = Color.Red;
                    break;
                case "f6":
                    f6.BackColor = Color.Red;
                    break;

                case "g1":
                    g1.BackColor = Color.Red;
                    break;
                case "g2":
                    g2.BackColor = Color.Red;
                    break;
                case "g3":
                    g3.BackColor = Color.Red;
                    break;
                case "g4":
                    g4.BackColor = Color.Red;
                    break;
                case "g5":
                    g5.BackColor = Color.Red;
                    break;
                case "g8":
                    g8.BackColor = Color.Red;
                    break;
                case "g7":
                    g7.BackColor = Color.Red;
                    break;
                case "g6":
                    g6.BackColor = Color.Red;
                    break;

                case "h1":
                    h1.BackColor = Color.Red;
                    break;
                case "h2":
                    h2.BackColor = Color.Red;
                    break;
                case "h3":
                    h3.BackColor = Color.Red;
                    break;
                case "h4":
                    h4.BackColor = Color.Red;
                    break;
                case "h5":
                    h5.BackColor = Color.Red;
                    break;
                case "h8":
                    h8.BackColor = Color.Red;
                    break;
                case "h7":
                    h7.BackColor = Color.Red;
                    break;
                case "h6":
                    h6.BackColor = Color.Red;
                    break;
            }
        }
        List<string> names = new List<string>();
        public int get_name(string piece)       //calls the functions to set the points based upon the piece on this block.
        {
            int temp = 0;
            switch (piece)
            {
                case "a1":
                    temp = set_point(a1.AccessibleName);
                    names.Add(a1.AccessibleName);
                    break;
                case "a2":
                    temp = set_point(a2.AccessibleName);
                    names.Add(a2.AccessibleName);
                    break;
                case "a3":
                    temp = set_point(a3.AccessibleName);
                    names.Add(a3.AccessibleName);
                    break;
                case "a4":
                    temp = set_point(a4.AccessibleName);
                    names.Add(a4.AccessibleName);
                    break;
                case "a5":
                    temp = set_point(a5.AccessibleName);
                    names.Add(a5.AccessibleName);
                    break;
                case "a6":
                    temp = set_point(a6.AccessibleName);
                    names.Add(a6.AccessibleName);
                    break;
                case "a7":
                    temp = set_point(a7.AccessibleName);
                    names.Add(a7.AccessibleName);
                    break;
                case "a8":
                    temp = set_point(a8.AccessibleName);
                    names.Add(a8.AccessibleName);
                    break;

                case "b1":
                    temp = set_point(b1.AccessibleName);
                    names.Add(b1.AccessibleName);
                    break;
                case "b2":
                    temp = set_point(b2.AccessibleName);
                    names.Add(b2.AccessibleName);
                    break;
                case "b3":
                    temp = set_point(b3.AccessibleName);
                    names.Add(b3.AccessibleName);
                    break;
                case "b4":
                    temp = set_point(b4.AccessibleName);
                    names.Add(b4.AccessibleName);
                    break;
                case "b5":
                    temp = set_point(b5.AccessibleName);
                    names.Add(b5.AccessibleName);
                    break;
                case "b6":
                    temp = set_point(b6.AccessibleName);
                    names.Add(b6.AccessibleName);
                    break;
                case "b7":
                    temp = set_point(b7.AccessibleName);
                    names.Add(b7.AccessibleName);
                    break;
                case "b8":
                    temp = set_point(b8.AccessibleName);
                    names.Add(b8.AccessibleName);
                    break;

                case "c1":
                    temp = set_point(c1.AccessibleName);
                    names.Add(c1.AccessibleName);
                    break;
                case "c2":
                    temp = set_point(c2.AccessibleName);
                    names.Add(c2.AccessibleName);
                    break;
                case "c3":
                    temp = set_point(c3.AccessibleName);
                    names.Add(c3.AccessibleName);
                    break;
                case "c4":
                    temp = set_point(c4.AccessibleName);
                    names.Add(c4.AccessibleName);
                    break;
                case "c5":
                    temp = set_point(c5.AccessibleName);
                    names.Add(c5.AccessibleName);
                    break;
                case "c6":
                    temp = set_point(c6.AccessibleName);
                    names.Add(c6.AccessibleName);
                    break;
                case "c7":
                    temp = set_point(c7.AccessibleName);
                    names.Add(c7.AccessibleName);
                    break;
                case "c8":
                    temp = set_point(c8.AccessibleName);
                    names.Add(c8.AccessibleName);
                    break;

                case "d1":
                    temp = set_point(d1.AccessibleName);
                    names.Add(d1.AccessibleName);
                    break;
                case "d2":
                    temp = set_point(d2.AccessibleName);
                    names.Add(d2.AccessibleName);
                    break;
                case "d3":
                    temp = set_point(d3.AccessibleName);
                    names.Add(d3.AccessibleName);
                    break;
                case "d4":
                    temp = set_point(d4.AccessibleName);
                    names.Add(d4.AccessibleName);
                    break;
                case "d5":
                    temp = set_point(d5.AccessibleName);
                    names.Add(d5.AccessibleName);
                    break;
                case "d6":
                    temp = set_point(d6.AccessibleName);
                    names.Add(d6.AccessibleName);
                    break;
                case "d7":
                    temp = set_point(d7.AccessibleName);
                    names.Add(d7.AccessibleName);
                    break;
                case "d8":
                    temp = set_point(d8.AccessibleName);
                    names.Add(d8.AccessibleName);
                    break;

                case "e1":
                    temp = set_point(e1.AccessibleName);
                    names.Add(e1.AccessibleName);
                    break;
                case "e2":
                    temp = set_point(e2.AccessibleName);
                    names.Add(e2.AccessibleName);
                    break;
                case "e3":
                    temp = set_point(e3.AccessibleName);
                    names.Add(e3.AccessibleName);
                    break;
                case "e4":
                    temp = set_point(e4.AccessibleName);
                    names.Add(e4.AccessibleName);
                    break;
                case "e5":
                    temp = set_point(e5.AccessibleName);
                    names.Add(e5.AccessibleName);
                    break;
                case "e6":
                    temp = set_point(e6.AccessibleName);
                    names.Add(e6.AccessibleName);
                    break;
                case "e7":
                    temp = set_point(e7.AccessibleName);
                    names.Add(e7.AccessibleName);
                    break;
                case "e8":
                    temp = set_point(e8.AccessibleName);
                    names.Add(e8.AccessibleName);
                    break;

                case "f1":
                    temp = set_point(f1.AccessibleName);
                    names.Add(f1.AccessibleName);
                    break;
                case "f2":
                    temp = set_point(f2.AccessibleName);
                    names.Add(f2.AccessibleName);
                    break;
                case "f3":
                    temp = set_point(f3.AccessibleName);
                    names.Add(f3.AccessibleName);
                    break;
                case "f4":
                    temp = set_point(f4.AccessibleName);
                    names.Add(f4.AccessibleName);
                    break;
                case "f5":
                    temp = set_point(f5.AccessibleName);
                    names.Add(f5.AccessibleName);
                    break;
                case "f6":
                    temp = set_point(f6.AccessibleName);
                    names.Add(f6.AccessibleName);
                    break;
                case "f7":
                    temp = set_point(f7.AccessibleName);
                    names.Add(f7.AccessibleName);
                    break;
                case "f8":
                    temp = set_point(f8.AccessibleName);
                    names.Add(f8.AccessibleName);
                    break;

                case "g1":
                    temp = set_point(g1.AccessibleName);
                    names.Add(g1.AccessibleName);
                    break;
                case "g2":
                    temp = set_point(g2.AccessibleName);
                    names.Add(g2.AccessibleName);
                    break;
                case "g3":
                    temp = set_point(g3.AccessibleName);
                    names.Add(g3.AccessibleName);
                    break;
                case "g4":
                    temp = set_point(g_4.AccessibleName);
                    names.Add(g_4.AccessibleName);
                    break;
                case "g5":
                    temp = set_point(g5.AccessibleName);
                    names.Add(g5.AccessibleName);
                    break;
                case "g6":
                    temp = set_point(g6.AccessibleName);
                    names.Add(g6.AccessibleName);
                    break;
                case "g7":
                    temp = set_point(g7.AccessibleName);
                    names.Add(g7.AccessibleName);
                    break;
                case "g8":
                    temp = set_point(g8.AccessibleName);
                    names.Add(g8.AccessibleName);
                    break;

                case "h1":
                    temp = set_point(h1.AccessibleName);
                    names.Add(h1.AccessibleName);
                    break;
                case "h2":
                    temp = set_point(h2.AccessibleName);
                    names.Add(h2.AccessibleName);
                    break;
                case "h3":
                    temp = set_point(h3.AccessibleName);
                    names.Add(h3.AccessibleName);
                    break;
                case "h4":
                    temp = set_point(h4.AccessibleName);
                    names.Add(h4.AccessibleName);
                    break;
                case "h5":
                    temp = set_point(h5.AccessibleName);
                    names.Add(h5.AccessibleName);
                    break;
                case "h6":
                    temp = set_point(h6.AccessibleName);
                    names.Add(h6.AccessibleName);
                    break;
                case "h7":
                    temp = set_point(h7.AccessibleName);
                    names.Add(h7.AccessibleName);
                    break;
                case "h8":
                    temp = set_point(h8.AccessibleName);
                    names.Add(h8.AccessibleName);
                    break;

            }
            return temp;
        }
        HashSet<int> max_p = new HashSet<int>();
        string max_piece_name;
        private int set_point(string str)
        {
            int max = 0;
            switch (str)
            {
                case "empty":
                    max = -1;
                    break;
                case "pawn_black_black":
                    max = 1;
                    break;
                case "pawn_black_white":
                    max = 1;
                    break;
                case "bishop_black_black":
                    max = 5;
                    break;
                case "bishop_black_white":
                    max = 5;
                    break;
                case "rook_black_white":
                    max = 2;
                    break;
                case "rook_black_black":
                    max = 2;
                    break;
                case "horse_black_black":
                    max = 3;
                    break;
                case "horse_black_white":
                    max = 3;
                    break;
                case "queen_black":
                    max = 6;
                    break;
                case "king_black":
                    max = 69;
                    break;
            }
            return max;
        }   //returns the points that can be obtained when a piece moves to a certain location.
        void prep_move_AI(string hehe)
        {       
            switch (hehe)
            {
                case "a1":
                    from = "a1";
                    prepare_to_move(a1);
                    break;
                case "a2":
                    from = "a2";
                    prepare_to_move(a2);
                    break;
                case "a3":
                    from = "a3";
                    prepare_to_move(a3);
                    break;
                case "a4":
                    from = "a4";
                    prepare_to_move(a4);
                    break;
                case "a5":
                    from = "a5";
                    prepare_to_move(a5);
                    break;
                case "a6":
                    from = "a6";
                    prepare_to_move(a6);
                    break;
                case "a7":
                    from = "a7";
                    prepare_to_move(a7);
                    break;
                case "a8":
                    from = "a8";
                    prepare_to_move(a8);
                    break;

                case "b1":
                    from = "b1";
                    prepare_to_move(b1);
                    break;
                case "b2":
                    from = "b2";
                    prepare_to_move(b2);
                    break;
                case "b3":
                    from = "b3";
                    prepare_to_move(b3);
                    break;
                case "b4":
                    from = "b4";
                    prepare_to_move(b4);
                    break;
                case "b5":
                    from = "b5";
                    prepare_to_move(b5);
                    break;
                case "b6":
                    from = "b6";
                    prepare_to_move(b6);
                    break;
                case "b7":
                    from = "b7";
                    prepare_to_move(b7);
                    break;
                case "b8":
                    from = "b8";
                    prepare_to_move(b8);
                    break;

                case "c1":
                    from = "c1";
                    prepare_to_move(c1);
                    break;
                case "c2":
                    from = "c2";
                    prepare_to_move(c2);
                    break;
                case "c3":
                    from = "c3";
                    prepare_to_move(c3);
                    break;
                case "c4":
                    from = "c4";
                    prepare_to_move(c4);
                    break;
                case "c5":
                    from = "c5";
                    prepare_to_move(c5);
                    break;
                case "c6":
                    from = "c6";
                    prepare_to_move(c6);
                    break;
                case "c7":
                    from = "c7";
                    prepare_to_move(c7);
                    break;
                case "c8":
                    from = "c8";
                    prepare_to_move(c8);
                    break;

                case "d1":
                    from = "d1";
                    prepare_to_move(d1);
                    break;
                case "d2":
                    from = "d2";
                    prepare_to_move(d2);
                    break;
                case "d3":
                    from = "d3";
                    prepare_to_move(d3);
                    break;
                case "d4":
                    from = "d4";
                    prepare_to_move(d4);
                    break;
                case "d5":
                    from = "d5";
                    prepare_to_move(d5);
                    break;
                case "d6":
                    from = "d6";
                    prepare_to_move(d6);
                    break;
                case "d7":
                    from = "d7";
                    prepare_to_move(d7);
                    break;
                case "d8":
                    from = "d8";
                    prepare_to_move(d8);
                    break;

                case "e1":
                    from = "e1";
                    prepare_to_move(e1);
                    break;
                case "e2":
                    from = "e2";
                    prepare_to_move(e2);
                    break;
                case "e3":
                    from = "e3";
                    prepare_to_move(e3);
                    break;
                case "e4":
                    from = "e4";
                    prepare_to_move(e4);
                    break;
                case "e5":
                    from = "e5";
                    prepare_to_move(e5);
                    break;
                case "e6":
                    from = "e6";
                    prepare_to_move(e6);
                    break;
                case "e7":
                    from = "e7";
                    prepare_to_move(e7);
                    break;
                case "e8":
                    from = "e8";
                    prepare_to_move(e8);
                    break;

                case "f1":
                    from = "f1";
                    prepare_to_move(f1);
                    break;
                case "f2":
                    from = "f2";
                    prepare_to_move(f2);
                    break;
                case "f3":
                    from = "f3";
                    prepare_to_move(f3);
                    break;
                case "f4":
                    from = "f4";
                    prepare_to_move(f4);
                    break;
                case "f5":
                    from = "f5";
                    prepare_to_move(f5);
                    break;
                case "f6":
                    from = "f6";
                    prepare_to_move(f6);
                    break;
                case "f7":
                    from = "f7";
                    prepare_to_move(f7);
                    break;
                case "f8":
                    from = "f8";
                    prepare_to_move(f8);
                    break;

                case "g1":
                    from = "a1";
                    prepare_to_move(a1);
                    break;
                case "g2":
                    from = "g2";
                    prepare_to_move(g2);
                    break;
                case "g3":
                    from = "g3";
                    prepare_to_move(g3);
                    break;
                case "g4":
                    from = "g4";
                    prepare_to_move(g_4);
                    break;
                case "g5":
                    from = "g5";
                    prepare_to_move(g5);
                    break;
                case "g6":
                    from = "g6";
                    prepare_to_move(g6);
                    break;
                case "g7":
                    from = "g7";
                    prepare_to_move(g7);
                    break;
                case "g8":
                    from = "g8";
                    prepare_to_move(g8);
                    break;

                case "h1":
                    from = "h1";
                    prepare_to_move(h1);
                    break;
                case "h2":
                    from = "h2";
                    prepare_to_move(h2);
                    break;
                case "h3":
                    from = "h3";
                    prepare_to_move(h3);
                    break;
                case "h4":
                    from = "h4";
                    prepare_to_move(h4);
                    break;
                case "h5":
                    from = "h5";
                    prepare_to_move(h5);
                    break;
                case "h6":
                    from = "h6";
                    prepare_to_move(h6);
                    break;
                case "h7":
                    from = "h7";
                    prepare_to_move(h7);
                    break;
                case "h8":
                    from = "h8";
                    prepare_to_move(h8);
                    break;
            }
            
        }
        void move_AI(string to)
        {
            richTextBox1.Text = "\nMoved to " + to + " FROM " + from;
            switch (to)
            {
                case "a1":
                    if (check)
                    {
                        make_move(a1);
                        change_names(from);
                        change_bg(to);
                        check = false;
                        update_king_pos(a1);
                    }
                    else
                    {
                        make_move(a1);
                        change_names(from);
                        checkmate(a1);
                    }
                    break;
                case "a2":
                    if (check)
                    {
                        make_move(a2);
                        change_names(from);
                        check = false;
                        update_king_pos(a2);
                    }
                    else
                    {
                        make_move(a2);
                        change_names(from);
                        checkmate(a2);
                    }
                    break;

                case "a3":
                    if (check)
                    {
                        make_move(a3);
                        change_names(from);
                        check = false;
                        update_king_pos(a3);

                    }
                    else
                    {
                        make_move(a3);
                        change_names(from);
                        checkmate(a3);
                    }
                    break;

                case "a4":
                    if (check)
                    {
                        make_move(a4);
                        change_names(from);
                        check = false;
                        update_king_pos(a4);
                    }
                    else
                    {
                        make_move(a4);
                        change_names(from);
                        checkmate(a4);
                    }
                    break;

                case "a5":
                    if (check)
                    {
                        make_move(a5);
                        change_names(from);
                        check = false;
                        update_king_pos(a5);
                    }
                    else
                    {
                        make_move(a5);
                        change_names(from);
                        checkmate(a5);
                    }
                    break;

                case "a6":
                    if (check)
                    {
                        make_move(a6);
                        change_names(from);
                        check = false;
                        update_king_pos(a6);
                    }
                    else
                    {
                        make_move(a6);
                        change_names(from);
                        checkmate(a6);
                    }
                    break;

                case "a7":
                    if (check)
                    {
                        make_move(a7);
                        change_names(from);
                        check = false;
                        update_king_pos(a7);
                    }
                    else
                    {
                        make_move(a7);
                        change_names(from);
                        checkmate(a7);
                    }
                    break;

                case "a8":
                    if (check)
                    {
                        make_move(a8);
                        change_names(from);
                        check = false;
                        update_king_pos(a8);
                    }
                    else
                    {
                        make_move(a8);
                        change_names(from);
                        checkmate(a8);
                    }
                    break;

                case "b1":
                    if (check)
                    {
                        make_move(b1);
                        change_names(from);
                        check = false;
                        update_king_pos(b1);
                    }
                    else
                    {
                        make_move(b1);
                        change_names(from);
                        checkmate(b1);
                    }
                    break;

                case "b2":
                    if (check)
                    {
                        make_move(b2);
                        change_names(from);
                        check = false;
                        update_king_pos(b2);
                    }
                    else
                    {
                        make_move(b2);
                        change_names(from);
                        checkmate(b2);
                    }
                    break;

                case "b3":
                    if (check)
                    {
                        make_move(b3);
                        change_names(from);
                        check = false;
                        update_king_pos(b3);
                    }
                    else
                    {
                        make_move(b3);
                        change_names(from);
                        checkmate(b3);
                    }
                    break;

                case "b4":
                    if (check)
                    {
                        make_move(b4);
                        change_names(from);
                        check = false;
                        update_king_pos(b4);
                    }
                    else
                    {
                        make_move(b4);
                        change_names(from);
                        checkmate(b4);
                    }
                    break;

                case "b5":
                    if (check)
                    {
                        make_move(b5);
                        change_names(from);
                        check = false;
                        update_king_pos(b5);
                    }
                    else
                    {
                        make_move(b5);
                        change_names(from);
                        checkmate(b5);
                    }
                    break;

                case "b6":
                    if (check)
                    {
                        make_move(b6);
                        change_names(from);
                        check = false;
                        update_king_pos(b6);
                    }
                    else
                    {
                        make_move(b6);
                        change_names(from);
                        checkmate(b6);
                    }
                    break;

                case "b7":
                    if (check)
                    {
                        make_move(b7);
                        change_names(from);
                        check = false;
                        update_king_pos(b7);
                    }
                    else
                    {
                        make_move(b7);
                        change_names(from);
                        checkmate(b7);
                    }
                    break;

                case "b8":
                    if (check)
                    {
                        make_move(b8);
                        change_names(from);
                        check = false;
                        update_king_pos(b8);
                    }
                    else
                    {
                        make_move(b8);
                        change_names(from);
                        checkmate(b8);
                    }
                    break;

                case "c1":
                    if (check)
                    {
                        make_move(c1);
                        change_names(from);
                        check = false;
                        update_king_pos(c1);
                    }
                    else
                    {
                        make_move(c1);
                        change_names(from);
                        checkmate(c1);
                    }
                    break;

                case "c2":
                    if (check)
                    {
                        make_move(c2);
                        change_names(from);
                        check = false;
                        update_king_pos(c2);
                    }
                    else
                    {
                        make_move(c2);
                        change_names(from);
                        checkmate(c2);
                    }
                    break;

                case "c3":
                    if (check)
                    {
                        make_move(c3);
                        change_names(from);
                        check = false;
                        update_king_pos(c3);
                    }
                    else
                    {
                        make_move(c3);
                        change_names(from);
                        checkmate(c3);
                    }
                    break;

                case "c4":
                    if (check)
                    {
                        make_move(c4);
                        change_names(from);
                        check = false;
                        update_king_pos(c4);
                    }
                    else
                    {
                        make_move(c4);
                        change_names(from);
                        checkmate(c4);
                    }
                    break;

                case "c5":
                    if (check)
                    {
                        make_move(c5);
                        change_names(from);
                        check = false;
                        update_king_pos(c5);
                    }
                    else
                    {
                        make_move(c5);
                        change_names(from);
                        checkmate(c5);
                    }
                    break;

                case "c6":
                    if (check)
                    {
                        make_move(c6);
                        change_names(from);
                        check = false;
                        update_king_pos(c6);
                    }
                    else
                    {
                        make_move(c6);
                        change_names(from);
                        checkmate(c6);
                    }
                    break;

                case "c7":
                    if (check)
                    {
                        make_move(c7);
                        change_names(from);
                        check = false;
                        update_king_pos(c7);
                    }
                    else
                    {
                        make_move(c7);
                        change_names(from);
                        checkmate(c7);
                    }
                    break;

                case "c8":
                    if (check)
                    {
                        make_move(c8);
                        change_names(from);
                        check = false;
                        update_king_pos(c8);
                    }
                    else
                    {
                        make_move(c8);
                        change_names(from);
                        checkmate(c8);
                    }
                    break;

                case "d1":
                    if (check)
                    {
                        make_move(d1);
                        change_names(from);
                        check = false;
                        update_king_pos(d1);
                    }
                    else
                    {
                        make_move(d1);
                        change_names(from);
                        checkmate(d1);
                    }
                    break;

                case "d2":
                    if (check)
                    {
                        make_move(d2);
                        change_names(from);
                        check = false;
                        update_king_pos(d2);
                    }
                    else
                    {
                        make_move(d2);
                        change_names(from);
                        checkmate(d2);
                    }
                    break;

                case "d3":
                    if (check)
                    {
                        make_move(d3);
                        change_names(from);
                        check = false;
                        update_king_pos(d3);
                    }
                    else
                    {
                        make_move(d3);
                        change_names(from);
                        checkmate(d3);
                    }
                    break;

                case "d4":
                    if (check)
                    {
                        make_move(d4);
                        change_names(from);
                        check = false;
                        update_king_pos(d4);
                    }
                    else
                    {
                        make_move(d4);
                        change_names(from);
                        checkmate(d4);
                    }
                    break;

                case "d5":
                    if (check)
                    {
                        make_move(d5);
                        change_names(from);
                        check = false;
                        update_king_pos(d5);
                    }
                    else
                    {
                        make_move(d5);
                        change_names(from);
                        checkmate(d5);
                    }
                    break;

                case "d6":
                    if (check)
                    {
                        make_move(d6);
                        change_names(from);
                        check = false;
                        update_king_pos(d6);
                    }
                    else
                    {
                        make_move(d6);
                        change_names(from);
                        checkmate(d6);
                    }
                    break;

                case "d7":
                    if (check)
                    {
                        make_move(d7);
                        change_names(from);
                        check = false;
                        update_king_pos(d7);
                    }
                    else
                    {
                        make_move(d7);
                        change_names(from);
                        checkmate(d7);
                    }
                    break;

                case "d8":
                    if (check)
                    {
                        make_move(d8);
                        change_names(from);
                        check = false;
                        update_king_pos(d8);
                    }
                    else
                    {
                        make_move(d8);
                        change_names(from);
                        checkmate(d8);
                    }
                    break;

                case "e1":
                    if (check)
                    {
                        make_move(e1);
                        change_names(from);
                        check = false;
                        update_king_pos(e1);
                    }
                    else
                    {
                        make_move(e1);
                        change_names(from);
                        checkmate(e1);
                    }
                    break;

                case "e2":
                    if (check)
                    {
                        make_move(e2);
                        change_names(from);
                        check = false;
                        update_king_pos(e2);
                    }
                    else
                    {
                        make_move(e2);
                        change_names(from);
                        checkmate(e2);
                    }
                    break;

                case "e3":
                    if (check)
                    {
                        make_move(e3);
                        change_names(from);
                        check = false;
                        update_king_pos(e3);
                    }
                    else
                    {
                        make_move(e3);
                        change_names(from);
                        checkmate(e3);
                    }
                    break;

                case "e4":
                    if (check)
                    {
                        make_move(e4);
                        change_names(from);
                        check = false;
                        update_king_pos(e4);
                    }
                    else
                    {
                        make_move(e4);
                        change_names(from);
                        checkmate(e4);
                    }
                    break;

                case "e5":
                    if (check)
                    {
                        make_move(e5);
                        change_names(from);
                        check = false;
                        update_king_pos(e5);
                    }
                    else
                    {
                        make_move(e5);
                        change_names(from);
                        checkmate(e5);
                    }
                    break;

                case "e6":
                    if (check)
                    {
                        make_move(e6);
                        change_names(from);
                        check = false;
                        update_king_pos(e6);
                    }
                    else
                    {
                        make_move(e6);
                        change_names(from);
                        checkmate(e6);
                    }
                    break;

                case "e7":
                    if (check)
                    {
                        make_move(e7);
                        change_names(from);
                        check = false;
                        update_king_pos(e7);
                    }
                    else
                    {
                        make_move(e7);
                        change_names(from);
                        checkmate(e7);
                    }
                    break;

                case "e8":
                    if (check)
                    {
                        make_move(e8);
                        change_names(from);
                        check = false;
                        update_king_pos(e8);
                    }
                    else
                    {
                        make_move(e8);
                        change_names(from);
                        checkmate(e8);
                    }
                    break;

                case "f1":
                    if (check)
                    {
                        make_move(f1);
                        change_names(from);
                        check = false;
                        update_king_pos(f1);
                    }
                    else
                    {
                        make_move(f1);
                        change_names(from);
                        checkmate(f1);
                    }
                    break;

                case "f2":
                    if (check)
                    {
                        make_move(f2);
                        change_names(from);
                        check = false;
                        update_king_pos(f2);
                    }
                    else
                    {
                        make_move(f2);
                        change_names(from);
                        checkmate(f2);
                    }
                    break;

                case "f3":
                    if (check)
                    {
                        make_move(f3);
                        change_names(from);
                        check = false;
                        update_king_pos(f3);
                    }
                    else
                    {
                        make_move(f3);
                        change_names(from);
                        checkmate(f3);
                    }
                    break;

                case "f4":
                    if (check)
                    {
                        make_move(f4);
                        change_names(from);
                        check = false;
                        update_king_pos(f4);
                    }
                    else
                    {
                        make_move(f4);
                        change_names(from);
                        checkmate(f4);
                    }
                    break;

                case "f5":
                    if (check)
                    {
                        make_move(f5);
                        change_names(from);
                        check = false;
                        update_king_pos(f5);
                    }
                    else
                    {
                        make_move(f5);
                        change_names(from);
                        checkmate(f5);
                    }
                    break;

                case "f6":
                    if (check)
                    {
                        make_move(f6);
                        change_names(from);
                        check = false;
                        update_king_pos(f6);
                    }
                    else
                    {
                        make_move(f6);
                        change_names(from);
                        checkmate(f6);
                    }
                    break;

                case "f7":
                    if (check)
                    {
                        make_move(f7);
                        change_names(from);
                        check = false;
                        update_king_pos(f7);
                    }
                    else
                    {
                        make_move(f7);
                        change_names(from);
                        checkmate(f7);
                    }
                    break;

                case "f8":
                    if (check)
                    {
                        make_move(f8);
                        change_names(from);
                        check = false;
                        update_king_pos(f8);
                    }
                    else
                    {
                        make_move(f8);
                        change_names(from);
                        checkmate(f8);
                    }
                    break;

                case "g1":
                    if (check)
                    {
                        make_move(g1);
                        change_names(from);
                        check = false;
                        update_king_pos(g1);
                    }
                    else
                    {
                        make_move(g1);
                        change_names(from);
                        checkmate(g1);
                    }
                    break;

                case "g2":
                    if (check)
                    {
                        make_move(g2);
                        change_names(from);
                        check = false;
                        update_king_pos(g2);
                    }
                    else
                    {
                        make_move(g2);
                        change_names(from);
                        checkmate(g2);
                    }
                    break;

                case "g3":
                    if (check)
                    {
                        make_move(g3);
                        change_names(from);
                        check = false;
                        update_king_pos(g3);
                    }
                    else
                    {
                        make_move(g3);
                        change_names(from);
                        checkmate(g3);
                    }
                    break;

                case "g4":
                    if (check)
                    {
                        make_move(g_4);
                        change_names(from);
                        check = false;
                        update_king_pos(g_4);
                    }
                    else
                    {
                        make_move(g_4);
                        change_names(from);
                        checkmate(g_4);
                    }
                    break;

                case "g5":
                    if (check)
                    {
                        make_move(g5);
                        change_names(from);
                        check = false;
                        update_king_pos(g5);
                    }
                    else
                    {
                        make_move(g5);
                        change_names(from);
                        checkmate(g5);
                    }
                    break;

                case "g6":
                    if (check)
                    {
                        make_move(g6);
                        change_names(from);
                        check = false;
                        update_king_pos(g6);
                    }
                    else
                    {
                        make_move(g6);
                        change_names(from);
                        checkmate(g6);
                    }
                    break;

                case "g7":
                    if (check)
                    {
                        make_move(g7);
                        change_names(from);
                        check = false;
                        update_king_pos(g7);
                    }
                    else
                    {
                        make_move(g7);
                        change_names(from);
                        checkmate(g7);
                    }
                    break;

                case "g8":
                    if (check)
                    {
                        make_move(g8);
                        change_names(from);
                        check = false;
                        update_king_pos(g8);
                    }
                    else
                    {
                        make_move(g8);
                        change_names(from);
                        checkmate(g8);
                    }
                    break;

                case "h1":
                    if (check)
                    {
                        make_move(h1);
                        change_names(from);
                        check = false;
                        update_king_pos(h1);
                    }
                    else
                    {
                        make_move(h1);
                        change_names(from);
                        checkmate(h1);
                    }
                    break;

                case "h2":
                    if (check)
                    {
                        make_move(h2);
                        change_names(from);
                        check = false;
                        update_king_pos(h2);
                    }
                    else
                    {
                        make_move(h2);
                        change_names(from);
                        checkmate(h2);
                    }
                    break;

                case "h3":
                    if (check)
                    {
                        make_move(h3);
                        change_names(from);
                        check = false;
                        update_king_pos(h3);
                    }
                    else
                    {
                        make_move(h3);
                        change_names(from);
                        checkmate(h3);
                    }
                    break;

                case "h4":
                    if (check)
                    {
                        make_move(h4);
                        change_names(from);
                        check = false;
                        update_king_pos(h4);
                    }
                    else
                    {
                        make_move(h4);
                        change_names(from);
                        checkmate(h4);
                    }
                    break;

                case "h5":
                    if (check)
                    {
                        make_move(h5);
                        change_names(from);
                        check = false;
                        update_king_pos(h5);
                    }
                    else
                    {
                        make_move(h5);
                        change_names(from);
                        checkmate(h5);
                    }
                    break;

                case "h6":
                    if (check)
                    {
                        make_move(h6);
                        change_names(from);
                        check = false;
                        update_king_pos(h6);
                    }
                    else
                    {
                        make_move(h6);
                        change_names(from);
                        checkmate(h6);
                    }
                    break;

                case "h7":
                    if (check)
                    {
                        make_move(h7);
                        change_names(from);
                        check = false;
                        update_king_pos(h7);
                    }
                    else
                    {
                        make_move(h7);
                        change_names(from);
                        checkmate(h7);
                    }
                    break;

                case "h8":
                    if (check)
                    {
                        make_move(h8);
                        change_names(from);
                        check = false;
                        update_king_pos(h8);
                    }
                    else
                    {
                        make_move(h8);
                        change_names(from);
                        checkmate(h8);
                    }
                    break;

            }
        }
        void max_piece(string a)
        {
            
            switch (a)
            {
                case "pawn_white_white":
                    prep_move_AI(pawn_w.Position);
                    break;
                case "pawn_white_black":
                    prep_move_AI(pawn_w_b.Position);
                    break;
                case "rook_white_white":
                    prep_move_AI(rook_w.Position);
                    break;
                case "rook_white_black":
                    prep_move_AI(rook_w_b.Position);
                    break;
                case "bishop_white_white":
                    prep_move_AI(bishop_w.Position);
                    break;
                case "bishop_white_black":
                    prep_move_AI(bishop_w_b.Position);
                    break;
                case "queen_white":
                    prep_move_AI(queen_w.Position);
                    break;
                case "horse_white_white":
                    prep_move_AI(horse_w.Position);
                    break;
                case "horse_white_black":
                    prep_move_AI(horse_w_b.Position);
                    break;
                case "king_white":
                    prep_move_AI(king_w.Position);
                    break;

            }
        }
        private void calculate_AI(int a)
        {
            switch (a)
            {
                case 1:
                    if (names.Contains("pawn_black_black"))
                    {
                        max_piece(max_piece_name);
                        move_AI(pawnn.Position);
                    }
                    else
                    {
                        max_piece(max_piece_name);
                        move_AI(pawn_b_w.Position);
                    }
                        
                    break;

                    case 2:
                    if (names.Contains("rook_black_black"))
                    {
                        max_piece(max_piece_name);
                        move_AI(rook.Position);
                    }
                    else
                    {
                        max_piece(max_piece_name);
                        move_AI(rook_b_w.Position);
                    }
                    break;
                case 3:
                    if (names.Contains("horse_black_black"))
                    {
                        max_piece(max_piece_name);
                        move_AI(horse.Position);
                    }
                    else
                    {
                        max_piece(max_piece_name);
                        move_AI(horse_b_w.Position);
                    }
                    break;
                case 5:
                    if (names.Contains("bishop_black_black"))
                    {
                        max_piece(max_piece_name);
                        move_AI(bishopp.Position);
                    }

                    else
                    {
                        max_piece(max_piece_name);
                        move_AI(bishop_b_w.Position);
                    }
                        
                    break;
                case 6:
                    max_piece(max_piece_name);
                    move_AI(queen.Position);
                    break;
                case 69:
                    max_piece(max_piece_name);
                    move_AI(king.Position);
                    break;
            }
        }       //Receives the maximum point that can be obtained by a move and then makes a move.
        private void minmax()
        {
            int i = 0;
            max_p.Clear();
            names.Clear();
            if (count <= 21)
            {
                if (count == 21)
                {
                    from = "a8";
                    prepare_to_move(a8);
                    make_move(a6);
                    change_names(from);
                }
                if (count == 19)
                {
                    pawn_w_b.Position = "a7";
                    from = "a7";
                    prepare_to_move(a7);
                    make_move(a5);
                    change_names(from);
                }
                if (count == 17)
                {
                    from = "e8";
                    prepare_to_move(e8);
                    make_move(f8);
                    change_names(from);
                }
                if (count == 15)
                {
                    from = "f8";
                    prepare_to_move(f8);
                    make_move(d6);
                    change_names(from);
                }
                if (count == 13)
                {
                    pawn_w.Position = "h7";
                    from = "h7";
                    prepare_to_move(h7);
                    make_move(h5);
                    change_names(from);

                }
                if (count == 11)
                {
                    from = "g8";
                    prepare_to_move(g8);
                    make_move(f6);
                    change_names(from);

                }
                if (count == 9)
                {
                    from = "e7";
                    pawn_w_b.Position = "e7";
                    prepare_to_move(e7);
                    make_move(e5);
                    change_names(from);
                }
                if (count == 7)
                {
                    horse_w_b.Position = "b8";
                    from = "b8";
                    prepare_to_move(b8);
                    make_move(c6);
                    change_names(from);
                }
                if (count == 5)
                {
                    from = "d5";
                    prepare_to_move(d5);
                    make_move(d4);
                    change_names(from);
                }
                if (count == 3)
                {
                    pawn_w_b.Position = "c7";
                    from = "c7";
                    prepare_to_move(c7);
                    make_move(c5);
                    change_names(from);
                }
                if (count == 1)
                {
                    pawn_w.Position = "d7";
                    from = "d7";
                    prepare_to_move(d7);
                    make_move(d5);
                    change_names(from);
                }
           }
                

            
            else
            {
                from = pawn_w.Position;
                add_move("pawn_white_white", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                max_piece_name = "pawn_white_white";
                i = max_p.Max();
                from = pawn_w_b.Position;
                add_move("pawn_white_black", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "pawn_white_black";
                }
                from = horse_w_b.Position;
                add_move("horse_white_black", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "horse_white_black";
                }
                from = horse_w.Position;
                add_move("horse_white_white", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "horse_white_white";
                }
                from = bishop_w_b.Position;
                add_move("bishop_white_black", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {

                    i = max_p.Max();
                    max_piece_name = "bishop_white_black";
                }
                from = bishop_w.Position;
                add_move("bishop_white_white", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "bishop_white_white";
                }
                from = rook_w_b.Position;
                add_move("rook_white_black", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "rook_white_black";
                }
                from = rook_w.Position;
                add_move("rook_white_white", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "rook_white_white";
                }
                from = queen_w.Position;
                add_move("queen_white", true);
                foreach (string str in moves)
                {
                    max_p.Add(get_name(str));
                }
                if (i < max_p.Max())
                {
                    i = max_p.Max();
                    max_piece_name = "queen_white";
                }

                richTextBox1.Text += "\nMaximum points: " + i + " by moving " + max_piece_name;
                calculate_AI(i);
            }
        }       //contains the logic for moving the pieces according to presets. It calculates valid moves for all the existing pieces of black.Furthermore, it also calls the functions used for setting the points for every piece. It passes the maximum of those pointsto Calculate_AI() function.
        private void checkmate(PictureBox temporary)
        {
            from = temporary.Name;
            add_move(temporary.AccessibleName, true);

            if (temporary.AccessibleDescription == "white")
            {
                if (moves.Contains(king.Position))
                {
                    king_pos = king.Position;
                    check = true;
                    change_king_colour(king.Position);
                    from = king.Position;
                    add_move("king_black", true);
                    if (moves.Count == 0)
                    {
                        MessageBox.Show("Checkmate!");
                        Close();
                    }

                }
                else
                    moves.Clear();
            }
            if (temporary.AccessibleDescription == "black")
            {
                if (moves.Contains(king_w.Position))
                {
                    king_pos = king_w.Position;
                    check = true;       
                    change_king_colour(king_w.Position);                          
                    from = king_w.Position;
                    add_move("king_white");
                    if (moves.Count == 0)
                    {
                        MessageBox.Show("Checkmate!");
                        Close();
                    }

                }
                else
                    moves.Clear();
            }
        }
        
        //Click events for each picturebox
        private void a1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("a1"))
            {
                if (check)
                {
                    make_move(a1);
                    change_names(from);
                    check = false;
                    update_king_pos(a1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a1";
                    }
                }
                else
                {
                    make_move(a1);
                    change_names(from);
                    checkmate(a1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a1";
                    }                

                    

                }
            }
            else
            {
                if (!check)
                {
                    if (check_for_turn(a1.AccessibleDescription) || king_pos == "a1")
                    {
                        from = "a1";
                        prepare_to_move(a1);
                    }
                }

            }
        }
        private void a2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("a2"))
            {
                if (check)
                {
                    make_move(a2);
                    change_names(from);
                    check = false;
                    update_king_pos(a2);
                    richTextBox1.Text += "\nMove: "  + piece_name + " to: a2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a2";
                    }

                }
                else
                {
                    make_move(a2);
                    change_names(from); ;
                    checkmate(a2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a2";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a2")
                {
                    if (check_for_turn(a2.AccessibleDescription))
                    {
                        from = "a2";
                        prepare_to_move(a2);
                    }
                }

            }
        }
        private void a3_Click(object sender, EventArgs e)
        {

            if (moves.Contains("a3"))
            {
                if (check)
                {
                    make_move(a3);
                    change_names(from);
                    check = false;
                    update_king_pos(a3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a3";
                    }
                }
                else
                {
                    make_move(a3);
                    change_names(from); ;
                    checkmate(a3);
                    richTextBox1.Text += "\nMove: " +piece_name + " to: a3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a3";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a3")
                {
                    if (check_for_turn(a3.AccessibleDescription))
                    {
                        from = "a3";
                        prepare_to_move(a3);
                    }
                }

            }
        }
        private void a4_Click(object sender, EventArgs e)
        {

            if (moves.Contains("a4"))
            {
                if (check)
                {
                    make_move(a4);
                    change_names(from);
                    check = false;
                    update_king_pos(a4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a4";
                    }
                }
                else
                {
                    make_move(a4);
                    change_names(from);
                    checkmate(a4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a4";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a4")
                {
                    if (check_for_turn(a4.AccessibleDescription))
                    {
                        from = "a4";
                        prepare_to_move(a4);
                    }
                }

            }

        }
        private void a5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("a5"))
            {
                if (check)
                {
                    make_move(a5);
                    change_names(from);
                    check = false;
                    update_king_pos(a5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a5";
                    }
                }
                else
                {
                    make_move(a5);
                    change_names(from);
                    checkmate(a5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a5";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a5")
                {
                    if (check_for_turn(a5.AccessibleDescription))
                    {
                        from = "a5";
                        prepare_to_move(a5);
                    }
                }

            }
        }
        private void a6_Click(object sender, EventArgs e)
        {

            if (moves.Contains("a6"))
            {
                if (check)
                {
                    make_move(a6);
                    change_names(from);
                    check = false;
                    update_king_pos(a6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a6";
                    }
                }
                else
                {
                    make_move(a6);
                    change_names(from); ;
                    checkmate(a6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a6";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a6")
                {
                    if (check_for_turn(a6.AccessibleDescription))
                    {
                        from = "a6";
                        prepare_to_move(a6);
                    }
                }

            }

        }
        private void a7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("a7"))
            {
                if (check)
                {
                    make_move(a7);
                    change_names(from);
                    check = false;
                    update_king_pos(a7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a7";
                    }
                }
                else
                {
                    make_move(a7);
                    change_names(from); ;
                    checkmate(a7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a7";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a7")
                {
                    if (check_for_turn(a7.AccessibleDescription))
                    {
                        from = "a7";
                        prepare_to_move(a7);
                    }
                }

            }
        }
        private void a8_Click(object sender, EventArgs e)
        {

            if (moves.Contains("a8"))
            {
                if (check)
                {
                    make_move(a8);
                    change_names(from);
                    update_king_pos(a8);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a8";
                    }
                }
                else
                {
                    make_move(a8);
                    change_names(from); ;
                    checkmate(a8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: a8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: a8";
                    }

                }
            }
            else
            {
                if (!check || king_pos == "a8")
                {
                    if (check_for_turn(a8.AccessibleDescription))
                    {
                        from = "a8";
                        prepare_to_move(a8);
                    }
                }

            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b1"))
            {
                if (check)
                {
                    make_move(b1);
                    change_names(from);
                    check = false;
                    update_king_pos(b1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b1";
                    }
                }
                else
                {
                    make_move(b1);
                    change_names(from); ;
                    checkmate(b1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b1")
                {
                    if (check_for_turn(b1.AccessibleDescription))
                    {
                        from = "b1";
                        prepare_to_move(b1);
                    }
                }

            }
        }
        private void b2_Click(object sender, EventArgs e)
        {

            if (moves.Contains("b2"))
            {
                if (check)
                {
                    make_move(b2);
                    change_names(from);
                    check = false;
                    update_king_pos(b2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b2";
                    }
                }
                else
                {
                    make_move(b2);
                    change_names(from); ;
                    checkmate(b2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b2")
                {
                    if (check_for_turn(b2.AccessibleDescription))
                    {
                        from = "b2";
                        prepare_to_move(b2);
                    }
                }

            }
        }
        private void b3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b3"))
            {
                if (check)
                {
                    make_move(b3);
                    change_names(from);
                    check = false;
                    update_king_pos(b3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b3";
                    }
                }
                else
                {
                    make_move(b3);
                    change_names(from); ;
                    checkmate(b3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b3";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b3")
                {
                    if (check_for_turn(b3.AccessibleDescription))
                    {
                        from = "b3";
                        prepare_to_move(b3);
                    }
                }

            }
        }
        private void b4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b4"))
            {
                if (check)
                {
                    make_move(b4);
                    change_names(from);
                    check = false;
                    update_king_pos(b4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b4";
                    }
                }
                else
                {
                    make_move(b4);
                    change_names(from); ;
                    checkmate(b4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b4")
                {
                    if (check_for_turn(b4.AccessibleDescription))
                    {
                        from = "b4";
                        prepare_to_move(b4);
                    }
                }

            }
        }
        private void b5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b5"))
            {
                if (check)
                {
                    make_move(b5);
                    change_names(from);
                    check = false;
                    update_king_pos(b5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b5";
                    }
                }
                else
                {
                    make_move(b5);
                    change_names(from);
                    checkmate(b5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b5")
                {
                    if (check_for_turn(b5.AccessibleDescription))
                    {
                        from = "b5";
                        prepare_to_move(b5);
                    }
                }

            }
        }
        private void b6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b6"))
            {
                if (check)
                {
                    make_move(b6);
                    change_names(from);
                    check = false;
                    update_king_pos(b6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b6";
                    }
                }
                else
                {
                    make_move(b6);
                    change_names(from); ;
                    checkmate(b6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b6")
                {
                    if (check_for_turn(b6.AccessibleDescription))
                    {
                        from = "b6";
                        prepare_to_move(b6);
                    }
                }

            }
        }
        private void b7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b7"))
            {
                if (check)
                {
                    make_move(b7);
                    change_names(from);
                    check = false;
                    update_king_pos(b7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b7";
                    }
                }
                else
                {
                    make_move(b7);
                    change_names(from);
                    checkmate(b7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b7")
                {
                    if (check_for_turn(b7.AccessibleDescription))
                    {
                        from = "b7";
                        prepare_to_move(b7);
                    }
                }

            }
        }
        private void b8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("b8"))
            {
                if (check)
                {
                    make_move(b8);
                    change_names(from);
                    check = false;
                    update_king_pos(b8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b8";
                    }
                }
                else
                {
                    make_move(b8);
                    change_names(from); ;
                    checkmate(b8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: b8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: b8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "b8")
                {
                    if (check_for_turn(b8.AccessibleDescription))
                    {
                        from = "b8";
                        prepare_to_move(b8);
                    }
                }

            }
        }

        private void c1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c1"))
            {
                if (check)
                {
                    make_move(c1);
                    change_names(from);
                    check = false;
                    update_king_pos(c1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c1";
                    }
                }
                else
                {
                    make_move(c1);
                    change_names(from); ;
                    checkmate(c1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c1")
                {
                    if (check_for_turn(c1.AccessibleDescription))
                    {
                        from = "c1";
                        prepare_to_move(c1);
                    }
                }

            }
        }
        private void c2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c2"))
            {
                if (check)
                {
                    make_move(c2);
                    change_names(from);
                    check = false;
                    update_king_pos(c2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c2";
                    }
                }
                else
                {
                    make_move(c2);
                    change_names(from); ;
                    checkmate(c2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c2")
                {
                    if (check_for_turn(c2.AccessibleDescription))
                    {
                        from = "c2";
                        prepare_to_move(c2);
                    }
                }

            }

        }
        private void c3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c3"))
            {
                if (check)
                {
                    make_move(c3);
                    change_names(from);
                    check = false;
                    update_king_pos(c3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c3";
                    }
                }
                else
                {
                    make_move(c3);
                    change_names(from); 
                    checkmate(c3);                 
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c3";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c3")
                {
                    if (check_for_turn(c3.AccessibleDescription))
                    {
                        from = "c3";
                        prepare_to_move(c3);
                    }
                }

            }
        }
        private void c4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c4"))
            {
                if (check)
                {
                    make_move(c4);
                    change_names(from);
                    check = false;
                    update_king_pos(c4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c4";
                    }
                }
                else
                {
                    make_move(c4);
                    change_names(from); ;
                    checkmate(c4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c4")
                {
                    if (check_for_turn(c4.AccessibleDescription))
                    {
                        from = "c4";
                        prepare_to_move(c4);
                    }
                }

            }
        }
        private void c5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c5"))
            {
                if (check)
                {
                    make_move(c5);
                    change_names(from);
                    check = false;
                    update_king_pos(c5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c5";
                    }
                }
                else
                {
                    make_move(c5);
                    change_names(from); ;
                    checkmate(c5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c5")
                {
                    if (check_for_turn(c5.AccessibleDescription))
                    {
                        from = "c5";
                        prepare_to_move(c5);
                    }
                }

            }
        }
        private void c6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c6"))
            {
                if (check)
                {
                    make_move(c6);
                    change_names(from);
                    check = false;
                    update_king_pos(c6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c6";
                    }
                }
                else
                {
                    make_move(c6);
                    change_names(from); ;
                    checkmate(c6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c6")
                {
                    if (check_for_turn(c6.AccessibleDescription))
                    {
                        from = "c6";
                        prepare_to_move(c6);
                    }
                }

            }
        }
        private void c7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c7"))
            {
                if (check)
                {
                    make_move(c7);
                    change_names(from);
                    check = false;
                    update_king_pos(c7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c7";
                    }
                }
                else
                {
                    make_move(c7);
                    change_names(from); 
                    checkmate(c7);        
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c7")
                {
                    if (check_for_turn(c7.AccessibleDescription))
                    {
                        from = "c7";
                        prepare_to_move(c7);
                    }
                }

            }
        }
        private void c8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("c8"))
            {
                if (check)
                {
                    make_move(c8);
                    change_names(from);
                    check = false;
                    update_king_pos(c8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c8";
                    }
                }
                else
                {
                    make_move(c8);
                    change_names(from); ;
                    checkmate(c8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: c8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: c8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "c8")
                {
                    if (check_for_turn(c8.AccessibleDescription))
                    {
                        from = "c8";
                        prepare_to_move(c8);
                    }
                }

            }
        }

        private void d1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d1"))
            {
                if (check)
                {
                    make_move(d1);
                    change_names(from);
                    check = false;
                    update_king_pos(c7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d1";
                    }
                }
                else
                {
                    make_move(d1);
                    change_names(from); ;
                    checkmate(d1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d1")
                {
                    if (check_for_turn(d1.AccessibleDescription))
                    {
                        from = "d1";
                        prepare_to_move(d1);
                    }
                }

            }

        }
        private void d2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d2"))
            {
                if (check)
                {
                    make_move(d2);
                    change_names(from);
                    check = false;
                    update_king_pos(d2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d2";
                    }
                }
                else
                {
                    make_move(d2);
                    change_names(from); ;
                    checkmate(d2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d2")
                {
                    if (check_for_turn(d2.AccessibleDescription))
                    {
                        from = "d2";
                        prepare_to_move(d2);
                    }
                }

            }
        }
        private void d3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d3"))
            {
                if (check)
                {
                    make_move(d3);
                    change_names(from);
                    check = false;
                    update_king_pos(d3);
                    
                    if (AI_mode)
                        minmax();
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d3";
                }
                else
                {
                    make_move(d3);
                    change_names(from); ;
                    checkmate(d3);
                    if (AI_mode)
                        minmax();
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d3";
                }
            }
            else
            {
                if (!check || king_pos == "d3")
                {
                    if (check_for_turn(d3.AccessibleDescription))
                    {
                        from = "d3";
                        prepare_to_move(d3);
                    }
                }

            }

        }
        private void d4_Click(object sender, EventArgs e)
        {

            if (moves.Contains("d4"))
            {
                if (check)
                {
                    make_move(d4);
                    change_names(from);
                    check = false;
                    update_king_pos(d4);
                  
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d4";
                    }
                }
                else
                {
                    make_move(d4);
                    change_names(from); ;
                    checkmate(d4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d4")
                {
                    if (check_for_turn(d4.AccessibleDescription))
                    {
                        from = "d4";
                        prepare_to_move(d4);
                    }
                }

            }

        }
        private void d5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d5"))
            {
                if (check)
                {
                    make_move(d5);
                    change_names(from);
                    check = false;
                    update_king_pos(d5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d5";
                    }
                }
                else
                {
                    make_move(d5);
                    change_names(from); ;
                    checkmate(d5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d5")
                {
                    if (check_for_turn(d5.AccessibleDescription))
                    {
                        from = "d5";
                        prepare_to_move(d5);
                    }
                }

            }
        }
        private void d6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d6"))
            {
                if (check)
                {
                    make_move(d6);
                    change_names(from);
                    check = false;
                    update_king_pos(d6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d6";
                    }
                }
                else
                {
                    make_move(d6);
                    change_names(from); ;
                    checkmate(d6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d6")
                {
                    if (check_for_turn(d6.AccessibleDescription))
                    {
                        from = "d6";
                        prepare_to_move(d6);
                    }
                }

            }

        }
        private void d7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d7"))
            {
                if (check)
                {
                    make_move(d7);
                    change_names(from);
                    check = false;
                    update_king_pos(d7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d7";
                    }
                }
                else
                {
                    make_move(d7);
                    change_names(from);
                    checkmate(d7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d7")
                {
                    if (check_for_turn(d7.AccessibleDescription))
                    {
                        from = "d7";
                        prepare_to_move(d7);
                    }
                }

            }
        }
        private void d8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("d8"))
            {
                if (check)
                {
                    make_move(d8);
                    change_names(from);
                    check = false;
                    update_king_pos(d8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d8";
                    }
                }
                else
                {
                    make_move(d8);
                    change_names(from);
                    checkmate(d8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: d8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: d8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "d8")
                {
                    if (check_for_turn(d8.AccessibleDescription))
                    {
                        from = "d8";
                        prepare_to_move(d8);
                    }
                }

            }
        }

        private void e1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e1"))
            {
                if (check)
                {
                    make_move(e1);
                    change_names(from);
                    update_king_pos(e1);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e1";
                    }
                }
                else
                {
                    make_move(e1);
                    change_names(from);
                    checkmate(e1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e1")
                {
                    if (check_for_turn(e1.AccessibleDescription))
                    {
                        from = "e1";
                        prepare_to_move(e1);
                    }
                }

            }

        }
        private void e2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e2"))
            {
                if (check)
                {
                    make_move(e2);
                    change_names(from);
                    update_king_pos(e2);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e2";
                    }
                }
                else
                {
                    make_move(e2);
                    change_names(from);
                    checkmate(e2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e2")
                {
                    if (check_for_turn(e2.AccessibleDescription))
                    {
                        from = "e2";
                        prepare_to_move(e2);
                    }
                }

            }
        }
        private void e3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e3"))
            {
                if (check)
                {
                    make_move(e3);
                    change_names(from);
                    update_king_pos(e3);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e3";
                    }
                }
                else
                {
                    make_move(e3);
                    change_names(from);
                    checkmate(e3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e3";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e3")
                {
                    if (check_for_turn(e3.AccessibleDescription))
                    {
                        from = "e3";
                        prepare_to_move(e3);
                    }
                }

            }
        }
        private void e4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e4"))
            {
                if (check)
                {
                    make_move(e4);
                    change_names(from);
                    check = false;
                    update_king_pos(e4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e4";
                    }
                }
                else
                {
                    make_move(e4);
                    change_names(from); ;
                    checkmate(e4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e1]4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e4")
                {
                    if (check_for_turn(e4.AccessibleDescription))
                    {
                        from = "e4";
                        prepare_to_move(e4);
                    }
                }

            }
        }
        private void e5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e5"))
            {
                if (check)
                {
                    make_move(e5);
                    change_names(from);
                    check = false;
                    update_king_pos(e5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e5";
                    }
                }
                else
                {
                    make_move(e5);
                    change_names(from); ;
                    checkmate(e5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e5")
                {
                    if (check_for_turn(e5.AccessibleDescription))
                    {
                        from = "e5";
                        prepare_to_move(e5);
                    }
                }

            }
        }
        private void e6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e6"))
            {
                if (check)
                {
                    make_move(e6);
                    change_names(from);
                    check = false;
                    update_king_pos(e6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e6";
                    }
                }
                else
                {
                    make_move(e6);
                    change_names(from); ;
                    checkmate(e6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e6")
                {
                    if (check_for_turn(e6.AccessibleDescription))
                    {
                        from = "e6";
                        prepare_to_move(e6);
                    }
                }

            }
        }
        private void e7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e7"))
            {
                if (check)
                {
                    make_move(e7);
                    change_names(from);
                    check = false; update_king_pos(e7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e7";
                    }
                }
                else
                {
                    make_move(e7);
                    change_names(from); ;
                    checkmate(e7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e7")
                {
                    if (check_for_turn(e7.AccessibleDescription))
                    {
                        from = "e7";
                        prepare_to_move(e7);
                    }
                }

            }
        }
        private void e8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("e8"))
            {
                if (check)
                {
                    make_move(e8);
                    change_names(from);
                    check = false;
                    update_king_pos(e8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e8";
                    }
                }
                else
                {
                    make_move(e8);
                    change_names(from); ;
                    checkmate(e8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: e8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: e8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "e8")
                {
                    if (check_for_turn(e8.AccessibleDescription))
                    {
                        from = "e8";
                        prepare_to_move(e8);
                    }
                }

            }
        }

        private void f1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f1"))
            {
                if (check)
                {
                    make_move(f1);
                    change_names(from);
                    update_king_pos(f1);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f1";
                    }
                }
                else
                {
                    make_move(f1);
                    change_names(from);
                    checkmate(f1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f1")
                {
                    if (check_for_turn(f1.AccessibleDescription))
                    {
                        from = "f1";
                        prepare_to_move(f1);
                    }
                }

            }
        }
        private void f2_Click(object sender, EventArgs e)
        {

            if (moves.Contains("f2"))
            {
                if (check)
                {
                    make_move(f2);
                    change_names(from);
                    check = false;
                    update_king_pos(f2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f2";
                    }
                }
                else
                {
                    make_move(f2);
                    change_names(from); ;
                    checkmate(f2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f2")
                {
                    if (check_for_turn(f2.AccessibleDescription))
                    {
                        from = "f2";
                        prepare_to_move(f2);
                    }
                }

            }
        }
        private void f3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f3"))
            {
                if (check)
                {
                    make_move(f3);
                    change_names(from);
                    check = false;
                    update_king_pos(f3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f3";
                    }
                }
                else
                {
                    make_move(f3);
                    change_names(from); ;
                    checkmate(f3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f3";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f3")
                {
                    if (check_for_turn(f3.AccessibleDescription))
                    {
                        from = "f3";
                        prepare_to_move(f3);
                    }
                }

            }
        }
        private void f4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f4"))
            {
                if (check)
                {
                    make_move(f4);
                    change_names(from);
                    check = false;
                    update_king_pos(f4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f4";
                    }
                }
                else
                {
                    make_move(f4);
                    change_names(from); ;
                    checkmate(f4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f4")
                {
                    if (check_for_turn(f4.AccessibleDescription))
                    {
                        from = "f4";
                        prepare_to_move(f4);
                    }
                }

            }
        }
        private void f5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f5"))
            {
                if (check)
                {
                    make_move(f5);
                    change_names(from);
                    check = false;
                    update_king_pos(f5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f5";
                    }
                }
                else
                {
                    make_move(f5);
                    change_names(from); 
                    checkmate(f5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: 5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f5")
                {
                    if (check_for_turn(f5.AccessibleDescription))
                    {
                        from = "f5";
                        prepare_to_move(f5);
                    }
                }

            }
        }
        private void f6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f6"))
            {
                if (check)
                {
                    make_move(f6);
                    change_names(from);
                    check = false;
                    update_king_pos(f6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f6";
                    }
                }
                else
                {
                    make_move(f6);
                    change_names(from); ;
                    checkmate(f6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f6")
                {
                    if (check_for_turn(f6.AccessibleDescription))
                    {
                        from = "f6";
                        prepare_to_move(f6);
                    }
                }

            }
        }
        private void f7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f7"))
            {
                if (check)
                {
                    make_move(f7);
                    change_names(from);
                    check = false;
                    update_king_pos(f7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f7";
                    }
                }
                else
                {
                    make_move(f7);
                    change_names(from); ;
                    checkmate(f7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f7")
                {
                    if (check_for_turn(f7.AccessibleDescription))
                    {
                        from = "f7";
                        prepare_to_move(f7);
                    }
                }

            }
        }
        private void f8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("f8"))
            {
                if (check)
                {
                    make_move(f8);
                    change_names(from);
                    check = false;
                    update_king_pos(f8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f8";
                    }
                }
                else
                {
                    make_move(f8);
                    change_names(from);
                    checkmate(f8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: f8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: f8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "f8")
                {
                    if (check_for_turn(f8.AccessibleDescription))
                    {
                        from = "f8";
                        prepare_to_move(f8);
                    }
                }

            }
        }

        private void g1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g1"))
            {
                if (check)
                {
                    make_move(g1);
                    change_names(from);
                    check = false;
                    update_king_pos(g1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g1";

                    }
                }
                else
                {
                    make_move(g1);
                    change_names(from); ;
                    checkmate(g1);
                    if (AI_mode)
                        minmax();
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g1")
                {
                    if (check_for_turn(g1.AccessibleDescription))
                    {
                        from = "g1";
                        prepare_to_move(g1);
                    }
                }

            }
        }
        private void g2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g2"))
            {
                if (check)
                {
                    make_move(g2);
                    change_names(from);
                    check = false;
                    update_king_pos(g2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g2";
                    }
                }
                else
                {
                    make_move(g2);
                    change_names(from); ;
                    checkmate(g2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g2")
                {
                    if (check_for_turn(g2.AccessibleDescription))
                    {
                        from = "g2";
                        prepare_to_move(g2);
                    }
                }

            }
        }
        private void g3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g3"))
            {
                if (check)
                {
                    make_move(g3);
                    change_names(from);
                    check = false;
                    update_king_pos(g3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g3";
                    }
                }
                else
                {
                    make_move(g3);
                    change_names(from); ;
                    checkmate(g3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g3";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g3";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g3")
                {
                    if (check_for_turn(g3.AccessibleDescription))
                    {
                        from = "g3";
                        prepare_to_move(g3);
                    }
                }

            }
        }
        private void g_4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g4"))
            {
                if (check)
                {
                    make_move(g_4);
                    change_names(from);
                    check = false;
                    update_king_pos(g4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g4";
                    }
                }
                else
                {
                    make_move(g_4);
                    change_names(from); ;
                    checkmate(g_4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g_4")
                {
                    if (check_for_turn(g_4.AccessibleDescription))
                    {
                        from = "g4";
                        prepare_to_move(g_4);
                    }
                }

            }
        }
        private void g5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g5"))
            {
                if (check)
                {
                    make_move(g5);
                    change_names(from); ;
                    check = false;
                    update_king_pos(g5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g5";
                    }
                }
                else
                {
                    make_move(g5);
                    change_names(from);
                    checkmate(g5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g5")
                {
                    if (check_for_turn(g5.AccessibleDescription))
                    {
                        from = "g5";
                        prepare_to_move(g5);
                    }
                }

            }
        }
        private void g6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g6"))
            {
                if (check)
                {
                    make_move(g6);
                    change_names(from);
                    check = false;
                    update_king_pos(g6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g6";
                    }
                }
                else
                {
                    make_move(g6);
                    change_names(from); ;
                    checkmate(g6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g6")
                {
                    if (check_for_turn(g6.AccessibleDescription))
                    {
                        from = "g6";
                        prepare_to_move(g6);
                    }
                }

            }
        }
        private void g7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g7"))
            {
                if (check)
                {
                    make_move(g7);
                    change_names(from);
                    check = false;
                    update_king_pos(g7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g7";
                    }
                }
                else
                {
                    make_move(g7);
                    change_names(from); ;
                    checkmate(g7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g7")
                {
                    if (check_for_turn(g7.AccessibleDescription))
                    {
                        from = "g7";
                        prepare_to_move(g7);
                    }
                }

            }
        }
        private void g8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("g8"))
            {
                if (check)
                {
                    make_move(g8);
                    change_names(from);
                    check = false;
                    update_king_pos(g8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g8";
                    }
                }
                else
                {
                    make_move(g8);
                    change_names(from); ;
                    checkmate(g8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: g8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: g8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "g8")
                {
                    if (check_for_turn(g8.AccessibleDescription))
                    {
                        from = "g8";
                        prepare_to_move(g8);
                    }
                }

            }
        }

        private void h1_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h1"))
            {
                if (check)
                {
                    make_move(h1);
                    change_names(from);
                    check = false;
                    update_king_pos(h1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h1";
                    }
                }
                else
                {
                    make_move(h1);
                    change_names(from); ;
                    checkmate(h1);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h1";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h1";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h1")
                {
                    if (check_for_turn(h1.AccessibleDescription))
                    {
                        from = "h1";
                        prepare_to_move(h1);
                    }
                }

            }
        }
       private void h2_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h2"))
            {
                if (check)
                {
                    make_move(h2);
                    change_names(from);
                    check = false;
                    update_king_pos(h2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    }
                }
                else
                {
                    make_move(h2);
                    change_names(from); ;
                    checkmate(h2);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h2")
                {
                    if (check_for_turn(h2.AccessibleDescription))
                    {
                        from = "h2";
                        prepare_to_move(h2);
                    }
                }

            }
        }
        private void h3_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h3"))
            {
                if (check)
                {
                    make_move(h3);
                    change_names(from); 
                    check = false;
                    update_king_pos(h3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    }

                }
                else
                {
                    make_move(h3);
                    change_names(from);
                    checkmate(h3);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h2";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h3")
                {
                    if (check_for_turn(h3.AccessibleDescription))
                    {
                        from = "h3";
                        prepare_to_move(h3);
                    }
                }

            }
        }
        private void h4_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h4"))
            {
                if (check)
                {
                    make_move(h4);
                    change_names(from);
                    check = false;
                    update_king_pos(h4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h4";
                    }
                }
                else
                {
                    make_move(h4);
                    change_names(from); ;
                    checkmate(h4);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h4";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h4";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h4")
                {
                    if (check_for_turn(h4.AccessibleDescription))
                    {
                        from = "h4";
                        prepare_to_move(h4);
                    }
                }

            }
        }
        private void h5_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h5"))
            {
                if (check)
                {
                    make_move(h5);
                    change_names(from);
                    check = false;
                    update_king_pos(h5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h5";
                    }
                }
                else
                {
                    make_move(h5);
                    change_names(from); ;
                    checkmate(h5);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h5";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h5";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h5")
                {
                    if (check_for_turn(h5.AccessibleDescription))
                    {
                        from = "h5";
                        prepare_to_move(h5);
                    }
                }

            }
        }
        private void h6_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h6"))
            {
                if (check)
                {
                    make_move(h6);
                    change_names(from);
                    check = false;
                    update_king_pos(h6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h6";
                    }
                }
                else
                {
                    make_move(h6);
                    change_names(from); ;
                    checkmate(h6);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h6";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h6";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h6")
                {
                    if (check_for_turn(h6.AccessibleDescription))
                    {
                        from = "h6";
                        prepare_to_move(h6);
                    }
                }

            }
        }
        private void h7_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h7"))
            {
                if (check)
                {
                    make_move(h7);
                    change_names(from);
                    check = false;
                    update_king_pos(h7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h7";
                    }
                }
                else
                {
                    make_move(h7);
                    change_names(from); ;
                    checkmate(h7);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h7";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h7";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h7")
                {
                    if (check_for_turn(h7.AccessibleDescription))
                    {
                        from = "h7";
                        prepare_to_move(h7);
                    }
                }

            }
        }
        private void h8_Click(object sender, EventArgs e)
        {
            if (moves.Contains("h8"))
            {
                if (check)
                {
                    make_move(h8);
                    change_names(from);
                    update_king_pos(h8);
                    check = false;
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h8";
                    }
                }
                else
                {
                    make_move(h8);
                    change_names(from);
                    checkmate(h8);
                    richTextBox1.Text += "\nMove: " + piece_name + " to: h8";
                    if (AI_mode)
                    {
                        minmax();
                        richTextBox1.Text += "\nMove: " + piece_name + " to: h8";
                    }
                }
            }
            else
            {
                if (!check || king_pos == "h8")
                {
                    if (check_for_turn(h8.AccessibleDescription))
                    {
                        from = "h8";
                        prepare_to_move(h8);
                    }
                }

            }
        } 
    }
}
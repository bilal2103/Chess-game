namespace Chess
{
    public partial class Form1
    {
        public abstract class piece
        {
            public piece() { }
            protected string piece_name;
            protected string side;
            protected string piece_background_colour;
            protected string position;
            protected string[] valid_move;
            protected  bool[,] occupied_for_black;
            protected  bool[,] occupied_for_white;
            protected string status;
            public abstract void valid_moves(string a, string b, bool[,] c, bool[,] d);
            
            public string Position { get => position; set => position = value; }
            public string Side { get => side; set => side = value; }
            public string Piece_name { get => piece_name; set => piece_name = value; }
            public string[] Valid_move { get => valid_move; }
            public bool[] Occupied_for_black { get => Occupied_for_black; }
            public bool[] Occupied_for_white { get => Occupied_for_white; }
            public string Status { get => status; set => status = value; }

        }
    }
}

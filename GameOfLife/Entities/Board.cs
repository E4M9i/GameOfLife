using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Enums;

namespace GameOfLife.Entities
{
    public class Board
    {

        public int Height { get; set; }
        public int Width { get; set; }
        public Cell[,] Cells { get; set; }
        

    }
}

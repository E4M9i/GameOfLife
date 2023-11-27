using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Entities
{
    public class GameSetting
    {
        public int BoardHeight { get; set; }
        public int BoardWidth { get; set; }
        public int Generation { get; set; }
        public int Interval { get; set; }
        public bool DebugMode { get; set; }
        public string LogFolder { get; set; }
        public BoardLayout BoardLayout { get; set; }
    }

    public class BoardLayout
    {
        public string LiveSymbol { get; set; }
        public string DeadSymbol { get; set; }
    }
}
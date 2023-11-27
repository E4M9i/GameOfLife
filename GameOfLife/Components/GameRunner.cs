using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using GameOfLife.Entities;

namespace GameOfLife.Components
{
    public class GameRunner
    {
        private readonly GameSetting _setting;

        public GameRunner(GameSetting setting)
        {
            _setting = setting;
        }

        public void Run()
        {
            var boardHelper=new BoardHelper(_setting);
            var board=boardHelper.Init();

            boardHelper.RenderBoard(board, 0); 
            for (var i = 1; i <= _setting.Generation; i++)
            {
                var newBoard = boardHelper.GetNextGeneration(board);
                Thread.Sleep(_setting.Interval);
                boardHelper.RenderBoard(newBoard, i);
                board = newBoard;
            }

        }
    }
}

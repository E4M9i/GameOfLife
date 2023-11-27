using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameOfLife.Entities;
using GameOfLife.Enums;

namespace GameOfLife.Components
{
   public class BoardHelper
    {
        private readonly GameSetting _setting;
        private string _timeStamp;

        public BoardHelper(GameSetting setting)
        {
            _setting = setting;
             _timeStamp = DateTime.Now.ToString("ddMMyyyy-HHmmss");
        }

        public Board Init()
        {
            var random = new Random();
            var cells = new Cell[_setting.BoardHeight, _setting.BoardWidth];


            for (var i = 0; i < _setting.BoardHeight; i++)
            for (var j = 0; j < _setting.BoardWidth; j++)
            {
                var randomInt = random.Next(2);
                var randomState = randomInt == 0 ? State.Dead : State.Alive;
                cells[i, j] = new Cell() {State = randomState};
            }

            return new Board() {Height = _setting.BoardHeight, Width = _setting.BoardWidth, Cells = cells};
        }
        public Board InitSquare()
        {
            
            var cells = new Cell[_setting.BoardHeight, _setting.BoardWidth];


            for (var i = 0; i < _setting.BoardHeight; i++)
            for (var j = 0; j < _setting.BoardWidth; j++)
            {
               
                cells[i, j] = new Cell() { State = State.Dead };
            }

            cells[1, 1].State = State.Alive;
            cells[1, 2].State = State.Alive;
            cells[2, 1].State = State.Alive;
            cells[2, 2].State = State.Alive;
            return new Board() { Height = _setting.BoardHeight, Width = _setting.BoardWidth, Cells = cells };
        }
        public Board Init10Cell()
        {

            var cells = new Cell[_setting.BoardHeight, _setting.BoardWidth];


            for (var i = 0; i < _setting.BoardHeight; i++)
            for (var j = 0; j < _setting.BoardWidth; j++)
            {

                cells[i, j] = new Cell() { State = State.Dead };
            }

            cells[5, 10].State = State.Alive;
            cells[5, 11].State = State.Alive;
            cells[5, 12].State = State.Alive;
            cells[5, 13].State = State.Alive;
            cells[5, 14].State = State.Alive;
            cells[5, 15].State = State.Alive;
            cells[5, 16].State = State.Alive;
            cells[5, 17].State = State.Alive;
            cells[5, 18].State = State.Alive;
            cells[5, 19].State = State.Alive;
        
            return new Board() { Height = _setting.BoardHeight, Width = _setting.BoardWidth, Cells = cells };
        }
        public Board GetNextGeneration(Board currentBoard)
        {
            var evolvedBoard=new Board() { Height = currentBoard.Height, Width = currentBoard.Width, Cells = new Cell[currentBoard.Height, currentBoard.Width] };
            for (var i = 0; i < currentBoard.Height; i++)
            for (var j = 0; j < currentBoard.Width; j++)
            {
                var liveNeighbors = GetLiveNeighbors(currentBoard,i, j);
                evolvedBoard.Cells[i, j] =new Cell(){State = StateMachine.GetNextState(currentBoard.Cells[i, j].State, liveNeighbors)};
            }

            return evolvedBoard;
        }
        private int GetLiveNeighbors(Board board,int locX,int locY)
        {
            var liveNeighbors = 0;
            for (var i = -1; i <= 1; i++)
            for (var j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                var nLocX = locX + i;
                var nLocY = locY + j;

                if (nLocX < 0 || nLocX >= board.Height || nLocY < 0 || nLocY >= board.Width) continue;
                if (board.Cells[nLocX, nLocY].State == State.Alive)
                    liveNeighbors++;
            }

            return liveNeighbors;
        }
        public void RenderBoard(Board currentBoard, int generation)
        {
            var rowIndex = 0;
            var rowLength = currentBoard.Cells.GetUpperBound(1) + 1;

            var output = new StringBuilder();
            var live = _setting.BoardLayout.LiveSymbol;
            var dead = _setting.BoardLayout.DeadSymbol;
            output.AppendLine($"Generation number: {generation}");
            foreach (var cell in currentBoard.Cells)
            {
                output.Append(cell.State == State.Alive ?live :dead );
                rowIndex++;
                if (rowIndex >= rowLength)
                {
                    rowIndex = 0;
                    output.AppendLine();
                }
            }
            Console.Clear();
           
            Console.Write(output.ToString());
            if (_setting.DebugMode)
            {
                var logDirPath = Path.Combine(_setting.LogFolder, _timeStamp);
                var logFilePath = Path.Combine(logDirPath, $"Gen-{generation}.txt");

                if (!Directory.Exists(logDirPath)) Directory.CreateDirectory(logDirPath);

                using FileStream fStream = new FileStream(logFilePath, FileMode.OpenOrCreate);
                using StreamWriter sWriter = new StreamWriter(fStream);
                sWriter.Write(output.ToString());
            }
             
        }
    }
}

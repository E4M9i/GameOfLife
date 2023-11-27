using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Enums;

namespace GameOfLife.Components
{
   public class StateMachine
    {
        public static  State GetNextState(State currentState, int liveNeighbors)
        {
           
            switch (currentState)
            {
                case State.Alive:
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                       return State.Dead;
                    break;
                case State.Dead:
                    if (liveNeighbors == 3)
                       return State.Alive;
                    break;
              
            }

            return currentState;
        }
    }
}

using GameOfLife.Components;
using GameOfLife.Enums;
using Xunit;

namespace GameOfLife_Test
{
    public class StateMachineTestSet
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Live_liveCellNeighborsLessThan2_Dies(int liveCellNeighbors)
        {
            // Any live cell with less than 2 live cells as neighbor dies.
            // Arrange
            var currentState = State.Alive;

            // Act
            var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

            // Assert
            Assert.Equal(State.Dead, result);
        }
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
      public void Live_liveCellNeighborsMoreThan3_Dies(int liveCellNeighbors)
        {
            // Any live cell with more than 3 live cells as neighbor dies.
            // Arrange
            var currentState = State.Alive;

            // Act
            var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

            // Assert
            Assert.Equal(State.Dead, result);
        }
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Live_liveCellNeighbors2or3_Survives(int liveCellNeighbors)
        {
            // Any live cell with 2 or 3 live cells as neighbor stays alive.
            // Arrange
            var currentState = State.Alive;

            // Act
            var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

            // Assert
            Assert.Equal(State.Alive, result);
        }

        [Theory]
        [InlineData(3)]
        public void Dead_liveCellNeighbors3_Born(int liveCellNeighbors)
        {
            // Any dead cell with 3 live cells as neighbor will born.
            // Arrange
            var currentState = State.Dead;

            // Act
            var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

            // Assert
            Assert.Equal(State.Alive, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void Dead_liveCellNeighborsOtherThan3_StaysDead(int liveCellNeighbors)
        {
            // Any dead cell with other than 3 live cells as neighbor will stay dead.
            // Arrange
            var currentState = State.Dead;

            // Act
            var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

            // Assert
            Assert.Equal(State.Dead, result);
        }

    }
}

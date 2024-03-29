## Streamlining Game Logic: State Machines & Unit Testing in 'Game of Life'

#### Dive into the effective use of state machines and unit testing in game development, illustrated through a detailed case study of the classic 'Game of Life'. Uncover insights into structuring game logic and ensuring robustness through targeted testing strategies.


### Introduction
**State machines** are a fundamental concept in software development, finding extensive use in game development due to their efficiency in managing different states and transitions. In this post, we'll explore the implementation and unit testing of a state machine using the classic Game of Life as a case study.

---

### Section 1: Understanding the State Machine in the Game of Life
The Game of Life is a cellular automaton devised by the mathematician [John Conway](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life). In this game, each cell on a grid can be in one of two states: Alive or Dead. These states change over time according to specific rules, making the Game of Life an excellent example of a state machine.

#### State Enumeration
```csharp
namespace GameOfLife.Enums
{
    public enum State
    {
        Dead,
        Alive
    }
}
```
---

### Section 2: Delving into the State Machine's Implementation
The `StateMachine` class is pivotal in determining the next state of each cell. It takes the current state and the number of live neighbors to decide the future state.

#### Key Functionality
```csharp
// Simplified example of a method within the StateMachine class
public State GetNextState(State currentState, int liveNeighbors)
{
    // Logic to determine the next state
}
```
---

### Section 3: The Role of Unit Testing in Ensuring Game Integrity

Unit testing is crucial in verifying that each part of the software works as expected. In the context of the Game of Life, it ensures that the state machine accurately adheres to the game's rules.

---

### Section 4: A Closer Look at the Unit Tests for the State Machine
The `StateMachineTestSet` class, using XUnit, focuses on testing the core functionality of the state machine.

### Example Test Case
```csharp
public class StateMachineTestSet
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void Live_liveCellNeighborsLessThan2_Dies(int liveCellNeighbors)
    {
        // Arrange
        var currentState = State.Alive;

        // Act
        var result = StateMachine.GetNextState(currentState, liveCellNeighbors);

        // Assert
        Assert.Equal(State.Dead, result);
    }
}
```

---

### Section 5: Lessons Learned and Best Practices
The development and testing of the state machine in the Game of Life project underscored several key points:

1. **Clarity in State Definitions**: Clearly defined states simplify the implementation and testing processes.
2. **Robust Testing**: Comprehensive unit tests are essential for ensuring the accuracy of state transitions.

---

### Conclusion
State machines and unit testing form the backbone of reliable and efficient game development. The Game of Life offers a practical example of these concepts in action. I encourage readers to experiment with these ideas in their projects.

---
### Setting
You can change settings of Game of Life by simply edit values in [``setting.json``](https://github.com/E4M9i/GameOfLife/blob/main/GameOfLife/setting.json)
 ``` json 
 {
    "boardHeight": 20,
    "boardWidth": 30,
    "generation": 150,
    "interval": 100,
    "debugMode":true,
    "logFolder":".\\Logs",
    "boardLayout": {
        "liveSymbol": "#",
        "deadSymbol": "-"
    }
} 
```
If you keep debug mode True it will create series of files in order to trace generations.
Log folder path can be changed as you wish.
Symbols of dead and alive also can be edited which is kind of fun to see the game in diffrent look, it's actually was my son's idea 🧬💡

# Turtle Challenge
 
## Description of problem

Turtle Challenge is a game where a turtle moves on a board with mines, following a sequence of movements. The objective is to take the turtle from the starting point to the exit point, avoiding mines and staying within the board limits.

## File Structure

### Game Settings (game-settings.json)

The `game-settings.json` file defines the game settings, including the board size, the turtle's starting position, the starting direction, the exit point, and the mines on the board.

#### Example File:

```json
{
    "Board": {
      "Width": 5,
      "Height": 4,
      "ExitPoint": {
        "X": 4,
        "Y": 2
      },
      "Mines": [
        {
          "X": 1,
          "Y": 2
        },
        {
          "X": 3,
          "Y": 1
        }
      ]
    },
    "Turtle": {
      "Position": {
        "X": 0,
        "Y": 1
      },
      "Direction": {
        "CurrentDirection": 0
      }
    }  
}
```
#### **Note: The turtle's starting direction in the game settings file should be 0 if North, 1 if East, 2 if South, or 3 if West.



### Movement Sequences (moves.json)

The `moves.json` file contains a list of movement sequences that the turtle must follow. Each sequence is a list of commands (m to move and r to rotate).

#### Example File:

```json
[
    {
        "Moves": ["m", "r", "m", "m", "r", "m", "m", "r", "r", "r", "m", "m"]
    },
    {
        "Moves": ["m", "r", "m", "r", "m", "m", "r", "r", "m", "m"]
    }
]
```

## Game rules

**Movements:**
- m: Moves the turtle one position in the current direction.
- r: Rotates the turtle 90 degrees clockwise.

**Goal:**
- Take the turtle from the starting point to the exit point.

**Termination Conditions:**
- Success: The turtle reaches the exit point.
- Mine: The turtle hits a mine.
- Out of Bounds: The turtle moves outside the boundaries of the board.
- Danger: The turtle is still on the board after making all the moves.

## Implementation
### **Services**
1. **InputService:**
- Reading the game-settings.json and moves.json files.
- Deserialization of JSON files into C# objects (GameSettings and MoveSequence).
2. **GameService**
- Game logic: Processes the sequence of moves and determines the outcome of the game based on established rules.

### **Model Classes**
1. GameSettings: Game settings (board size, starting position, starting direction, exit point, mines).
2. MoveSequence: Movement sequences.
3. Turtle: Represents the turtle, including its position and direction.
4. Board: Represents the board, including its dimensions, exit point and mines.

## Running the Game
```properties 
dotnet run game-settings moves
```

## Tests
The project includes unit tests to verify the behavior of the InputService and GameService services. The tests cover scenarios such as valid movements, reaching the mine, reaching the exit point, moving out of bounds, and handling invalid commands.
It also includes unit tests for the Board and Turtle classes.
```properties 
dotnet test
```


# Conway's Game of Life Kata

The Game of Life is a cellular automaton devised by the British mathematician John Horton Conway in 1970.

A cellular automaton is a model which consists of cell objects that exist on a grid, where each cell has a 'state', and a 'neighbourhood' of adjacent cells.

The game evolves through a series of generations, and is known as a zero-player game, meaning that the evolution is determined by the initial state of the world, and no further input is required.

## Requirements

-   2D grid of square cells
-   Cells have two states: 'Alive' or 'Dead'
-   The neighbours consist of the 8 surrounding cells.
-   If a cell is at the edge of the grid, the neighbours wrap to the other side.

-   Visualise the game in the console.
-   Be able to define how big the world/grid is.
-   Be able to set the initial state of the world.

**Advanced**: Allow world state to be saved and loaded from disk.

## Rules

For the game to evolve to the next generation, each cell is compared to a series of rules:

-   Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
-   Any live cell with more than three live neighbours dies, as if by overcrowding.
-   Any live cell with two or three live neighbours lives on to the next generation.
-   Any dead cell with exactly three live neighbours becomes a live cell.

## Running the Application

Once you have cloned the repository, you can run the program using the following steps:

1. Navigate to the correct directory using `cd conways-game-of-life/src/ConsoleApp`

2. Use `dotnet run` to run the program using the default file.

OR

3. Use `dotnet run {filePath}` where filePath = the location of a json file configured in the same format as the default file found in `conways-game-of-life/src/ConsoleApp/InputFiles`

    For example, using `dotnet run ~/Documents/GameOfLife/my-game.json` will run a json file that I have stored in my documents folder.

## Code Coverage

To generate a report of the code coverage for unit testing:

1. Run `dotnet test --collect:"XPlat Code Coverage"`
2. Install the report generator tool using `dotnet tool install -g dotnet-reportgenerator-globaltool`

3. Run the following command, replacing {guid} with the guid name of the folder generated in `conways-game-of-life/tests/GameOfLifeTests/TestResults` when you run the command in the first step.

`reportgenerator "-reports:./tests/GameOfLifeTests/TestResults/{guid}/coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html`

3. This will generate a HTML file (`conways-game-of-life/coveragereport/index.html`) which will display the current code coverage.

## Acknowledgement

This program was completed for a **Language Design Quorum** as a part of the **Future Maker's Academy** at MYOB.

Source: https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-conways-game-of-life/kata-conways-game-of-life.md

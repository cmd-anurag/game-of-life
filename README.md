# Conway's Game of Life

Conway's Game of Life is a cellular automaton created by mathematician John Conway. It is a zero-player game, meaning its evolution is determined by its initial state, requiring no further input. The game takes place on a grid of cells, each of which can be either alive or dead. The state of each cell changes based on the following simple rules:

1. **Birth**: A dead cell becomes alive if exactly three live neighbors surround it.
2. **Survival**: A live cell remains alive if it has two or three live neighbors; otherwise, it dies from underpopulation or overpopulation.
3. **Death**: A live cell dies if it has fewer than two or more than three live neighbors.  

___________________________________________  

This project implements Conway's Game of Life in Unity using a tilemap to represent the grid. The initial configuration can be set by the user.

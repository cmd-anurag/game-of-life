using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameOfLifeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    public AnimatedTile aliveTile;
    public AnimatedTile deadTile;

    private int[,] grid;
    public int rows = 25;
    public int columns = 25;


    void Start()
    {
        grid = new int[rows, columns];
        InitializeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 0.5 <  Time.deltaTime) {
            CreateNextGeneration();
            UpdateTileMap();
        }
    }

    void InitializeGrid() {
        for(int i = 0; i < rows; ++i) {
            for(int j = 0; j < columns; ++j) {
                Vector3Int tilePosition = new(i, j, 0);
                grid[i,j] = Random.Range(0,2);
                if(grid[i,j] == 0) {
                    tilemap.SetTile(tilePosition, deadTile);
                }
                else {
                    tilemap.SetTile(tilePosition, aliveTile);
                }                
            }
        }
    }
    void UpdateTileMap() {
        Vector3Int tilePosition = new(0,0,0);
        for(int i = 0; i < rows; ++i) {
            for(int j = 0; j < columns; ++j) {
                tilePosition = new(i,j,0);
                if(grid[i,j] == 0) {
                    tilemap.SetTile(tilePosition, deadTile);
                }
                else {
                    tilemap.SetTile(tilePosition, aliveTile);
                }
            }
        }
    }

    void CreateNextGeneration() {

        // new generation storage
        int [,] newGrid = new int[rows, columns];

        for(int i = 0;  i < rows; ++i) {
            for(int j = 0; j < columns; ++j) {
                
                int liveNeighbors = CountLiveNeighbors(i,j);

                if(grid[i,j] == 1) { // if current gen cell is alive
                    if(liveNeighbors > 3 || liveNeighbors < 2) { 
                        // overpopulation or underpopulation
                        newGrid[i,j] = 0;
                    }
                    else { 
                        // survival
                        newGrid[i,j] = grid[i,j];
                    }
                }
                else {
                    // if current gen cell is dead
                    if(liveNeighbors == 3) {
                        // birth
                        newGrid[i,j] = 1;
                    }
                }
            }
        }
        grid = newGrid;
    }

    int CountLiveNeighbors(int x, int y) {
        int count = 0;
        // i and j are offsets from current x and y
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int newX = x + i;
                int newY = y + j;

                if (newX >= 0 && newX < rows && newY >= 0 && newY < columns)
                {
                    // increment count if at the new position the cell is alive
                    count += grid[newX, newY];
                }
            }
        }
        return count;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectionManagerScript : MonoBehaviour
{
    public GameObject selectionPanel;
    public GameObject UImanager;
    public Tilemap tilemap;
    public AnimatedTile aliveTile;
    public AnimatedTile deadTile;

    public GameOfLifeScript gameOfLifeScript;


    

    // Start is called before the first frame update
    void Start()
    {
        gameOfLifeScript = tilemap.GetComponent<GameOfLifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!selectionPanel.activeSelf) {
            return;
        }
        DetectSelection();
        if(Input.GetKeyDown(KeyCode.S)) {
           gameOfLifeScript.isSimulating = true;
        }

        if(Input.GetKeyDown(KeyCode.P)) {
            gameOfLifeScript.StopSimulation();
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            gameOfLifeScript.isSimulating = false;
            gameOfLifeScript.ResetGrid();
            UImanager.GetComponent<UIManagerScript>().SwitchToHome();
        }
    }

    void DetectSelection() {
        
        if(Input.GetMouseButtonDown(0)) {   
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);

            if(cellPosition.x >= 0 && cellPosition.x < gameOfLifeScript.rows && 
                cellPosition.y >=0 && cellPosition.y < gameOfLifeScript.columns) {
                    ToggleCell(cellPosition);
                }
        }
    }
    void ToggleCell(Vector3Int cellPosition) {
        int currentState = gameOfLifeScript.grid[cellPosition.x, cellPosition.y];
        if(currentState == 0) {
            gameOfLifeScript.grid[cellPosition.x, cellPosition.y] = 1;
            tilemap.SetTile(cellPosition, aliveTile);
        }
        else {
            gameOfLifeScript.grid[cellPosition.x, cellPosition.y] = 0;
            tilemap.SetTile(cellPosition, deadTile);
        }
    }
}

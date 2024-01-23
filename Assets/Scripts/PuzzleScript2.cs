using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Puzzle2 : MonoBehaviour
{

    public Camera mazeCamera;
    public GameObject player;
    public GameObject playerModel;
    public TMP_Text interactionText;
    private bool isInteracting = false;

    private bool won = false;

    float interactionRange = 6f;

    private  int[,] maze = {
{1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
{1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
{1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1},
{1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1},
{1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1},
{1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1},
{1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1},
{1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1},
{1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
{1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1},
{1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
{1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
{1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1},
{1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1},
{1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1},
{1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1},
{1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
{1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1},
{1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1},
{1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1}
        };


    void Start()
    {
        
        DrawMaze();
    }

     void Update()
    {
        if(won && !isInteracting)
        {
            interactionText.text = "";
            return;
        }


        Vector3 playerPosition = transform.InverseTransformPoint(player.transform.position);
        if(playerPosition.magnitude <= interactionRange)
        {
            if(!isInteracting && !won) 
            {
                interactionText.text = "Druk op E om te interacteren";
            }
            if(isInteracting && won)
            {
                interactionText.text = "Druk op E om de puzzel te beëindigen";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                isInteracting = !isInteracting;

                if (isInteracting && !won)
                {
                    player.GetComponent<FPSController>().enabled = false;
                    mazeCamera.enabled = true;
                    interactionText.text = "Gebruik de pijltjes om het doolhof te navigeren";
                    Debug.Log("Maze interaction started.");
                    playerModel.SetActive(false);
                }
                if(!isInteracting)
                {
                    player.GetComponent<FPSController>().enabled = true;
                    mazeCamera.enabled = false;
                    interactionText.text = "";
                    Debug.Log("Maze interaction ended.");
                    playerModel.SetActive(true);
                }

        }

        }
        else 
        {
            interactionText.text = "";
        }
      

        if(isInteracting && !won)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(-1, 0); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(1, 0); // Move down
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(0, -1); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(0, 1); // Move right
        }

        }
    }

void MovePlayer(int offsetX, int offsetY)
{
    int currentPlayerX = -1;
    int currentPlayerY = -1;

    for (int i = 0; i < maze.GetLength(0); i++)
    {
        for (int j = 0; j < maze.GetLength(1); j++)
        {
            if (maze[i, j] == 2)
            {
                currentPlayerX = i;
                currentPlayerY = j;
                break;
            }
        }
    }

    int newPlayerX = currentPlayerX + offsetX;
    int newPlayerY = currentPlayerY + offsetY;

    if (IsWithinBounds(newPlayerX, newPlayerY))
    {
        int cellValue = maze[newPlayerX, newPlayerY];

        if (cellValue == 0)
        {
            maze[currentPlayerX, currentPlayerY] = 3; 
            maze[newPlayerX, newPlayerY] = 2; 

            DestroyAllWalls();
           
        }
        else if (cellValue == 3) 
        {
            maze[newPlayerX, newPlayerY] = 2;
            maze[currentPlayerX, currentPlayerY] = 0; 

            DestroyAllWalls();


        }
        else if (cellValue == 4)
        {
            Win();
        }
    }
     DrawMaze();
}


void Win() {
    won = true;

    for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] == 3 || maze[i, j] == 4 ||maze[i, j] == 2)
                {
                    maze[i, j] = 5;
                }
            
            }
        }


    DestroyAllWalls();
    DrawMaze();


    GameObject gameManagerObject = GameObject.Find("GameManager");

    if (gameManagerObject != null)
        {
            // Get the GameManager script component
            GameManagerLevel2 gameManager = gameManagerObject.GetComponent<GameManagerLevel2>();

            if (gameManager != null)
            {
                gameManager.wonPuzzle2();
            }
            else
            {
                Debug.LogError("GameManager script not found on GameManager object.");
            }
        }
        else
        {
            Debug.LogError("GameManager object not found in the scene.");
        }


}



bool IsWithinBounds(int x, int y)
{
    return x >= 0 && x < maze.GetLength(0) && y >= 0 && y < maze.GetLength(1);
}

    void DrawMaze()
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] > 0)
                {
                    InstantiateWall(i, j, maze[i, j]);
                }
            
            }
        }
    }

    void InstantiateWall(int x, int y, int type)
    {
        

        Vector3 cubeLocalPosition = transform.localPosition;

        
        float wallScaleX = 0.1f;
        float wallScaleY = 0.1f;
        float wallScaleZ = 0.1f;

        

        float wallPositionZ = x * wallScaleX + cubeLocalPosition.z;
        float wallPositionY = y * wallScaleY + cubeLocalPosition.y;




        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);

        
        if(type == 2) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.yellow;
        }
        if(type == 3) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.blue;
        }

        if(type == 4) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.red;
        }
        if(type == 5) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.green;
        }

        if(type == 9) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.green;
        }


        wall.tag = "WallPuzzle2";

        wall.transform.localScale = new Vector3(wallScaleX, wallScaleY, wallScaleZ);
        wall.transform.localPosition = new Vector3(cubeLocalPosition.x + 0.3f, wallPositionY - 1.63f, wallPositionZ - 0.95f);
    }


void DestroyAllWalls() 

{
    GameObject[] walls = GameObject.FindGameObjectsWithTag("WallPuzzle2");
    foreach(GameObject wall in walls) {
        GameObject.Destroy(wall);
    }
}
}




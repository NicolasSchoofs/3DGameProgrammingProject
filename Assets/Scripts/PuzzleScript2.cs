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
{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4},
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
{0, 6, 0, 6, 0, 6, 0, 1, 0, 7, 0},
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
{0, 6, 0, 1, 0, 8, 0, 1, 0, 7, 0},
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
{0, 6, 0, 1, 0, 8, 0, 1, 0, 7, 0},
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
{0, 1, 0, 1, 0, 1, 0, 6, 0, 6, 0},
{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},  
{2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
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
                interactionText.text = "Press E to interact";
            }
            if(isInteracting && won)
            {
                interactionText.text = "Press E to end the puzzle";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                isInteracting = !isInteracting;

                if (isInteracting && !won)
                {
                    player.GetComponent<FPSController>().enabled = false;
                    mazeCamera.enabled = true;
                    interactionText.text = "Use the arrow keys to navigate the maze";
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
            
    
            if(CheckConnectivity(maze, 6, new int[] { 7, 8}) && CheckConnectivity(maze, 7, new int[] { 6, 8 }) && CheckConnectivity(maze, 8, new int[] { 6, 7 }) ) {
                Debug.LogError(CheckConnectivity(maze, 6, new int[] { 7, 8 }));
                Win();
            }
        }
    }
     DrawMaze();
}

void PrintSubarray(int[,] subarray)
        {
            for (int i = 0; i < subarray.GetLength(0); i++)
            {
                for (int j = 0; j < subarray.GetLength(1); j++)
                {
                    Console.Write(subarray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
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
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();

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

        
        float wallScaleX = 0.19f;
        float wallScaleY = 0.19f;
        float wallScaleZ = 0.19f;

        

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
        if(type == 6) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.gray;
        }
        if(type == 7) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.cyan;
        }
        if(type == 8) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.magenta;
        }

        if(type == 9) 
        {
            Renderer wallRenderer = wall.GetComponent<Renderer>();
            wallRenderer.material.color = Color.green;
        }


        wall.tag = "Wall";

        wall.transform.localScale = new Vector3(wallScaleX, wallScaleY, wallScaleZ);
        wall.transform.localPosition = new Vector3(cubeLocalPosition.x + 0.3f, wallPositionY - 1.63f, wallPositionZ - 0.95f);
    }


void DestroyAllWalls() 

{
    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
    foreach(GameObject wall in walls) {
        GameObject.Destroy(wall);
    }
}

//Path finding
static bool IsValidMove(int[,] maze, bool[,] visited, int row, int col, int[] targetValues)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        return  row >= 0 && row < rows && col >= 0 && col < cols && !visited[row, col] && Array.IndexOf(targetValues, maze[row, col]) == -1;
    }

    static void DFS(int[,] maze, bool[,] visited, int row, int col, int[] targetValues)
    {
        visited[row, col] = true;

        // Define the possible moves (up, down, left, right)
        int[,] moves = { {-1, 0}, {1, 0}, {0, -1}, {0, 1} };

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + moves[i, 0];
            int newCol = col + moves[i, 1];

            if (IsValidMove(maze, visited, newRow, newCol, targetValues))
            {
                DFS(maze, visited, newRow, newCol, targetValues);
            }
        }
    }

    static bool CheckConnectivity(int[,] maze, int value, int[] otherValues)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        bool[,] visited = new bool[rows, cols];

        int startRow = -1, startCol = -1;

        // Find the starting point (any cell with the specified value)
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (maze[i, j] == value)
                {
                    startRow = i;
                    startCol = j;
                    break;
                }
            }
        }

        if (startRow != -1 && startCol != -1)
        {
            // Perform DFS from the starting point
            DFS(maze, visited, startRow, startCol, otherValues);

            // Check if all cells with the specified value are visited
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (maze[i, j] == value && !visited[i, j])
                    {
                        return false;
                    }
                }
            }

            // Check if any cell with the specified value can reach a cell with other specified values
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Array.IndexOf(otherValues, maze[i, j]) != -1 && visited[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        else
        {
            // No cell with the specified value found
            return false;
        }
    }


}



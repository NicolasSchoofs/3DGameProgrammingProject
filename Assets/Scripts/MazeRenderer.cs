using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    public Camera mazeCamera;
    public RenderTexture mazeRenderTexture;

    // Example maze represented as a 2D array (0 = wall, 1 = path)
    private int[,] mazeData = {
        {1, 1, 0, 1, 0},
        {0, 0, 1, 1, 1},
        {1, 0, 1, 0, 1},
        {1, 1, 1, 1, 1},
        {0, 1, 0, 0, 1}
    };

    private bool isInteracting = false;

    void Start()
    {
        RenderMazeToTexture();

        mazeCamera.depth = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInteracting = !isInteracting;

            if (isInteracting)
            {
                mazeCamera.enabled = true;
                Debug.Log("Maze interaction started.");
            }
            else
            {
                mazeCamera.enabled = false;
                Debug.Log("Maze interaction ended.");
            }
        }
    }

    void RenderMazeToTexture()
    {
        
        if (mazeRenderTexture != null)
        {
            Debug.Log("Rendering maze to texture...");
            RenderTexture.active = mazeRenderTexture;
            GL.Clear(true, true, Color.black);  // Clear the Render Texture

            for (int x = 0; x < mazeData.GetLength(0); x++)
            {
                for (int y = 0; y < mazeData.GetLength(1); y++)
                {
                    if (mazeData[x, y] == 1)
                    {
                        // Draw a path on the Render Texture
                        DrawPixel(x, y, Color.white);
                    }
                    // Add additional conditions for drawing walls or other elements if needed
                }
            }

            RenderTexture.active = null;
            Debug.Log("Maze rendering completed.");
        }
        else
        {
            Debug.LogError("Render Texture is not assigned.");
        }
    }

    void DrawPixel(int x, int y, Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();

        Graphics.DrawTexture(new Rect(x, y, 1, 1), texture);
    }
}

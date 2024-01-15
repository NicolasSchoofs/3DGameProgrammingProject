using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePuzzle : MonoBehaviour
{
    public Transform[] nodes; // Drag and drop the node objects in the inspector
    public Material lineMaterial;
    
    private LineRenderer lineRenderer;

    void Start()
    {
        // Initialize Line Renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;  // Adjust the width as needed
        lineRenderer.endWidth = 0.1f;    // Adjust the width as needed
        lineRenderer.material = lineMaterial; // Assign the material

        // Set the initial positions of the Line Renderer
        UpdateLinePositions();
    }

    void Update()
    {
        // Check for player input and update the positions of the Line Renderer
        UpdateLinePositions();
        
        // Check if the puzzle is solved
        if (IsPuzzleSolved())
        {
            // Puzzle is solved, update visuals or trigger events
            lineRenderer.material.color = Color.green; // Change color to indicate success
        }
    }

    void UpdateLinePositions()
    {
        // Set the positions of the Line Renderer based on the nodes
        lineRenderer.positionCount = nodes.Length;
        for (int i = 0; i < nodes.Length; i++)
        {
            lineRenderer.SetPosition(i, nodes[i].position);
        }
    }

    bool IsPuzzleSolved()
    {
        // Check if the pattern is correct (e.g., nodes connected in a specific order)
        // Return true if the puzzle is solved, false otherwise
        // Add your specific logic here
        return false;
    }
}
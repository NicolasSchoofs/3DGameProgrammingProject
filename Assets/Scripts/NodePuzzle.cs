using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePuzzle : MonoBehaviour
{
    public Material lineMaterial;
    
    private LineRenderer lineRenderer;
    private List<Transform> connectedNodes = new List<Transform>();

    void Start()
    {
        // Initialize Line Renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;  // Adjust the width as needed
        lineRenderer.endWidth = 0.1f;    // Adjust the width as needed
        lineRenderer.material = lineMaterial; // Assign the material

        // Disable Line Renderer initially
        lineRenderer.enabled = false;
    }

    void Update()
    {
        // Check for player input
        if (Input.GetMouseButtonDown(0))
        {
            HandleNodeClick();
        }

        // Update the positions of the Line Renderer
        UpdateLinePositions();

        // Check if the puzzle is solved
        if (IsPuzzleSolved())
        {
            // Puzzle is solved, update visuals or trigger events
            lineRenderer.material.color = Color.green; // Change color to indicate success
        }
    }

    void HandleNodeClick()
    {
        // Cast a ray from the mouse position to detect nodes
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Transform clickedNode = hit.transform;

            // Toggle connection status for the clicked node
            if (connectedNodes.Contains(clickedNode))
            {
                connectedNodes.Remove(clickedNode);
            }
            else
            {
                connectedNodes.Add(clickedNode);
            }

            // Enable Line Renderer if there are at least two connected nodes
            lineRenderer.enabled = connectedNodes.Count >= 2;
        }
    }

    void UpdateLinePositions()
    {
        // Set the positions of the Line Renderer based on the connected nodes
        lineRenderer.positionCount = connectedNodes.Count;
        for (int i = 0; i < connectedNodes.Count; i++)
        {
            lineRenderer.SetPosition(i, connectedNodes[i].position);
        }
    }

    bool IsPuzzleSolved()
    {
        // Implement your puzzle-solving logic here based on the connected nodes
        // For example, check if the connected nodes form a specific pattern
        return false;
    }
}
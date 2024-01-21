using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool puzzle1 = false;
    private bool puzzle2 = false;

    public AudioClip powerUpAudio;

    private AudioSource audioSource;
    public Material glowingMaterial;
    // Start is called before the first frame update
    void Start()
    {

        // Get the AudioSource component on the GameManager object
        audioSource = GetComponent<AudioSource>();

        // Check if an AudioSource component is found
        if (audioSource == null)
        {
            // If AudioSource component is not found, add one to the GameManager object
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (powerUpAudio == null)
        {
            Debug.LogError("Win audio clip is not assigned in the Inspector.");
        }
        else
        {
            // Assign the audio clip to the AudioSource
            audioSource.clip = powerUpAudio;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if puzzle1 is true
        if (puzzle1)
        {
            // Find the GameObject with the name "cable2"
            GameObject cable2Object = GameObject.Find("cable2");

            // Check if the cable2Object is found
            if (cable2Object != null)
            {
                // Find the child object named "cylinder"
                Transform cylinderTransform = cable2Object.transform.Find("Cylinder");

                // Check if the cylinderTransform is found
                if (cylinderTransform != null)
                {
                    // Get the MeshRenderer component of the cylinderTransform
                    MeshRenderer cylinderRenderer = cylinderTransform.GetComponent<MeshRenderer>();

                    // Check if the MeshRenderer component is found
                    if (cylinderRenderer != null)
                    {
                        // Check if the material is found
                        if (glowingMaterial != null)
                        {
                            // Change the material of the cylinder to the newMaterial
                            cylinderRenderer.material = glowingMaterial;

                            puzzle1 = false;
                        }
                        else
                        {
                            Debug.LogError("Material 'newMaterial' not found in Resources folder.");
                        }
                    }
                    else
                    {
                        Debug.LogError("MeshRenderer component not found on cylinder object.");
                    }
                }
                else
                {
                    Debug.LogError("Cylinder object not found as a child of cable2 object.");
                }
            }
            else
            {
                Debug.LogError("cable2 object not found in the scene.");
            }
        }

        if (puzzle2)
        {
            GameObject cable4Object = GameObject.Find("cable4");

            if (cable4Object != null)
            {
                // Find the child object named "cylinder"
                Transform cylinderTransform = cable4Object.transform.Find("Cylinder");

                // Check if the cylinderTransform is found
                if (cylinderTransform != null)
                {
                    // Get the MeshRenderer component of the cylinderTransform
                    MeshRenderer cylinderRenderer = cylinderTransform.GetComponent<MeshRenderer>();

                    // Check if the MeshRenderer component is found
                    if (cylinderRenderer != null)
                    {
                        // Check if the material is found
                        if (glowingMaterial != null)
                        {
                            // Change the material of the cylinder to the newMaterial
                            cylinderRenderer.material = glowingMaterial;

                            puzzle2 = false;
                        }
                        else
                        {
                            Debug.LogError("Material 'newMaterial' not found in Resources folder.");
                        }
                    }
                    else
                    {
                        Debug.LogError("MeshRenderer component not found on cylinder object.");
                    }
                }
                else
                {
                    Debug.LogError("Cylinder object not found as a child of cable2 object.");
                }
            }
            else
            {
                Debug.LogError("cable2 object not found in the scene.");
            }
        }
    }

    public void wonPuzzle1() {
        puzzle1 = true;
        audioSource.Play();
    }

     public void wonPuzzle2() {
        puzzle2 = true;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLevel2 : MonoBehaviour
{
    private bool puzzle1 = false;
    private bool puzzle2 = false;
    private bool puzzle3 = false;

    private bool pause = false;
    
    public Canvas pauseScreen;

    public GameObject player;
    public GameObject house;

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
        
        if (puzzle1 && puzzle2 && puzzle3)
        {
            
           
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
        }

        if(pause)
        {
            pauseScreen.enabled = true;
            Time.timeScale = 0f;
        }
        else 
        {
            pauseScreen.enabled = false;
            Time.timeScale = 1f;
        }
       
    }

    public void wonPuzzle1() {
        puzzle1 = true;
        audioSource.Play();

         GameObject cable2Object = GameObject.Find("cable2");

            // Check if the cable2Object is found
            if (cable2Object != null)
            {
                Transform cylinderTransform = cable2Object.transform.Find("Cylinder");

                if (cylinderTransform != null)
                {
                    MeshRenderer cylinderRenderer = cylinderTransform.GetComponent<MeshRenderer>();

                    if (cylinderRenderer != null)
                    {
                        if (glowingMaterial != null)
                        {
                            cylinderRenderer.material = glowingMaterial;

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

     public void wonPuzzle2() {
        puzzle2 = true;
        audioSource.Play();

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
                Debug.LogError("cable4 object not found in the scene.");
            }
    }

    public void wonPuzzle3() {
        puzzle3 = true;
        audioSource.Play();

        GameObject cable6Object = GameObject.Find("cable6");

            if (cable6Object != null)
            {
                // Find the child object named "cylinder"
                Transform cylinderTransform = cable6Object.transform.Find("Cylinder");

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
                Debug.LogError("cable6 object not found in the scene.");
            }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevel2 : MonoBehaviour
{
    private bool puzzle1 = false;
    private bool puzzle2 = false;
    private bool puzzle3 = false;

    private bool pause = false;
    
    public Canvas pauseScreen;

    public GameObject player;
    public Transform door;

    public AudioClip powerUpAudio;

    private AudioSource audioSource;
    public Material glowingMaterial;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (powerUpAudio == null)
        {
            Debug.LogError("audio clip is not assigned in the Inspector.");
        }
        else
        {
            audioSource.clip = powerUpAudio;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (puzzle1 && puzzle2 && puzzle3)
        {
            float distanceToHouse = Vector3.Distance(player.transform.position, door.position);

            if(distanceToHouse < 5f)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("zuidpool");
            }
          
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
                       
                    }
                   
                }
               
            }
    }

     public void wonPuzzle2() {
        puzzle2 = true;
        audioSource.Play();

        GameObject cable4Object = GameObject.Find("cable4");

            if (cable4Object != null)
            {
                Transform cylinderTransform = cable4Object.transform.Find("Cylinder");

                if (cylinderTransform != null)
                {
                    MeshRenderer cylinderRenderer = cylinderTransform.GetComponent<MeshRenderer>();

                    if (cylinderRenderer != null)
                    {
                        if (glowingMaterial != null)
                        {
                            cylinderRenderer.material = glowingMaterial;

                        }
                       
                    }
                    
                }
              
            }
           
    }

    public void wonPuzzle3() {
        puzzle3 = true;
        audioSource.Play();

        GameObject cable6Object = GameObject.Find("cable6");

            if (cable6Object != null)
            {
                Transform cylinderTransform = cable6Object.transform.Find("Cylinder");

                if (cylinderTransform != null)
                {
                    MeshRenderer cylinderRenderer = cylinderTransform.GetComponent<MeshRenderer>();

                    if (cylinderRenderer != null)
                    {
                        if (glowingMaterial != null)
                        {
                            cylinderRenderer.material = glowingMaterial;

                        }
                      
                    }
                   
                }
                
            }
           
    }
}



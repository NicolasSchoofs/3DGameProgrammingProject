using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public Transform player; 
    public AudioSource audioSource;
    public float maxHoorbareAfstand = 10f; 

    private void Start()
    {
        
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (player == null || audioSource == null)
        {
            return;
        }

        
        float afstandNaarSpeler = Vector3.Distance(transform.position, player.position);

        
        float volumefactor = Mathf.Clamp01(1f - (afstandNaarSpeler / maxHoorbareAfstand));

        
        audioSource.volume = volumefactor;
    }
}


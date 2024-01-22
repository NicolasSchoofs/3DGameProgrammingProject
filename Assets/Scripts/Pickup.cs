using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int coinCounter = 0;  

    void Start()
    {
        UpdateCounterText();  
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Coin opgepakt!");
            coinCounter++;
            UpdateCounterText();
            Destroy(gameObject);
            Debug.Log(coinCounter);
            
        }
    }

    
    void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = "Vuilniszakken gevonden: " + coinCounter + "/10";
        }
    }

    
}

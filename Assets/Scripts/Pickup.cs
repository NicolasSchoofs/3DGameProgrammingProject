using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private GameManagerLevel1 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManagerLevel1>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager niet gevonden in de scene!");
        }

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
            gameManager?.addCount();
            UpdateCounterText();
            Destroy(gameObject);
            
            
        }
    }

    
    void UpdateCounterText()
    {

        int coinCounter = gameManager?.GetCoinCount() ?? 0;

        if (counterText != null)
        {
            counterText.text = "Vuilniszakken gevonden: " + coinCounter + "/10";
        }
    }

   

    
}

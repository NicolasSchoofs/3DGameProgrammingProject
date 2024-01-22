using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private int coinCounter = 0;

    public void addCount() 
    {
        coinCounter++;
        loadNextScene();

    }

    public void loadNextScene() {
    
        if(coinCounter >= 1)
        {
            SceneManager.LoadScene("lvl1-end");
        }
    }

    public int GetCoinCount() 
    {
        return coinCounter;
    }
}

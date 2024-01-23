using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int coinCounter = 0;


    private bool pause;
    public Canvas pauseScreen;




    void Update() 
    {

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
    public void addCount() 
    {
        coinCounter++;
        loadNextScene();

    }

    public void loadNextScene() {
    
        if(coinCounter >= 1)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("lvl1-end");
        }
    }

    public int GetCoinCount() 
    {
        return coinCounter;
    }
}

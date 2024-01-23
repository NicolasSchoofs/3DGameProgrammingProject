using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("lvl1-intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScreen()
    {
        SceneManager.LoadScene("level-1");
    }

    public void IntroButton()
    {
        SceneManager.LoadScene("lvl1-objective");
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene("level-2-intro");
    }

    public void GotoLevel2() 
    {
        SceneManager.LoadScene("level-2");
    }

}

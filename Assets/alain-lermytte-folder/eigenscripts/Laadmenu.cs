using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laadmenu : MonoBehaviour
{

    public string GeladenLevel;
    // Start is called before the first frame update
    public void LevelLaden()
    {
        //dit script is in de finale versie niet in gebruik

        // level 3

        SceneManager.LoadScene(GeladenLevel);
    }
}

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
        //laad level3. zou op einde naar startscherm moeten laden

        // level 3

        SceneManager.LoadScene(GeladenLevel);
    }
}

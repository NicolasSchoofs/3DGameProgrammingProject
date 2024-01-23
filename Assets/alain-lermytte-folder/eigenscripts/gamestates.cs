using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamestates : MonoBehaviour
{
    public GameObject speler;
    public GameObject player;
    public GameObject levelscherm;
    public GameObject introscherm;
    public GameObject eindscherm;
    public GameObject finish;
    public spelbestuurder spelbestuurder;
    public Text eindscoretekst;
    public testraketbeweginen bewegingen;
    public FPSController movement;
    public AudioListener geluid;

    private bool pause = false;
    public Canvas pauseScreen;


    public enum Gamestates
    {
        introductiescherm,
        level,
        eindscherm
    }

    public Gamestates gamestate = Gamestates.introductiescherm;
    // Start is called before the first frame update
    void Start()
    {
        if (speler == null)
        {
            speler = GameObject.FindWithTag("Player");
            print("speler gevonden");
        }

        // scorebord ophalen
        spelbestuurder = GameObject.FindWithTag("needed").GetComponent<spelbestuurder>();
        // audio ophalen
        geluid = player.GetComponentInChildren<AudioListener>();
        //bewegingen = GameObject.FindWithTag("Player").GetComponent<testraketbeweginen>();
    }

    // Update is called once per frame
    void Update()
    {

        
        float klikken = Input.GetAxis("Cancel");
        //print(klikken);

        switch (gamestate)
        {
            
            case Gamestates.level:
                if (klikken == 1)
                {
                    // test lezen input
                    print("ik zweer plechtig dat ik nobele plannen heb");
                }

                break;
            case Gamestates.eindscherm:
                if (klikken == 1)
                {
                    //gamestate = Gamestates.introductiescherm;
                    print("opnieuw!");
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    //huidige level laden voor testing
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    //player.transform.position = new Vector3(46, 1, -40);
                }
                break;

            
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


    public void StartLevel()
    {
        gamestate = Gamestates.level;
        geluid.enabled = true;
        introscherm.SetActive(false);
        levelscherm.SetActive(true);
        eindscherm.SetActive(false);
        //bewegingen.enabled = true;
        player.SetActive(true);
    }
    public void eindigen()
    {
        gamestate = Gamestates.eindscherm;
        geluid.enabled = false;
        levelscherm.SetActive(false);
        eindscherm.SetActive(true);
        //bewegingen.enabled = false;
        player.SetActive(false);
        if (spelbestuurder.punten == 1)
        {
            eindscoretekst.text = "\nGefeliciteerd\nJe vond " + spelbestuurder.punten + " pinguin\n\n" +
                "Hoewel de meeste pinguinsoorten niet bedreigd zijn voelen ook zij in het dagelijks leven het effect van de klimaatverandering\n" +
                "Het smelten van de poolkappen maken veilige plekken zoeken lastiger. Door de vissenvangst wordt eten zoeken moeilijker. Zeker als ze vastkomen in visnetten\n\n" +
                "Hopelijk ben je nu meer bewust van de problemen in de wereld\n";
                //"druk op escape om opnieuw te proberen";
        }
        else
        {
            eindscoretekst.text = "\nGefeliciteerd\nJe vond " + spelbestuurder.punten + " pinguins\n\n" +
            "Hoewel de meeste pinguinsoorten niet bedreigd zijn voelen ook zij in het dagelijks leven het effect van de klimaatverandering\n" +
            "Het smelten van de poolkappen maken veilige plekken zoeken lastiger. Door de vissenvangst wordt eten zoeken moeilijker. Zeker als ze vastkomen in visnetten\n\n" +
            "Hopelijk ben je nu meer bewust van de problemen in de wereld\n";
            //"druk op escape om opnieuw te proberen";
        }
        
        print("squadulah we are off");
    }
}

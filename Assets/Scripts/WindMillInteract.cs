using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindMillInteract : MonoBehaviour
{
    private string text = @"Aanschouw de windmolen, een symbool van hernieuwbare energie. Hier is een snelle gids:

Windkracht:
Deze draaiende bladen zetten windenergie om in elektriciteit, een schone alternatieve bron voor fossiele brandstoffen.

Oneindig en Schoon:
In tegenstelling tot eindige hulpbronnen is wind een oneindige, groene energiebron met minimale milieueffecten.

Milieuvriendelijke Elektriciteit:
De windmolen produceert schone energie, wat de uitstoot van broeikasgassen vermindert voor een gezondere planeet.

Voordelen voor de Gemeenschap:
Ondersteuning voor windenergie creëert banen, stimuleert economische groei en bevordert een duurzame toekomst.

Maak gebruik van de kracht van de wind en pleit voor duurzaamheid!";

    public GameObject player;

    private float interactionRange = 7f;

    public TMP_Text infoText;
    private bool active = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.InverseTransformPoint(player.transform.position);
        if(playerPosition.magnitude <= interactionRange)
        {

            if(!active)
            {
                infoText.text = "Press E to interact";
            }

            if(Input.GetKeyDown(KeyCode.E)) 
            {
                active = !active;
                infoText.text = text;
            }
        }
        else {
            active = false;
            infoText.text = "";
        }
    }
}

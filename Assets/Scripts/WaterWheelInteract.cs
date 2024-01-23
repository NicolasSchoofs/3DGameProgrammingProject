using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterWheelInteract : MonoBehaviour
{
    private string text = @"Voor je staat een opmerkelijk waterrad, een wonder van hernieuwbare energie. Hier is een snelle blik:

Hydropower Harmony:
Dit waterrad benut de energie van stromend water en zet het om in elektriciteit.

Natuurkracht:
In tegenstelling tot fossiele brandstoffen is water een voortdurende en milieuvriendelijke bron, waardoor het een duurzame krachtpatser is.

Schone Energie Waterval:
De opgewekte elektriciteit is schoon en laat een minimaal milieusporen achter.

Vindingrijk Mechanisme:
Het waterrad maakt gebruik van inventieve mechanica om de energie van stromend water om te zetten in een constante stroom van kracht.";

    public GameObject player;

    private float interactionRange = 10f;

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

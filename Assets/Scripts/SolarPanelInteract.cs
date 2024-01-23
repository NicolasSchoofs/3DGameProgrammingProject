using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SolarPanelInteract : MonoBehaviour
{
    private string text = @"Zonnepanelen benutten zonlicht om schone, hernieuwbare energie te creëren. Belangrijkste voordelen:

Hernieuwbare Energie: Vermindert afhankelijkheid van fossiele brandstoffen.

Koolstofvoetafdruk: Verlaagt emissies en bestrijdt klimaatverandering.

Energieonafhankelijkheid: Bevordert zelfvoorzienendheid.

Kosteneffectief: Lage bedrijfskosten, hoge efficiëntie.";

    public GameObject player;

    private float interactionRange = 11f;

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

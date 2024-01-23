using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweegMinimapIcoon : MonoBehaviour
{
    public GameObject speler; // de speler dat het minimapicoon volgt

    // Start is called before the first frame update
    void Start()
    {
        //speler ophalen
        if (speler)
        {
            Debug.Log("speler gevonden");
        }
        else
        {
            Debug.Log("speler niet gevonden");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //verplaats op de minimap zodat het boven de huidige locatie van de speler komt
        transform.position = new Vector3(speler.transform.position.x, 30 , speler.transform.position.z);
        transform.transform.rotation = Quaternion.LookRotation(speler.transform.forward, speler.transform.up);
    }
}

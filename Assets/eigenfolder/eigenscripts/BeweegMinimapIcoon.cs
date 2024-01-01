using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweegMinimapIcoon : MonoBehaviour
{
    public GameObject speler; // de speler dat het minimapicoon volgt

    // Start is called before the first frame update
    void Start()
    {
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
        transform.position = new Vector3(speler.transform.position.x, speler.transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweegCamera : MonoBehaviour
{
    public GameObject speler; // de speler dat het minimapicoon volgt
    private float zijwaarts;
    private float opwaarts;
    private float voorwaarts;

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
        zijwaarts = speler.transform.position.x;

        opwaarts = speler.transform.position.y;
        opwaarts += 0.4f;

        voorwaarts = speler.transform.position.z;
        voorwaarts += 7.3f;
        transform.position = new Vector3(zijwaarts, opwaarts, voorwaarts);
    }
}

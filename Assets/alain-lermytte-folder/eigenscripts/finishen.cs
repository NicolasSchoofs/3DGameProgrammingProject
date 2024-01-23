using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishen : MonoBehaviour
{

    public gamestates manager;
    // Start is called before the first frame update
    void Start()
    {
        // gamemanager ophalen
        manager = GameObject.FindWithTag("management").GetComponent<gamestates>();
        if (manager is not null)
        {
            print("found em");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // als speler op de finish komt eindig level
        print("HIII");
        if (other.gameObject.tag == "Player")
        {
            manager.eindigen();
        }
    }
}

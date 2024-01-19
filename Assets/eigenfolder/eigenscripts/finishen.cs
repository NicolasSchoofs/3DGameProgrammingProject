using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishen : MonoBehaviour
{

    public gamestates manager;
    // Start is called before the first frame update
    void Start()
    {
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
        print("HIII");
        if (other.gameObject.tag == "Player")
        {
            manager.eindigen();
        }
    }
}

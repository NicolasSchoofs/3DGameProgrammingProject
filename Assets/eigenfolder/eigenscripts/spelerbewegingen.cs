using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class testraketbeweginen : MonoBehaviour
{
    private Rigidbody kubus;
    // Start is called before the first frame update
    void Start()
    {
        kubus = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float sprongen = Input.GetAxis("Jump");
        float draaien = Input.GetAxis("Horizontal");
        float bewegen = Input.GetAxis("Vertical");

        VliegVooruit(sprongen);
        Ronddraaien(transform, draaien * -2f);
        voortbewegen(bewegen);
    }

    private void VliegVooruit (float totaal)
    {
        Vector3 kracht = transform.up * (totaal * 10);
        kubus.AddForce(kracht);
    }

    private void Ronddraaien (Transform richting, float aantal)
    {
        richting.Rotate(0, aantal , 0);
    }

    private void voortbewegen (float totaal)
    {
        Vector3 kracht = transform.forward * (totaal * 10);
        kubus.AddForce(kracht);
    }
}

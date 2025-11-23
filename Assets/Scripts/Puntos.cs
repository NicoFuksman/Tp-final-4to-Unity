using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    public int puntos = 0;
    public TextMeshProUGUI txtPuntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtPuntos.text = "Puntos: " + puntos;
    }

    void OnTriggerEnter(Collider other)
    {
        SeguirMano contable = other.GetComponent<SeguirMano>();

        if (other.CompareTag("Roja") && !contable.yaContado)
        {
            puntos += 1;
            contable.yaContado = true;
        }

            if (other.CompareTag("Azul") && !contable.yaContado)
        {
            puntos += 2;
            contable.yaContado = true;
        }

            if (other.CompareTag("Naranja") && !contable.yaContado)
        {
            puntos += 1;
            contable.yaContado = true;
        }

            if (other.CompareTag("Amarilla") && !contable.yaContado)
        {
            puntos += 3;
            contable.yaContado = true;
        }

            if (other.CompareTag("Violeta") && !contable.yaContado)
        {
            puntos += 2;
            contable.yaContado = true;
        }
    }
}

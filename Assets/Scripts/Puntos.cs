using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    public int puntos = 0;
    public TextMeshProUGUI txtPuntos;
    
    private Color colorOriginal;
    // Start is called before the first frame update
    void Start()
    {
        colorOriginal = txtPuntos.color;
    }

    // Update is called once per frame
    void Update()
    {
        txtPuntos.text = puntos.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        SeguirMano contable = other.GetComponent<SeguirMano>();

        if (other.CompareTag("Roja") && !contable.yaContado)
        {
            puntos += 1;
            StartCoroutine(CambiarColor());
            contable.yaContado = true;
        }

            if (other.CompareTag("Azul") && !contable.yaContado)
        {
            puntos += 2;
            StartCoroutine(CambiarColor());
            contable.yaContado = true;
        }

            if (other.CompareTag("Naranja") && !contable.yaContado)
        {
            puntos += 1;
            StartCoroutine(CambiarColor());
            contable.yaContado = true;
        }

            if (other.CompareTag("Amarilla") && !contable.yaContado)
        {
            puntos += 3;
            StartCoroutine(CambiarColor());
            contable.yaContado = true;
        }

            if (other.CompareTag("Violeta") && !contable.yaContado)
        {
            puntos += 2;
            StartCoroutine(CambiarColor());
            contable.yaContado = true;
        }

        IEnumerator CambiarColor()
        {
        txtPuntos.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        txtPuntos.color = colorOriginal;
        }
    }
}

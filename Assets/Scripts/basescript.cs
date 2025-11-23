using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basescript : MonoBehaviour
{
    public bool estarquieto = false;
    private Transform objetoAQuietar;

    void Update()
    {
        if (estarquieto && objetoAQuietar != null)
        {
            objetoAQuietar.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // si querés que funcione SOLO con el jugador:
        if (other.gameObject.name == "SimpleFPSController")
        {
            objetoAQuietar = other.transform;
            estarquieto = true;
        }
    }
}

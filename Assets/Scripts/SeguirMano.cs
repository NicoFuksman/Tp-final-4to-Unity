using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMano : MonoBehaviour
{
    private Transform mano;

    void Start()
    {
        // Busca automáticamente un objeto en la escena llamado "mano"
        GameObject manoObj = GameObject.Find("mano");

        if (manoObj != null)
        {
            mano = manoObj.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto llamado 'mano' en la escena.");
        }
    }

    void Update()
    {
        if (mano != null)
        {
            // Igualar la posición de la pelota a la del objeto mano
            transform.position = mano.position;
        }
    }
}
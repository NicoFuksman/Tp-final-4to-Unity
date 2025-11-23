using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroScript : MonoBehaviour
{
    public bool QuedanPelotas = true;

    public int colisionesActivas = 0;

    void OnCollisionEnter(Collision collision)
    {
        colisionesActivas++;

        // si hay al menos una colisión, entonces quedan pelotas
        QuedanPelotas = true;
    }

    void OnCollisionExit(Collision collision)
    {
        colisionesActivas--;

        // si ya no queda ninguna colisión activa → no quedan pelotas
        if (colisionesActivas <= 0)
        {
            colisionesActivas = 0;
            QuedanPelotas = false;
        }
    }
}

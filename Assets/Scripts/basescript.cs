using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class basescript : MonoBehaviour
{
    public bool estarquieto;
    public Rigidbody rbTarget;
    public CarroScript CarrosScript;
    public DeteccionPelotasRaycast deteccion;

    public int numeroDeBase; // 1 = derecha, 2 = medio, 3 = izquierda

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "SimpleFPSController")
        {
            FirstPersonController controller = other.GetComponent<FirstPersonController>();

            // --------- 🔥 BLOQUEAR BASE SI NO CUMPLE LOS REQUISITOS ---------
            // Solo permite entrar a esta base si ya hizo las anteriores
            if (deteccion.basesCompletadas < numeroDeBase - 1)
            {
                // No tiene permiso todavía
                controller.m_WalkSpeed = 5;
                controller.m_RunSpeed = 10;
                estarquieto = false;
                return;
            }

            // --------- ✔ SI YA TIENE PERMISO Y HAY PELOTAS ---------
            if (CarrosScript.QuedanPelotas == true)
            {
                controller.m_WalkSpeed = 0;
                controller.m_RunSpeed = 0;
                estarquieto = true;

                deteccion.CompletarBase(numeroDeBase);
            }
            else if (deteccion.pelotaenmano == false)
            {
                controller.m_WalkSpeed = 5;
                controller.m_RunSpeed = 10;
                estarquieto = false;
            }
        }
    }
}

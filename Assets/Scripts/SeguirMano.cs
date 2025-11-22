using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMano : MonoBehaviour
{
    [Header("Estado")]
    public bool agarrada = false;
    public bool agarrable = true;
    public bool yaContado = false;

    private Rigidbody rb;
    private Transform mano;

    public DeteccionPelotasRaycast DeteccionPelotas;

    [Header("Tiro")]
    public float fuerzaDisparo = 6f;     
    public float arcoTiro = 1.0f;   // Cuánto arco tiene el tiro (0.5 a 1.5 es realista)

    void Start()
    {
        DeteccionPelotas = FindObjectOfType<DeteccionPelotasRaycast>();

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("SeguirMano: falta Rigidbody en la pelota.");
        }

        GameObject manoObj = GameObject.Find("mano");
        if (manoObj != null)
            mano = manoObj.transform;
        else
            Debug.LogError("SeguirMano: no existe un objeto llamado 'mano' en la escena.");
    }

    void Update()
    {
        // Soltar/disparar con espacio SOLO si está agarrada
        if (Input.GetKeyDown(KeyCode.E) && agarrada)
        {
            SoltarPelota();
        }

        // Si está en la mano, seguirla
        if (agarrada && mano != null)
        {
            // Congelar física
            if (!rb.isKinematic)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Seguir la mano
            transform.position = mano.position;
            transform.rotation = mano.rotation;
        }
        else
        {
            // Volver física normal si ya no está agarrada
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }
        }
    }

    // Llamado por tu sistema de detección cuando agarrás la pelota
    public void AgarrarPelota()
    {
        agarrada = true;
        DeteccionPelotas.pelotaenmano = true;
    }

    public void SoltarPelota()
    {
        agarrada = false;
        DeteccionPelotas.pelotaenmano = false;
        agarrable = false;

        rb.isKinematic = false;

        // --------- DIRECCIÓN DEL DISPARO CON ARCO ---------
        Vector3 direccion = (mano.forward * 1f + mano.up * arcoTiro).normalized;

        // --------- ADD FORCE PARA LA PARÁBOLA ---------
        rb.AddForce(direccion * fuerzaDisparo, ForceMode.Impulse);

        rb.constraints = RigidbodyConstraints.None;

        // --------- AUTODESTRUIR PELOTA A LOS 10s ---------
        Destroy(gameObject, 10f);
    }
}

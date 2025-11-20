using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirMano : MonoBehaviour

{
    [Header("Estado")]
    public bool agarrada = false;

    private Rigidbody rb;
    private Transform mano;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("PelotaSeguirMano_Update: falta Rigidbody en el GameObject.");
        }

        GameObject manoObj = GameObject.Find("mano");
        if (manoObj != null)
            mano = manoObj.transform;
        else
            Debug.LogError("PelotaSeguirMano_Update: no existe un objeto llamado 'mano' en la escena.");
    }

    void Update()
    {
        // Soltar con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoltarPelota();
        }

        if (agarrada && mano != null)
        {
            // Mientras está agarrada: hacemos kinematic para evitar conflictos de física
            if (!rb.isKinematic)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Igualar posición continuamente en Update (sin teletransportes "una vez")
            transform.position = mano.position;

            // Evitar rotación: igualamos rotación al Empty (o fijala a Quaternion.identity si querés)
            transform.rotation = mano.rotation;
        }
        else
        {
            // Si no está agarrada, devolvemos la física normal (solo si estaba kinematic)
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
            }
        }
    }

    public void AgarrarPelota()
    {
        agarrada = true;
    }

    public void SoltarPelota()
    {
        agarrada = false;

        // Al soltar, permitir rotaciones y física normal
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}

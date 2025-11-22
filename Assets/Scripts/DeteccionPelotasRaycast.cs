using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionPelotasRaycast : MonoBehaviour
{
    public float rayDistance = 5f;
    public bool pelotaenmano = false;
    public float rayRadius = 1f;

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position + transform.forward * 0.2f;
        Vector3 direction = transform.forward;

        if (Physics.SphereCast(origin, rayRadius, direction, out hit, rayDistance, layerMask))
        {
            Debug.Log("Golpeamos: " + hit.collider.gameObject.name);

            GameObject pelotavista = hit.collider.gameObject;
            SeguirMano SeguirManoScript = pelotavista.GetComponent<SeguirMano>();

            if (pelotaenmano == false && SeguirManoScript .agarrable == true)
            {
                    if (hit.collider.CompareTag("Azul"))
                {
                    SeguirManoScript.AgarrarPelota();
                }

                    if (hit.collider.CompareTag("Violeta"))
                {
                    SeguirManoScript.AgarrarPelota();
                }

                    if (hit.collider.CompareTag("Roja"))
                {
                    SeguirManoScript.AgarrarPelota();
                }

                    if (hit.collider.CompareTag("Amarilla"))
                {
                    SeguirManoScript.AgarrarPelota();
                }

                    if (hit.collider.CompareTag("Naranja"))
                {
                    SeguirManoScript.AgarrarPelota();
                }
            }
            else 
            {
                Debug.Log ("Ya hay una pelota agarrada");
            }

            Debug.DrawRay(origin, direction * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(origin, direction * rayDistance, Color.green);
        }


    }
}

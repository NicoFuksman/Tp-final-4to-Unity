using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class Basketball : MonoBehaviour
{
    [Header("Physical settings")]
    public float mass = 0.62f;
    public float linearDrag = 0.05f;
    public float angularDrag = 0.05f;
    public PhysicMaterial physMat; // Asigna uno creado en el editor con bounciness ~0.75

    Rigidbody rb;
    SphereCollider sc;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();

        // Rigidbody settings
        rb.mass = mass;
        rb.useGravity = true;
        rb.drag = linearDrag;
        rb.angularDrag = angularDrag;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Collider / PhysicMaterial
        if (physMat != null) sc.material = physMat;
    }

    // Método simple para "lanzar" la pelota en la dirección dada
    // direction debe estar normalizada. releaseAngleVel es velocidad inicial deseada (m/s).
    public void Throw(Vector3 direction, float initialSpeed)
    {
        direction.Normalize();
        Vector3 impulse = direction * (mass * initialSpeed);
        rb.AddForce(impulse, ForceMode.Impulse);
    }

    // Ejemplo: calcular la velocidad vertical necesaria para alcanzar targetHeight desde releaseHeight
    public static float VerticalSpeedToReachHeight(float releaseHeight, float targetHeight)
    {
        float g = Mathf.Abs(Physics.gravity.y); // normalmente 9.81
        float dh = targetHeight - releaseHeight;
        if (dh <= 0f) return 0f;
        return Mathf.Sqrt(2f * g * dh);
    }
}

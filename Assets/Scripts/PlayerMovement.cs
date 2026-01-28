using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    // A c�mera/ponto da sala atual (setado quando entra no trigger)
    public Transform currentRoomCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Se n�o tiver c�mera da sala, usa o eixo do mundo
        if (currentRoomCamera == null)
        {
            Vector3 fallback = new Vector3(h, 0f, v).normalized * speed;
            rb.linearVelocity = new Vector3(fallback.x, rb.linearVelocity.y, fallback.z);
            return;
        }

        // Dire��es baseadas na c�mera (no ch�o)
        Vector3 camForward = currentRoomCamera.forward;
        Vector3 camRight = currentRoomCamera.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        // Movimento reto no mundo, alinhado com a c�mera
        Vector3 move = (camRight * h + camForward * v);

        if (move.sqrMagnitude > 1f) move.Normalize();

        Vector3 vel = move * speed;
        rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
    }
}

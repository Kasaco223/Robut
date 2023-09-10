using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 10f;
    public float upwardForce = 2f;
    private Rigidbody rb;
    private float lunarGravity = -1.62f; // Aproximadamente 1/6 de la gravedad terrestre

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody en este objeto. Por favor, añade uno.");
        }
    }

    void FixedUpdate()
    {
        // Aplica la gravedad lunar
        rb.AddForce(0, lunarGravity * rb.mass, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.forward * force + transform.up * upwardForce, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-transform.right * force + transform.up * upwardForce, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(transform.right * force + transform.up * upwardForce, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(-transform.forward * force + transform.up * upwardForce, ForceMode.Impulse);
        }
    }
}

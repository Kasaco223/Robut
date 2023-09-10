using UnityEngine;

public class Robut: MonoBehaviour
{
    public GameObject ball;
    public float speed = 10f;
    public float maxDistance = 10f;
    private Rigidbody rb;
    private Vector3 originalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody en este objeto. Por favor, añade uno.");
        }

        originalPosition = transform.position;
    }

    void FixedUpdate()
    {
        float distanceToBall = Vector3.Distance(transform.position, ball.transform.position);

        if (distanceToBall > maxDistance)
        {
            // Mueve al perro hacia la pelota
            Vector3 direction = (ball.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
        else if (distanceToBall < 1f)
        {
            // Mueve la pelota de vuelta a su posición original
            ball.transform.position = originalPosition;
        }
    }
}

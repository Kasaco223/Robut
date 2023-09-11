using UnityEngine;

public class Robut : MonoBehaviour
{
    public GameObject ball;
    public float speed = 10f;
    private float maxDistance = 10f;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private bool isFetching = false;

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

        if (!isFetching && distanceToBall > maxDistance)
        {
            // Mueve al perro hacia la pelota
            Vector3 direction = (ball.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            maxDistance = 0.25f;
        }
        else if (distanceToBall < 4f)
        {
            // El perro ha alcanzado la pelota, ahora debe traerla de vuelta
            isFetching = true;
        }

        if (isFetching)
        {

            if (Vector3.Distance(transform.position, originalPosition) < 3f)
            {
                // El perro y la pelota han vuelto a su posición original
                isFetching = false;
                maxDistance = 10f;
            }
            else
            {
                // Mueve la pelota y al perro de vuelta a su posición original
                ball.transform.position = Vector3.MoveTowards(ball.transform.position, originalPosition, speed * Time.fixedDeltaTime);
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.fixedDeltaTime);

            }
           

        }
    }
}

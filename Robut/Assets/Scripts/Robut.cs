using UnityEngine;

public class Robut : MonoBehaviour
{
    
    public float speed = 10f;
    private float maxDistance = 10f;
    private Rigidbody rb;
    private Vector3 originalPosition;
    private bool isFetching = false;

    private GameObject mainCamera;  
    private GameObject taggedObjectMouth;
    private GameObject taggedObjectBall;

    private float startTime;
    private bool canFollow = false;


    void Start()
    {
        startTime = Time.time;
        taggedObjectMouth = GameObject.FindGameObjectWithTag("BallMouthTag");
        taggedObjectBall = GameObject.FindGameObjectWithTag("BallTag");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody en este objeto. Por favor, añade uno.");
        }

        originalPosition = taggedObjectBall.transform.position;
    }

    void PonerPelota()
    {
        if (taggedObjectMouth != null)
        {
            MeshRenderer meshRenderer = taggedObjectMouth.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
        }
        if (taggedObjectBall != null)
        {
            MeshRenderer meshRenderer = taggedObjectBall.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }
    }
    void QuitarPelota()
    {
        if (taggedObjectMouth != null)
        {
            MeshRenderer meshRenderer = taggedObjectMouth.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }
        if (taggedObjectBall != null)
        {
            MeshRenderer meshRenderer = taggedObjectBall.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (Time.time - startTime >= 13f)
        {
            canFollow = true;
        }

        float distanceToBall = Vector3.Distance(transform.position, taggedObjectBall.transform.position);

        Vector3 targetDirection;

        if (!isFetching && distanceToBall > maxDistance)
        {
            targetDirection = taggedObjectBall.transform.position - transform.position; // Mira a la pelota
        }
        else
        {
            targetDirection = mainCamera.transform.position - transform.position; // Mira a la cámara principal
        }

        targetDirection.y = 0; // Esto hace que el objeto solo gire en el eje Y
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        targetRotation *= Quaternion.Euler(0, 90, 0); // Añade una rotación adicional de 90 grados en el eje Y
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);



        if (!isFetching && distanceToBall > maxDistance)
        {
            if (canFollow)
            {
                 // Mueve al perro hacia la pelota
            Vector3 direction = (taggedObjectBall.transform.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            maxDistance = 0.25f;

            }
           
        }
        else if (distanceToBall < 0.25f)
        {
            // El perro ha alcanzado la pelota, ahora debe traerla de vuelta
            PonerPelota();
            // Teletransporta el objeto con el tag "BallTag" a su posición original
            GameObject ballToTeleport = GameObject.FindWithTag("BallTag");
            if (ballToTeleport != null)
            {
                ballToTeleport.transform.position = originalPosition;
            }
        }
        if (Vector3.Distance(transform.position, originalPosition) < 2f) { QuitarPelota(); isFetching = true; // El perro y la pelota han vuelto a su posición original
          isFetching = false; maxDistance = 10f; 
        }
        if (transform.position.y < -1)
        {
            TeleportToLayer22();
        }
    }
    void TeleportToLayer22()
    {
        // Teletransporta al personaje a la capa y=22
        Vector3 newPosition = transform.position;
        newPosition.y = 22f;
        transform.position = newPosition;
    }
}
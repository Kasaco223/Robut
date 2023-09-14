using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // el objeto que quieres seguir
    private bool canFollow = false;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // Espera 15 segundos antes de comenzar a seguir al objetivo
        if (Time.time - startTime >= 15f)
        {
            canFollow = true;
        }

        // Si la variable canFollow es verdadera, la cámara se orienta hacia el objetivo
        if (canFollow)
        {
            transform.LookAt(target);
        }
    }
}

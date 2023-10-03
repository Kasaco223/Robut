using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject robutTag; // el objeto que quieres seguir
    private bool canFollow = false;
    private float startTime;
    private Camera mainCamera;

    void Start()
    {
        robutTag = GameObject.FindGameObjectWithTag("RobutTag");
        mainCamera = Camera.main;
        startTime = Time.time;
    }

    void Update()
    {
        // Espera 15 segundos antes de comenzar a seguir al objetivo
        if (Time.time - startTime >= 16f)
        {
            canFollow = true;
        }

        // Si la variable canFollow es verdadera, la cámara se orienta hacia el objetivo
        if (canFollow)
        {
            Debug.Log("está siguiendo");
            mainCamera.transform.LookAt(robutTag.transform);
            mainCamera.Render();
        }
    }
}

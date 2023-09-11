using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // el objeto que quieres seguir

    void Update()
    {
        transform.LookAt(target); // la c�mara se orienta hacia el objetivo
    }
}
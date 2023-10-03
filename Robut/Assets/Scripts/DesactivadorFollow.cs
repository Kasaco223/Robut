using UnityEngine;

public class DesactivadorFollow : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableCameraFollow", 13f);
        Invoke("EnableCameraFollow", 15f);
    }

    void DisableCameraFollow()
    {
        GetComponent<CameraFollow>().enabled = false;
    }

    void EnableCameraFollow()
    {
        GetComponent<CameraFollow>().enabled = true;
    }
}
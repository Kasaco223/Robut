using System.Collections;
using UnityEngine;

public class AtencionController : MonoBehaviour
{
    private GameObject mainCamera; //camara
    private Vector3 originalRotation;
    private bool isLookingAtTarget = false;
    private int priority = 0;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        originalRotation = mainCamera.transform.rotation.eulerAngles;
        LookAtTargetForSeconds(15, 1); // la cámara mirará a este objeto al inicio durante 15 segundos
    }

    void Update()
    {
        if (isLookingAtTarget && priority == 1)
        {
            mainCamera.transform.LookAt(transform); // la cámara se orienta hacia este objeto
        }
        else
        {
            mainCamera.transform.rotation = Quaternion.Euler(originalRotation); // la cámara regresa a su rotación original
        }
    }

    public void LookAtTargetForSeconds(float seconds, int newPriority)
    {
        StartCoroutine(LookAtTargetCoroutine(seconds, newPriority));
    }

    private IEnumerator LookAtTargetCoroutine(float seconds, int newPriority)
    {
        if (newPriority >= priority)
        {
            priority = newPriority;
            isLookingAtTarget = true;
            yield return new WaitForSeconds(seconds);
            isLookingAtTarget = false;
            priority = 0;
        }
    }
}

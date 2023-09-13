using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{

    AudioSource audio1;

    [SerializeField] AudioClip pelota;
    [SerializeField] AudioClip correr;
    [SerializeField] AudioClip ladrido;

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            audio1.PlayOneShot(pelota);
            Invoke("ladrar", 0.5f);
        }
    }

    private void ladrar()
    {
        audio1.PlayOneShot(ladrido);
    }
}

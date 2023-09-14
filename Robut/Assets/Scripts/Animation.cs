using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        // Obtiene los componentes Animator y Rigidbody del objeto
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Comprueba si el objeto se est� moviendo
        if (rb.velocity.magnitude < 0.001f) // Puedes ajustar este valor seg�n tus necesidades
        {
            // Si el objeto se est� moviendo, activa la animaci�n "Salto"
            animator.SetBool("IsMoving", false);
            
        }
        else
        {
            // Si el objeto no se est� moviendo, vuelve al estado por defecto (puedes cambiar esto a cualquier estado que quieras)
            animator.SetBool("IsMoving", true);
        }
    }
}

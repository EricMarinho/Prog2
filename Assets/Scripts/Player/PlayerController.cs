using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que controla o jogador
public class PlayerController : MonoBehaviour
{
    // Velocidade do jogador
    public float speed = 10.0f;
    // Velocidade de rotação do jogador
    public float turnSpeed = 25.0f;
    // Input horizontal
    public float horizontalInput;
    // Input vertical
    public float forwardInput;

    // Animator do jogador
    private Animator animator;

    private void Awake()
    {
        // Pega o componente Animator
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Pega o input do jogador
        horizontalInput = Input.GetAxis("Horizontal");
        // Pega o input do jogador
        forwardInput = Input.GetAxis("Vertical");

        // Move o jogador
        transform.Translate( new Vector3(horizontalInput, 0, forwardInput) * Time.deltaTime * speed);

        // Define a velocidade do jogador no Animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(forwardInput));
        // Define a direção do jogador no Animator
        animator.SetFloat("MovX", horizontalInput);
        // Define a direção do jogador no Animator
        animator.SetFloat("MovY", forwardInput);
    }

}

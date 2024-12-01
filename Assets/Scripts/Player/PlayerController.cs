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

    // Range
    [SerializeField] private float range = 5.0f;

    // Força
    [SerializeField] private float force = 3.0f;

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
        Move();

        // Define a velocidade do jogador no Animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(forwardInput));
        // Define a direção do jogador no Animator
        animator.SetFloat("MovX", horizontalInput);
        // Define a direção do jogador no Animator
        animator.SetFloat("MovY", forwardInput);

        // Joga inimigos pertos para longe
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ExplodeInimigosProximos();
        }

        // Atrai inimigos próximos
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            AtraiaInimigosProximos();
        }
    }

    // Método que explode inimigos
    private void ExplodeInimigosProximos()
    {
        // Pega todos os elementos no range
        Collider[] elementosNoRange = Physics.OverlapSphere(transform.position, range);

        // Para cada elemento no range
        foreach (var elemento in elementosNoRange)
        {
            // Se o elemento for um inimigo
            if (elemento.CompareTag("Inimigo"))
            {
                // Adiciona uma força de explosão no elemento
                elemento.GetComponent<Rigidbody>().AddForce((elemento.transform.position - transform.position) * force, ForceMode.Impulse);
            }
        }

    }

    // Método que move o jogador
    private void Move()
    {
        // Calcula a direção e normaliza
        Vector3 dir = new Vector3(horizontalInput, 0, forwardInput).normalized;
        // Calcula o ângulo do movimento baseado na camera
        float targetAngulo = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        if (dir.magnitude >= 0)
        {
            // Calcula o ângulo suavemente
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngulo, ref turnSpeed, 0.1f);
            // Rotaciona o jogador
            transform.rotation = Quaternion.Euler(0, angulo, 0);
            // Move o jogador
            transform.Translate(dir * speed * Time.deltaTime, Space.Self);
        }
    }

    // Atraia inimigos próximos
    private void AtraiaInimigosProximos()
    {
        // Pega todos os elementos no range
        Collider[] elementosNoRange = Physics.OverlapSphere(transform.position, range);

        // Para cada elemento no range
        foreach (var elemento in elementosNoRange)
        {
            // Se o elemento for um inimigo
            if (elemento.CompareTag("Inimigo"))
            {
                // Adiciona uma força de explosão no elemento
                elemento.GetComponent<Rigidbody>().AddForce((elemento.transform.position - transform.position) * -force, ForceMode.Impulse);
            }
        }

    }

}

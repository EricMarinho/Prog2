using UnityEngine;
using UnityEngine.AI;

// Interface para ser implementada por classes que representam NPCs
public interface INPC
{
    // M�todo para mover o NPC
    void Move();

}
// Classe que representa um NPC
public class NPC : MonoBehaviour, INPC
{
    // Dados do NPC
    [SerializeField] private NPCData npcData;
    // Alvo para o NPC se mover
    private Transform target;
    // Componente NavMeshAgent do NPC
    private NavMeshAgent agent;

    private void Start()
    {
        // Inicializa o NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        // Configura a velocidade do NavMeshAgent pegando o dado do NPCData
        agent.speed = npcData.speed;

        // Define o alvo do NPC como o jogador
        SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private void Update()
    {
        // Move o NPC
        Move();
    }

    // M�todo para definir o alvo do NPC
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    // M�todo para mover o NPC
    public void Move()
    {
        // Se o alvo for nulo, retorna
        if (target == null)
        {
            return;
        }

        Debug.Log(Vector3.Distance(transform.position, target.position));

        //Se a dist�ncia entre o NPC e o alvo for menor que a dist�ncia de parada
        if (Vector3.Distance(transform.position, target.position) < npcData.stopDistance)
        {
            // Para o NavMeshAgent
            agent.isStopped = true;
            return;
        }
        // Continua o NavMeshAgent
        agent.isStopped = false;

        // Define o destino do NavMeshAgent como a posi��o do alvo
        agent.SetDestination(target.position);
    }
}

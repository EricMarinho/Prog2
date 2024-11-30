using UnityEngine;

// Classe que representa os dados de um NPC
[CreateAssetMenu(fileName = "NPCData", menuName = "NPCData", order = 1)]
public class NPCData : ScriptableObject
{
    // ID do NPC
    public string id;
    // Velocidade do NPC
    public float speed;
    // Distancia para parar de seguir o alvo
    public float stopDistance;
}

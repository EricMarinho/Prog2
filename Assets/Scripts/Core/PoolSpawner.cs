using NaughtyAttributes;
using UnityEngine;

// Classe que gerencia o pool de objetos
public class PoolSpawner : MonoBehaviour
{
    // Referência ao ObjectPooler
    private ObjectPooler objectPoolerInstance;
    // Tamanho da fila
    private int queueSize;

    private void Start()
    {
        // Referência ao ObjectPooler
        objectPoolerInstance = ObjectPooler.instance;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        // Verifica se a fila está vazia
        queueSize = objectPoolerInstance.poolDictionary[tag].Count;
        // Se a fila estiver vazia, instancia um novo objeto
        if (queueSize == 0)
        {
            // Para cada pool, verifica se a tag é a mesmaw
            foreach (ObjectPooler.Pool pool in objectPoolerInstance.pools)
            {
                // Se a tag for a mesma, instancia um novo objeto
                if (pool.tag == tag)
                {
                    objectPoolerInstance.newObj(pool, objectPoolerInstance.poolDictionary[tag]);
                }
            }
        }

        // Pega o objeto da fila
        GameObject objectToSpawn = objectPoolerInstance.poolDictionary[tag].Dequeue();
        // Ativa o objeto
        objectToSpawn.SetActive(true);
        // Posiciona o objeto
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        // Retorna o objeto
        return objectToSpawn;
    }

    // Método que retorna o objeto para a fila
    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objectPoolerInstance.poolDictionary[tag].Enqueue(objectToReturn);
    }

    // Método que instancia um novo objeto usando Naughty Attributes, tornando possível
    // chamar o método pelo inspetor do Unity
    [Button ("Spawnar NPC")]
    public void SpawnNPC()
    {
        SpawnFromPool("npc1", transform.position, Quaternion.identity);
    }

    // Método que retorna o objeto para a fila usando Naughty Attributes, tornando possível
    // chamar o método pelo inspetor do Unity
    [Button("Returnar NPC")]
    public void ReturnNPC()
    {
        // Pega o NPC
        GameObject npc = FindAnyObjectByType<NPC>().gameObject;
        // Se o NPC for nulo, retorna
        if (npc == null) return;

        // Retorna o NPC para a fila
        ReturnToPool("npc1", npc);
    }
}
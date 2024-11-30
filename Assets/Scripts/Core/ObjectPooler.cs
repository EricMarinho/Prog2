using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que gerencia o pool de objetos
public class ObjectPooler : MonoBehaviour
{
    // Classe que define o pool
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // Dicionário que armazena os objetos do pool
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Lista de pools
    public List<Pool> pools;
    // Referência ao PoolSpawner
    private PoolSpawner poolSpawner;

    // Instância do ObjectPooler
    #region Singleton
    public static ObjectPooler instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        // Referência ao PoolSpawner
        poolSpawner = GetComponent<PoolSpawner>();
        // Inicializa o dicionário
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        // Para cada pool, cria uma fila de objetos
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                // Instancia um novo objeto
                newObj(pool, objectPool);
            }

            // Adiciona a fila ao dicionário
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Método que instancia um novo objeto
    public void newObj(Pool pool, Queue<GameObject> objectPool)
    {
        GameObject obj = Instantiate(pool.prefab);
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

}
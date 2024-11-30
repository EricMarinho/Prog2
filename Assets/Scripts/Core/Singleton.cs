using UnityEngine;

// Classe que implementa o padrão Singleton para ser herdado por outras classes
public class Singleton<T> : MonoBehaviour
{
    // Propriedade para acessar a instância da classe
    public static T Instance { get; private set; }

    private void Awake()
    {
        // Se a instância for nula, define a instância como a própria classe
        if (Instance == null)
        {
            // Define a instância como a própria classe
            Instance = (T)(object)this;
            // Mantém o objeto na cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroi o objeto
            Destroy(gameObject);
        }
    }
}

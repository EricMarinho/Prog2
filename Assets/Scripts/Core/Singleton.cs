using UnityEngine;

// Classe que implementa o padr�o Singleton para ser herdado por outras classes
public class Singleton<T> : MonoBehaviour
{
    // Propriedade para acessar a inst�ncia da classe
    public static T Instance { get; private set; }

    private void Awake()
    {
        // Se a inst�ncia for nula, define a inst�ncia como a pr�pria classe
        if (Instance == null)
        {
            // Define a inst�ncia como a pr�pria classe
            Instance = (T)(object)this;
            // Mant�m o objeto na cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroi o objeto
            Destroy(gameObject);
        }
    }
}

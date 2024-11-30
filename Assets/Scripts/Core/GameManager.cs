using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que gerencia o jogo que herda de Singleton
public class GameManager : Singleton<GameManager>
{
    //
    private void Awake()
    {
        // Adiciona o evento de início do jogo
        GameEvents.Instance.OnGameStart += StartGame;
    }

    private void Start()
    {
        // Invoca o evento de início do jogo
        GameEvents.Instance.OnGameStart?.Invoke();
    }

    // Método para iniciar o jogo
    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    // Método para finalizar o jogo
    public void EndGame()
    {
    }
}

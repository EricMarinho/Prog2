using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que gerencia o jogo que herda de Singleton
public class GameManager : Singleton<GameManager>
{
    //
    private void Awake()
    {
        // Adiciona o evento de in�cio do jogo
        GameEvents.Instance.OnGameStart += StartGame;
    }

    private void Start()
    {
        // Invoca o evento de in�cio do jogo
        GameEvents.Instance.OnGameStart?.Invoke();
    }

    // M�todo para iniciar o jogo
    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    // M�todo para finalizar o jogo
    public void EndGame()
    {
    }
}

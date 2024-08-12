using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Awake()
    {
        GameEvents.Instance.OnGameStart += StartGame;
    }

    private void Start()
    {
        GameEvents.Instance.OnGameStart?.Invoke();
    }

    public void StartGame()
    {

    }

    public void EndGame()
    {
    }
}

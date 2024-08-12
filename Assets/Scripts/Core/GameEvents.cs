using System;

public class GameEvents : Singleton<GameEvents>
{
    public Action OnGameStart;
    public Action OnGameEnd;
}
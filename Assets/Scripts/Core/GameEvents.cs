using System;

// Classe que gerencia os eventos do jogo
public class GameEvents : Singleton<GameEvents>
{
    // Evento para quando o jogo come�a
    public Action OnGameStart;
    // Evento para quando o jogo termina
    public Action OnGameEnd;
}
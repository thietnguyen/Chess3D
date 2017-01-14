using UnityEngine;
using System.Collections;

public class BaseGameCTL : MonoBehaviour {

    public static BaseGameCTL Current;

    private EGameState _gameState;
    private EPlayer currentPlayer;

    public EGameState GameState
    {
        get
        {
            return _gameState;
        }

        set
        {
            _gameState = value;
        }
    }

    public EPlayer CurrentPlayer
    {
        get
        {
            return currentPlayer;
        }

        private set
        {
            currentPlayer = value;
        }
    }

    void Awake()
    {
        Current = this;
        currentPlayer = EPlayer.WHITE;
        GameState = EGameState.PLAYING;
    }

    public void SwichTurn()
    {
        CurrentPlayer = CurrentPlayer == EPlayer.WHITE ? EPlayer.BLACK : EPlayer.WHITE;
    }
}

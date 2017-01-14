using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseGameCTL : MonoBehaviour {

    public static BaseGameCTL Current;

    private EGameState _gameState;
    private EPlayer currentPlayer;

    public Text t_PlayerWin;

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

    public EGameState CheckGameState()
    {
        return EGameState.PLAYING;
    }

    public void GameOver(EPlayer winPlayer)
    {
        if (winPlayer == EPlayer.BLACK)
            t_PlayerWin.text = "WINNER: BLACK";
        else
            t_PlayerWin.text = "WINNER: WHITE";
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BaseGameCTL : MonoBehaviour {

    public MovieTexture movie;

    public static BaseGameCTL Current;

    private EGameState _gameState;
    private EPlayer currentPlayer;

    public Texture2D m_StartMenu;
    public Texture2D m_btnStartGame;
    public Texture2D m_btnExitGame;
    public Texture2D m_MainMenu;
    public Texture2D m_GameOver;

    public Texture2D m_WhitePlayerWin;
    public Texture2D m_BlackPlayerWin;

    private Texture2D _playerWin;

    public Text t_PlayerWin;

    private EPlayer _winner;

    public static Rect screenRect
        (float tx,
         float ty,
         float tw,
         float th)
    {
        float x1 = tx * Screen.width;
        float y1 = ty * Screen.height;
        float sw = tw * Screen.width;
        float sh = th * Screen.height;
        return new Rect(x1, y1, sw, sh);
    }


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
        GameState = EGameState.START;
        //movie.Play();
    }


    //void Update()
    //{
    //    if (!movie.isPlaying)
    //    {
    //        movie.Stop();
    //        GameObject.Find("Plane").SetActive(false);
    //    }
    //}

    public void OnGUI()
    {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

        if (GameState == EGameState.START)
        {
            GUI.DrawTexture(screenRect(0.0f, 0.0f, 1.0f, 1.0f), m_StartMenu);
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            centeredStyle.fontSize = (int)(Screen.height * 0.025);
            if (GUI.Button(screenRect(0.35f, 0.6f, 0.3f, 0.1f), m_btnStartGame))
            {
                GameState = EGameState.PLAYING;
                ChessBoard.Current.InitChessBoard();
                ChessBoard.Current.InitChess();
            }
            if (GUI.Button(screenRect(0.35f, 0.75f, 0.3f, 0.1f), m_btnExitGame))
            {
                Application.Quit();
            }

        }

        if (GameState == EGameState.GAME_OVER)
        {
            CreateFinishView();
        }

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
        _winner = winPlayer;
        if (_winner == EPlayer.BLACK)
            _playerWin = m_BlackPlayerWin;
        else
            _playerWin = m_WhitePlayerWin;
        GameState = EGameState.GAME_OVER;
    }

    private void CreateFinishView()
    {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        centeredStyle.normal.textColor = Color.red;
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        GUI.DrawTexture(screenRect(0.3f, 0.2f, 0.4f, 0.4f), _playerWin);

        if (GUI.Button(screenRect(0.42f, 0.75f, 0.16f, 0.1f), m_MainMenu))
        {
            Application.LoadLevel("TwoPlayer");
        }
    }
}

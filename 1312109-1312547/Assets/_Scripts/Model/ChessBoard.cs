using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChessBoard : MonoBehaviour {

    public GameObject cellPrefap;
    public LayerMask CellLayerMask = 0;
    public static ChessBoard Current;

    private List<BaseChess> chess;

    private Cell _currentSelectedCell = null;
    private Vector3 basePosition = Vector3.zero;
    private Cell[][] _cell;
    public Cell[][] Cell { get { return _cell; } }



    //khoi tao ban co
    private float cell_size = -1;
    public float CELL_SIZE
    {
        get
        {
            if (cell_size < 0)
                cell_size = cellPrefap.GetComponent<Cell>().SIZE;
            return cell_size;
        }
    }

    //xu ly su kien tren ban co

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        //if (BaseGameCTL.Current.GameState == EGameState.PLAYING)
        //{
        //    InitChessBoard();
        //    InitChess();
        //}
    }

    public void Update()
    {
        if (BaseGameCTL.Current.GameState == EGameState.PLAYING)
        {
            CheckUserInput();
        }
    }

    private void CheckUserInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000, CellLayerMask.value))
            {
                Cell newCell = hit.collider.GetComponent<Cell>();

                switch (newCell.State)
                {
                    case Ecellstate.NORMAL:
                        if (newCell.CurrentChess != null && newCell.CurrentChess.Player == BaseGameCTL.Current.CurrentPlayer)
                        {
                            if (_currentSelectedCell != null)
                            {
                                _currentSelectedCell.SetCellState(Ecellstate.NORMAL);
                                if (_currentSelectedCell.CurrentChess != null)
                                    _currentSelectedCell.CurrentChess.BeUnselected();
                            }
                            _currentSelectedCell = newCell;
                            _currentSelectedCell.SetCellState(Ecellstate.SELECTED);
                        }
                        break;

                    case Ecellstate.TAGETED:
                        if (newCell.CurrentChess == null)
                        {
                            _currentSelectedCell.MakeAMove(newCell);
                        }
                        else
                        {
                            if (newCell.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                            {
                                _currentSelectedCell.CurrentChess.Attack(newCell);
                            }
                        }
                        break;
                }
            }
        }

    }

    //them o co
    [ContextMenu("InitChessBoard")]
    public void InitChessBoard()
    {
        basePosition = Vector3.zero + new Vector3(-3.5f * CELL_SIZE, 0, 0);
        _cell = new Cell[8][];
        for (int i = 0;i < 8;i++ )
            _cell[i] = new Cell[8];

        for(int i = 0;i < 8;i++ )
        {
            for (int j = 0;j < 8;j++)
            {
                GameObject c = GameObject.Instantiate(cellPrefap, CanculatePosition(i, j),
                    Quaternion.identity) as GameObject;
                c.transform.parent = this.transform.GetChild(0);

                _cell[i][j] = c.GetComponent<Cell>();
                _cell[i][j].SetLocation(new CLocation(i, j));


                if ((i + j) % 2 == 0)
                    _cell[i][j].Color = Ecellcolor.WHITE;
                else
                    _cell[i][j].Color = Ecellcolor.BLACK;
            }
        }
    }

    //them co vao o

    [ContextMenu("InitChess")]
    public void InitChess()
    {
        chess = new List<BaseChess>();

        List<ChessInfo> list = new List<ChessInfo>();

        //White
        list.Add(new ChessInfo() { Name1 = "W_TOT_1", Path1 = "Chess/W_Tot", X1 = 0, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_2", Path1 = "Chess/W_Tot", X1 = 1, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_3", Path1= "Chess/W_Tot", X1 = 2, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_4", Path1 = "Chess/W_Tot", X1 = 3, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_5", Path1 = "Chess/W_Tot", X1 = 4, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_6", Path1 = "Chess/W_Tot", X1 = 5, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_7", Path1 = "Chess/W_Tot", X1 = 6, Y1 = 1 });
        list.Add(new ChessInfo() { Name1 = "W_TOT_8", Path1 = "Chess/W_Tot", X1 = 7, Y1 = 1 });

        list.Add(new ChessInfo() { Name1 = "W_XE_1", Path1 = "Chess/W_Xe", X1 = 0, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_XE_2", Path1 = "Chess/W_Xe", X1 = 7, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_NGUA_1", Path1 = "Chess/W_Ma", X1 = 1, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_NGUA_2", Path1 = "Chess/W_Ma", X1 = 6, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_TUONG_1", Path1 = "Chess/W_Tuong", X1 = 2, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_THUONG_2", Path1 = "Chess/W_Tuong", X1 = 5, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_KING_1", Path1 = "Chess/W_King", X1 = 3, Y1 = 0 });
        list.Add(new ChessInfo() { Name1 = "W_QUEEN_1", Path1 = "Chess/W_Hau", X1 = 4, Y1 = 0 });

        //Black
        list.Add(new ChessInfo() { Name1 = "B_TOT_1", Path1 = "Chess/B_Tot", X1 = 0, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_2", Path1 = "Chess/B_Tot", X1 = 1, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_3", Path1 = "Chess/B_Tot", X1 = 2, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_4", Path1 = "Chess/B_Tot", X1 = 3, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_5", Path1 = "Chess/B_Tot", X1 = 4, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_6", Path1 = "Chess/B_Tot", X1 = 5, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_7", Path1 = "Chess/B_Tot", X1 = 6, Y1 = 6 });
        list.Add(new ChessInfo() { Name1 = "B_TOT_8", Path1 = "Chess/B_Tot", X1 = 7, Y1 = 6 });

        list.Add(new ChessInfo() { Name1 = "B_XE_1", Path1 = "Chess/B_Xe", X1 = 0, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_XE_2", Path1 = "Chess/B_Xe", X1 = 7, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_NGUA_1", Path1 = "Chess/B_Ma", X1 = 1, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_NGUA_2", Path1 = "Chess/B_Ma", X1 = 6, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_TUONG_1", Path1 = "Chess/B_Tuong", X1 = 2, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_THUONG_2", Path1 = "Chess/B_Tuong", X1 = 5, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_KING_1", Path1 = "Chess/B_King", X1 = 3, Y1 = 7 });
        list.Add(new ChessInfo() { Name1 = "B_QUEEN_1", Path1 = "Chess/B_Hau", X1 = 4, Y1 = 7 });

        foreach (var item in list)
        {
            GameObject GO = GameObject.Instantiate<GameObject>(ResourcesCTL.Instance.GetGameObject(item.Path1));
            GO.transform.parent = this.transform.GetChild(1);
            GO.name = item.Name1;

            BaseChess p = GO.GetComponent<BaseChess>();
            p.SetInfo(item, _cell[item.X1][item.Y1]);
            chess.Add(p);
        }

    }

    public Vector3 CanculatePosition(int i, int j)
    {
        return basePosition + new Vector3(i * CELL_SIZE, 0, j * CELL_SIZE);
    }

    public void DestroyChessBoard()
    {
        chess = new List<BaseChess>();
        _cell = new Cell[8][];
    }

}

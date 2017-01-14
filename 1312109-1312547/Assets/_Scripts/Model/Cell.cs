using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    private Ecellcolor _color;

    private Transform cellHoverObj;
    private Transform cellSelectedObj;

    public BaseChess CurrentChess { get; private set; }


    public Ecellcolor Color
    {
        get
        {
            return _color;
        }

        set
        {
            _color = value;
            switch (_color)
            {
                case Ecellcolor.BLACK:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.BlackCellMaterial;
                    break;
                case Ecellcolor.WHITE:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.WhiteCellMaterial;
                    break;
                default:
                    break;
            }
        }
    }


    //Vi tri toa do tren ban co
    public CLocation Location { get; private set; }
    public void SetLocation(CLocation location)
    {
        this.Location = location;
    }
    private Ecellstate _state;
    public Ecellstate State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
            switch (_state)
            {
                case Ecellstate.NORMAL:
                    cellSelectedObj.gameObject.SetActive(false);
                    break;
                case Ecellstate.SELECTED:
                    cellSelectedObj.gameObject.SetActive(true);
                    CurrentChess.BeSelected();
                    break;
                case Ecellstate.TAGETED:
                    cellSelectedObj.gameObject.SetActive(true);
                    break;
            }
        }
    }

    public float SIZE
    {
        get
        {
            return GetComponent<Renderer>().bounds.size.x;
        }
    }

    void Awake()
    {
        cellSelectedObj = this.transform.GetChild(1);
    }

    protected void Start()
    {
        //cellHoverObj = this.transform.GetChild(0);
        //cellSelectedObj = this.transform.GetChild(1);

        //State = Ecellstate.NORMAL;
    }

    //Thay doi trang thai
    public void SetCellState(Ecellstate cellState)
    {
        this.State = cellState;
    }

    public void SetPiece(BaseChess chess)
    {
        this.CurrentChess = chess;
    }

    public void MakeAMove(Cell targetedCell)
    {
        Debug.Log("MakeAMove : " + targetedCell.Location);
        CurrentChess.Move(targetedCell);
        State = Ecellstate.NORMAL;
        CurrentChess = null;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public abstract class BaseChess : MonoBehaviour {

    protected List<Cell> _targetedCell = new List<Cell>();
    protected Cell _currentCell;

    [SerializeField]
    private Vector3 offsetPosition;
    public ChessInfo Info { get; private set; }

    [SerializeField]
    protected EPlayer _player;

    public EPlayer Player
    {
        get
        {
            return _player;
        }

        protected set
        {
            _player = value;
        }
    }

    public CLocation Location { get; private set; }

    private Vector2 _originalLocation;
   

    public void SetInfo(ChessInfo info, Cell newCell)
    {
        this.Info = info;
        SetNewLocation(newCell);
    }

    private int setPosCount = 0;

    protected void SetNewLocation(Cell newCell)
    {
        setPosCount++;
        if (setPosCount > 1)
            this._currentCell.SetPiece(null);
        this._currentCell = newCell;
        newCell.SetPiece(this);
        this.Location = newCell.Location;
        //this.transform.position = offsetPosition + new Vector3(Location.X * ChessBoard.Current.CELL_SIZE, 0,
        //    Location.Y * ChessBoard.Current.CELL_SIZE);

        this.transform.DOMove(offsetPosition + new Vector3(Location.X * ChessBoard.Current.CELL_SIZE, 0,
            Location.Y * ChessBoard.Current.CELL_SIZE), 1f);

    }
    public virtual void Move(Cell targetedCell)
    {
        this.SetNewLocation(targetedCell);

        BeUnselected();

        BaseGameCTL.Current.SwichTurn();
    }

    public virtual void Attack(Cell targetedCell)
    {
        targetedCell.CurrentChess.BeAttackedBy(this);

        _currentCell.SetCellState(Ecellstate.NORMAL);
        this.SetNewLocation(targetedCell);
        BeUnselected();

        BaseGameCTL.Current.SwichTurn();

    }

    public virtual void BeAttackedBy(BaseChess enemy)
    {
        GameObject.Destroy(this.gameObject);
        _currentCell.SetPiece(null);
    }

    public abstract void BeSelected();

    public void BeUnselected()
    {
        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.NORMAL);
        _targetedCell.Clear();
    }
}

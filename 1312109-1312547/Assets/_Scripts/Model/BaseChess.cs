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

    protected void SetNewLocation(Cell newCell)
    {
        this._currentCell = newCell;
        newCell.SetPiece(this);
        this.Location = newCell.Location;
        //this.transform.position = offsetPosition + new Vector3(Location.X * ChessBoard.Current.CELL_SIZE, 0,
        //    Location.Y * ChessBoard.Current.CELL_SIZE);

        this.transform.DOMove(offsetPosition + new Vector3(Location.X * ChessBoard.Current.CELL_SIZE, 0,
            Location.Y * ChessBoard.Current.CELL_SIZE), 1f);

    }
    public abstract void Move(Cell targetedCell);

    public abstract void BeSelected();

    public void BeUnselected()
    {
        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.NORMAL);
        _targetedCell.Clear();
    }
}

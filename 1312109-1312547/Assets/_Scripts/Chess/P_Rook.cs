using UnityEngine;
using System.Collections;
using System;

public class P_Rook : BaseChess {
    //public override void Move(Cell targetedCell)
    //{
    //    this.SetNewLocation(targetedCell);

    //    BeUnselected();

    //    BaseGameCTL.Current.SwichTurn();
    //}
    public override void BeSelected()
    {
        for (int x = this.Location.X+1; x<8; x++)
        {
            Cell c = ChessBoard.Current.Cell[x][this.Location.Y];
            if (c.CurrentChess == null)
            {
                _targetedCell.Add(c);
            }
            else
            {
                if (c.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                {
                    _targetedCell.Add(c);
                }
                break;
            }
        }
        for (int x = this.Location.X - 1; x >= 0; x--)
        {
            Cell c = ChessBoard.Current.Cell[x][this.Location.Y];
            if (c.CurrentChess == null)
            {
                _targetedCell.Add(c);
            }
            else
            {
                if (c.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                {
                    _targetedCell.Add(c);
                }
                break;
            }
        }

        for (int y = this.Location.Y+1; y<8; y++)
        {
            Cell c = ChessBoard.Current.Cell[this.Location.X][y];
            if (c.CurrentChess == null)
            {
                _targetedCell.Add(c);
            }
            else
            {
                if (c.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                {
                    _targetedCell.Add(c);
                }
                break;
            }
        }
        for (int y = this.Location.Y - 1; y >=0; y--)
        {
            Cell c = ChessBoard.Current.Cell[this.Location.X][y];
            if (c.CurrentChess == null)
            {
                _targetedCell.Add(c);
            }
            else
            {
                if (c.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                {
                    _targetedCell.Add(c);
                }
                break;
            }
        }


        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

    //public override void Attack(Cell targetedCell)
    //{
    //    targetedCell.CurrentChess.BeAttackedBy(this);

    //    _currentCell.SetCellState(Ecellstate.NORMAL);
    //    this.SetNewLocation(targetedCell);
    //    BeUnselected();

    //    BaseGameCTL.Current.SwichTurn();
    //}

    //public override void BeAttackedBy(BaseChess enemy)
    //{
    //    GameObject.Destroy(this.gameObject);
    //    _currentCell.SetPiece(null);
    //}
}

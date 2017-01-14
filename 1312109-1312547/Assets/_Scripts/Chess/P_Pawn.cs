using UnityEngine;
using System.Collections;
using System;

public class P_Pawn : BaseChess {

    private bool isFirstMoved = true;

    public override void Move(Cell targetedCell)
    {
        isFirstMoved = false;

        this.SetNewLocation(targetedCell);

        BeUnselected();

        BaseGameCTL.Current.SwichTurn();
    }

    public override void BeSelected()
    {
        switch (this._player)
        {
            case EPlayer.BLACK:
                BeSelected_Black();
                break;
            case EPlayer.WHITE:
                BeSelected_White();
                break;
        }
    }

    private void BeSelected_White()
    {
        if (isFirstMoved)
        {
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y + 2]);
        }

        _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y + 1]);

        if (Location.X > 0 && ChessBoard.Current.Cell[Location.X - 1][Location.Y + 1].CurrentChess != null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X - 1][Location.Y + 1]);

        if (Location.X < 7 && ChessBoard.Current.Cell[Location.X + 1][Location.Y + 1].CurrentChess != null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X + 1][Location.Y + 1]);

        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

    private void BeSelected_Black()
    {
        if (isFirstMoved)
        {
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y - 2]);
        }

        _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y - 1]);

        if (Location.X > 0 && ChessBoard.Current.Cell[Location.X - 1][Location.Y - 1].CurrentChess != null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X - 1][Location.Y - 1]);

        if (Location.X < 7 && ChessBoard.Current.Cell[Location.X + 1][Location.Y - 1].CurrentChess != null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X + 1][Location.Y - 1]);

        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }
}

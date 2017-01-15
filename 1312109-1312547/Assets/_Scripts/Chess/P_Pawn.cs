using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class P_Pawn : BaseChess
{

    private bool isFirstMoved = true;

    public override void Move(Cell targetedCell)
    {
        isFirstMoved = false;
        base.Move(targetedCell);
        //if ((BaseGameCTL.Current.CurrentPlayer == EPlayer.WHITE && targetedCell.Location.Y == 7) || (BaseGameCTL.Current.CurrentPlayer == EPlayer.BLACK && targetedCell.Location.Y == 0))
        //{
        //    this.SetNewLocation(targetedCell);
        //    this._currentCell = null;
        //    GameObject.Destroy(targetedCell.CurrentChess);
        //    BaseChess pawn_invol = new P_Queen();
        //    targetedCell.SetPiece(pawn_invol);
        //    Debug.Log("Tien hoa");
        //}
        //else
        //    this.SetNewLocation(targetedCell);
        //base.BeUnselected();
        //BaseGameCTL.Current.SwichTurn();
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
            if (ChessBoard.Current.Cell[Location.X][Location.Y + 2].CurrentChess == null && ChessBoard.Current.Cell[Location.X][Location.Y + 1].CurrentChess == null)
                _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y + 2]);
        }

        if (ChessBoard.Current.Cell[Location.X][Location.Y + 1].CurrentChess == null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y + 1]);

        if (Location.X > 0 && ChessBoard.Current.Cell[Location.X - 1][Location.Y + 1].CurrentChess != null && ChessBoard.Current.Cell[Location.X - 1][Location.Y + 1].CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X - 1][Location.Y + 1]);

        if (Location.X < 7 && ChessBoard.Current.Cell[Location.X + 1][Location.Y + 1].CurrentChess != null && ChessBoard.Current.Cell[Location.X + 1][Location.Y + 1].CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X + 1][Location.Y + 1]);

        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

    private void BeSelected_Black()
    {
        if (isFirstMoved)
        {
            if (ChessBoard.Current.Cell[Location.X][Location.Y - 2].CurrentChess == null && ChessBoard.Current.Cell[Location.X][Location.Y - 1].CurrentChess == null)
                _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y - 2]);
        }

        if (ChessBoard.Current.Cell[Location.X][Location.Y - 1].CurrentChess == null)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X][Location.Y - 1]);

        if (Location.X > 0 && ChessBoard.Current.Cell[Location.X - 1][Location.Y - 1].CurrentChess != null && ChessBoard.Current.Cell[Location.X - 1][Location.Y - 1].CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X - 1][Location.Y - 1]);

        if (Location.X < 7 && ChessBoard.Current.Cell[Location.X + 1][Location.Y - 1].CurrentChess != null && ChessBoard.Current.Cell[Location.X + 1][Location.Y - 1].CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
            _targetedCell.Add(ChessBoard.Current.Cell[Location.X + 1][Location.Y - 1]);

        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);

    }
}

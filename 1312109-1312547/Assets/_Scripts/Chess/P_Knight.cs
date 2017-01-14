using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class P_Knight : BaseChess
{

    public override void BeSelected()
    {
        List<CLocation> locs = getTargetableLocation();
        foreach (var c in locs)
        {
            Cell cell = ChessBoard.Current.Cell[c.X][c.Y];
            if (cell.CurrentChess == null)
            {
                _targetedCell.Add(cell);
            }
            else if (cell.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                _targetedCell.Add(cell);
        }

        //int[] x_array = new int[8] { -1, -2, -2, -1, 1, 2, 2, 1 };
        //int[] y_array = new int[8] { -2, -1, 1, 2, 2, 1, -1, -2 };
        //for (int i = 0; i < 8; i++)
        //{
        //    int PosX = this.Location.X - 1 + x_array[i];
        //    int PosY = this.Location.Y - 1 + y_array[i];
        //    Debug.Log(PosX);
        //    Debug.Log(PosY);
        //    if (PosX >= 0 && PosX <= 7 && PosY >= 0 && PosY <= 7)
        //    {
        //        Debug.Log(PosX);
        //        Debug.Log(PosY);
        //        Cell c = new Cell();
        //            c = (ChessBoard.Current.Cell[PosX][PosY]);
        //        if (c.CurrentChess == null)
        //        {
        //            _targetedCell.Add(c);
        //        }
        //        else
        //        {
        //            if (c.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
        //            {
        //                _targetedCell.Add(c);
        //            }
        //        }
        //    }
        //}
        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

    private List<CLocation> getTargetableLocation()
    {
        List<CLocation> list = new List<CLocation>();
        CLocation c;
        c = new CLocation(this.Location.X + 2, this.Location.Y - 1);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X + 2, this.Location.Y + 1);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X - 2, this.Location.Y - 1);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X - 2, this.Location.Y + 1);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X + 1, this.Location.Y + 2);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X + 1, this.Location.Y - 2);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X - 1, this.Location.Y + 2);
        if (checkLocation(c))
            list.Add(c);
        c = new CLocation(this.Location.X - 1, this.Location.Y - 2);
        if (checkLocation(c))
            list.Add(c);


        return list;
    }

    private bool checkLocation(CLocation c)
    {
        if (c.X >= 0 && c.X <= 7 && c.Y >= 0 && c.Y <= 7)
            return true;
        else
            return false;
    }
}

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class P_King : BaseChess {

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

        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

    private List<CLocation> getTargetableLocation()
    {
        List<CLocation> list = new List<CLocation>();
        CLocation c;


        int[] x_array = new int[8] { -1, -1, -1, 0, 1, 1, 1, 0 };
        int[] y_array = new int[8] { -1, 0, 1, 1, 1, 0, -1, -1 };

        for (int i = 0; i < 8; i++)
        {
            c = new CLocation(this.Location.X + x_array[i], this.Location.Y + y_array[i]);
            if (Helper.checkLocation(c))
                list.Add(c);
        }

        return list;
    }
}

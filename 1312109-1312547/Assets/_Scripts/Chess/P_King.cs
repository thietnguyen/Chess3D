using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class P_King : BaseChess {

    public override void BeSelected()
    {
        List<CLocation> list = new List<CLocation>();

        CLocation c;

        //0 +1
        c = new CLocation(Location.X, Location.Y + 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //0 -1
        c = new CLocation(Location.X, Location.Y - 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //+1 0
        c = new CLocation(Location.X + 1, Location.Y);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //-1 0
        c = new CLocation(Location.X - 1, Location.Y);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //+1 +1
        c = new CLocation(Location.X + 1, Location.Y + 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //+1 -1
        c = new CLocation(Location.X + 1, Location.Y - 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //-1 +1
        c = new CLocation(Location.X - 1, Location.Y + 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        //-1 -1
        c = new CLocation(Location.X - 1, Location.Y - 1);
        if (CHelper.CheckLocation(c))
            list.Add(c);

        foreach (var item in list)
        {
            Cell cell = ChessBoard.Current.Cell[item.X][item.Y];
            if (cell.CurrentChess == null)
                _targetedCell.Add(cell);
            else if (cell.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                _targetedCell.Add(cell);
        }
        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

}

using UnityEngine;
using System.Collections;
using System;

public class P_Bishop : BaseChess {

    public override void BeSelected()
    {
        int[] x_array = new int[4] { -1, -1, 1, 1};
        int[] y_array = new int[4] { -1, 1, -1, 1};

        for (int i = 0; i<4; i++)
        {
            CLocation c = this.Location;
            while (true)
            {
                c = new CLocation(c.X + x_array[i], c.Y + y_array[i]);
                if (Helper.checkLocation(c))
                {
                    Cell cell = ChessBoard.Current.Cell[c.X][c.Y];
                    if (cell.CurrentChess != null)
                    {
                        if (cell.CurrentChess.Player != BaseGameCTL.Current.CurrentPlayer)
                            _targetedCell.Add(cell);
                        break;
                    }
                    _targetedCell.Add(cell);
                }
                else
                    break;
                
            }
        }
        
        foreach (var item in _targetedCell)
            item.SetCellState(Ecellstate.TAGETED);
    }

}

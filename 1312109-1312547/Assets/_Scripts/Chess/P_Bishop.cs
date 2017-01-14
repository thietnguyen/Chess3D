using UnityEngine;
using System.Collections;
using System;

public class P_Bishop : BaseChess {

    public override void BeSelected()
    {
        CLocation c;
        c = this.Location;
        while (true)
        {
            c = new CLocation(c.X + 1, c.Y + 1);
            if (CHelper.CheckLocation(c))
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
            else { break; }

            c = this.Location;
            while (true)
            {
                c = new CLocation(c.X + 1, c.Y - 1);
                if (CHelper.CheckLocation(c))
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
                else { break; }
            }


            //3. Trái trên : x-- y++
            c = this.Location;
            while (true)
            {
                c = new CLocation(c.X - 1, c.Y + 1);
                if (CHelper.CheckLocation(c))
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
                else { break; }
            }


            //4. Trái dưới : x-- y--
            c = this.Location;
            while (true)
            {
                c = new CLocation(c.X - 1, c.Y - 1);
                if (CHelper.CheckLocation(c))
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
                {
                    break;
                }
            }



            foreach (var item in _targetedCell)
                item.SetCellState(Ecellstate.TAGETED);
        }
    }
}

using UnityEngine;
using System.Collections;
using System;

public class P_Queen : BaseChess {
    public override void BeSelected()
    {
        BishopMove();
        RookMove();
    }


    private void BishopMove()
    {
        int[] x_array = new int[4] { -1, -1, 1, 1 };
        int[] y_array = new int[4] { -1, 1, -1, 1 };

        for (int i = 0; i < 4; i++)
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

    private void RookMove()
    {
        for (int x = this.Location.X + 1; x < 8; x++)
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

        for (int y = this.Location.Y + 1; y < 8; y++)
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
        for (int y = this.Location.Y - 1; y >= 0; y--)
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
}

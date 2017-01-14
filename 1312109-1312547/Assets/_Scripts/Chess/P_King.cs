using UnityEngine;
using System.Collections;
using System;

public class P_King : BaseChess {
    public override void Move(Cell targetedCell)
    {

    }
    public override void BeSelected()
    {
    }

    public override void Attack(Cell targetedCell)
    {
        throw new NotImplementedException();
    }

    public override void BeAttackedBy(BaseChess enemy)
    {
        throw new NotImplementedException();
    }
}

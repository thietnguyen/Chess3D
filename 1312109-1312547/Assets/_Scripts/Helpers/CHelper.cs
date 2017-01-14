using UnityEngine;
using System.Collections;

public class CHelper{

	public static bool CheckLocation(CLocation c)
    {
        if (c.X >= 0 && c.X <= 7 && c.Y >= 0 && c.Y <= 7)
            return true;
        return false;
    }
}

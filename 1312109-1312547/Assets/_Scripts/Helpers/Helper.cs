using UnityEngine;
using System.Collections;

public class Helper {

    public static bool checkLocation(CLocation c)
    {
        if (c.X >= 0 && c.X <= 7 && c.Y >= 0 && c.Y <= 7)
            return true;
        else
            return false;
    }
}

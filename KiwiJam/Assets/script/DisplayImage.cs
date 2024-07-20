using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 1)
                currentWall = 1;
            else if (value == 0)
                currentWall = 1;
            else
                currentWall = value;
        }
    }
    private int currentWall;

}

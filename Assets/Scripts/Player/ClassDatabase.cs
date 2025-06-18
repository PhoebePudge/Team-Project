using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDatabase
{
    public CharacterClass character;
    public ClassDatabase(int index)
    {
        if (index < 0)
        {
            index = 0;
        }
        if (index > 9)
        {
            index = 9;
        }
        switch (index)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }
}

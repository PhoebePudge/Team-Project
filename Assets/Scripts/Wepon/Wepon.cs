using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon
{
    public Sprite Icon;
    public string Name;
    public int Damage;
    [Range(0f,1f)]
    public float SwingSpeed;
    public Wepon(Sprite ICON, string NAME, int DAMAGE, float SWINGSPEED)
    {
        Icon = ICON; Name = NAME; Damage = DAMAGE; SwingSpeed = SWINGSPEED;
    }
}

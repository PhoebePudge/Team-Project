using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponDatabase{
    public Wepon wepon;
    public WeponDatabase(int index){
        if (index < 0){
            index = 0;
        }
        if (index > 9){
            index = 9;
        }
        switch (index) { 
            case 0:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/Axe.png"), "Axe", 20, 0.6f);
                break;
            case 1:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/Bow.png"), "Bow", 14, 0.7f);
                break;
            case 2:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/Crossbow.png"), "CrossBow", 17, 0.9f);
                break;
            case 3:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/Javelin.png"), "Javelin", 15, 0.6f);
                break;
            case 4:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_01.png"), "BastardSword", 16, 0.7f);
                break;
            case 5:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_02.png"), "LongSword", 18, 0.8f);
                break;
            case 6:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_03.png"), "VeryLongSword", 20, 0.6f);
                break;
            case 7:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_04.png"), "Dagger", 14, 1f);
                break;
            case 8:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_05.png"), "BiggerAxe", 22, 0.4f);
                break;
            case 9:
                wepon = new Wepon((Sprite)Resources.Load("Assets/Resources/weapons_06.png"), "PointyThing", 15, 1f);
                break;
        }
    }
}

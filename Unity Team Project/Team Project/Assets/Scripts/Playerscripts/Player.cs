using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//player class
[System.Serializable]
public class Player
{
    #region attributes

    //public------------------------------
    [Range(1,4)]public int affix;
    public GameObject gm;
    
    public bool isActive = true;
    //components--------------------------
    private Rigidbody2D rb;
    private Collider2D co;


    #endregion

    //runs on creation after attributes have been entered
    //public Player(string GivenClassName, GameObject tempalteGM, int GivenAffrix, Sprite DefaultInventoryBoarderImage){
    //    gm = tempalteGM;
    //    affix = GivenAffrix;
    //    Debug.Log(affix);
    //    ClassName = GivenClassName;
    //    textname = new GameObject();
    //    textname.name = "Text Box " + affix;
    //    gm.name = "Player " + affix;
    //    tn = textname.AddComponent<TextMeshPro>();
    //    //log creation
    //    Debug.Log("player: " + affix + " created from: " + gm.name);
    //    //add components
    //    rb = gm.AddComponent<Rigidbody2D>();
    //    co = gm.AddComponent<BoxCollider2D>();
    //    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    //    if (!isActive){
    //        //deactivate player
    //    }
    //}
    #region UI
  

}

#endregion
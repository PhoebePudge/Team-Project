using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weapon
{

    #region attributes

    //public variariables
    public Sprite Sprite;
    public string Name;
    public int typeIndex;
    public int damage;
    public GameObject gm;
    public Player pl;

    //components
    private SpriteRenderer sr;


    #endregion

    public weapon(){
        //gameobject
        gm = new GameObject();
        gm.AddComponent<PlayerMovement>();
        //component
        sr = gm.AddComponent<SpriteRenderer>();
        sr.sprite = Sprite;
        Debug.Log(Name + " given!");
        gm.name = Name;
        gm.GetComponent<SpriteRenderer>().sortingOrder = 90;
    }

    //on attack button press
    public void Attack(){
        switch (typeIndex){
            case 1:
                if (Physics2D.OverlapCircle(gm.transform.position, 3)){
                    if (Physics2D.OverlapCircle(gm.transform.position, 3).gameObject.name != pl.gm.name){
                        findPlayer(Physics2D.OverlapCircle(gm.transform.position, 3).gameObject.name);
                    }
                }
                break;
            case 2:
                //ranged wepon


                break;
        }
    }

    void findPlayer(string searchedName){
        GameObject g = GameObject.Find("Controller");
        for (int i = 0; i < g.GetComponent<GameScript>().players.Length; i++){
            if (g.GetComponent<GameScript>().players[i].name == searchedName){
                Debug.Log(g.GetComponent<GameScript>().players[i].name + " is Attacking " + Physics2D.OverlapCircle(gm.transform.position, 2).gameObject.name + " with " + Name + " dealing " + damage + " damage!");
                //g.GetComponent<GameScript>().players[i].health -= damage;
            }
        }
        
    }
    //called each update to display
    public void DisplayWeapon(Vector3 Position){
        if (gm != null){
            gm.transform.position = Position;
        }

    }
}

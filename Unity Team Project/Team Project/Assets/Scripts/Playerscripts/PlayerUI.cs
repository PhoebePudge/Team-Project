using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public int affix;
    public string ClassName;
    //health------------------------------
    const int healthMax = 100;
    public float health = healthMax;
    private bool needToRespawn = false;

    //lives-------------------------------
    const int livesMax = 3;
    private int lives = livesMax;

    //text displayable--------------------
    GameObject textname;
    TextMeshPro tn;
    const float textboxOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Display()
    {
        if (!needToRespawn)
        {
            tn.text = "Player " + affix.ToString() + " (" + ClassName + ")";
            tn.text += "\n" + (int)health + " / " + healthMax;
            tn.text += "\n" + lives + " / " + livesMax;
            //if (inventory[inventoryIndex] != null){
            //tn.text += "\n" + "Equiped: " + inventory[inventoryIndex].Name;
            //}
        }
        else
        {
            tn.text = "Player " + affix.ToString();
            tn.text += "\n" + "Press B to respawn!";
        }
        CheckHealth();
        tn.fontSize = 3;
        gameObject.GetComponent<PlayerMovement>().Velocity = gameObject.GetComponent<Rigidbody>().velocity;
        tn.alignment = TextAlignmentOptions.BottomGeoAligned;
        textname.transform.position = gameObject.transform.position + new Vector3(0, textboxOffset, 0);
    }
    private void CheckHealth()
    {
        if (health < 0)
        {
            health = healthMax;
            lives--;
            gameObject.SetActive(false);

            needToRespawn = true;
        }
        if (needToRespawn)
        {
            if (Input.GetButtonDown("P" + affix + "Return"))
            {
                Debug.Log("Player " + affix + " has respawned and is now at " + lives + " lives!");
                needToRespawn = false;
                gameObject.SetActive(true);
            }
        }
    }
}

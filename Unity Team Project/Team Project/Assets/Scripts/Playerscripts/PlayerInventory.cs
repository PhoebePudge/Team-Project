using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour{
    public int affix;
    private GameObject defaultInventoryParent;

    public Sprite inventoryBoarderImage;
    public struct inventoryVisual{public GameObject icon; public GameObject boarders;}
    private inventoryVisual[] Display = new inventoryVisual[3];

    int timeSinceOpen = 0;
    bool isDisplayed = false;

    bool justClicked = false;
    private weapon currentlySelectedWeapon;
    private weapon[] inventory = new weapon[3];
    private int inventoryIndex = 0;
    private Vector3 weaponTransformOffset = new Vector3(0.4f, 0, 0);
    void Start(){
        for (int i = 0; i < 3; i++){
            StartInventory(i);
        }
        defaultInventoryParent = new GameObject();
        defaultInventoryParent.name = "Player " + affix + " inventory system";
        HideInventory();
        
        ChangeWeapon(0);
    }

    private void StartInventory(int index){
        Display[index].icon = new GameObject();
        Display[index].icon.AddComponent<SpriteRenderer>();
        Display[index].icon.name = "Player " + affix + " inventory icon";
        Display[index].icon.transform.parent = defaultInventoryParent.transform;
        Display[index].icon.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Display[index].icon.gameObject.layer = 17;

        Display[index].boarders = new GameObject();
        Display[index].boarders.AddComponent<SpriteRenderer>();
        Display[index].boarders.GetComponent<SpriteRenderer>().sprite = inventoryBoarderImage;
        Display[index].boarders.name = "Player " + affix + " inventory background";
        Display[index].boarders.transform.parent = defaultInventoryParent.transform;
        Display[index].boarders.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Display[index].boarders.gameObject.layer = 0;

        inventory[index] = new weapon();
        inventory[index].gm = new GameObject();
        inventory[index].gm.SetActive(false);
    }
    void Update() { 
        //change help weapon dependent on position
        if (!CheckForException()){
            if (gameObject.GetComponent<PlayerMovement>().isMoveingRight){
                inventory[inventoryIndex].DisplayWeapon(gameObject.transform.position + weaponTransformOffset);
            }else{
                inventory[inventoryIndex].DisplayWeapon(gameObject.transform.position - weaponTransformOffset);
            }
        }
        timeSinceOpen++;

        //timeout inventory
        if (timeSinceOpen == 100){
            HideInventory();
        }

        //attack
        if (FindReturnButton()){
            Attack();
        }

        //decrease weapon
        if (FindLeftTrigger() != 0){
            if (!justClicked)
            {
                ChangeWeapon(inventoryIndex - 1);
            }
            justClicked = true;
            ActivateIcons();
            timeSinceOpen = 0;
        }//increase weapon
        else if (FindRightTrigger() != 0){
            if (!justClicked){
                ChangeWeapon(inventoryIndex + 1);
            }
            justClicked = true;
            ActivateIcons();
            timeSinceOpen = 0;
        }

        if (FindLeftTrigger() == 0 && FindRightTrigger() == 0){
            justClicked = false;
        }
        //update display
        UpdateInventoryDisplay();

    }
    public void ChangeWeapon(int index){
        if (CheckForOutBoundIndex(index)){
            Debug.Log(inventory[index].gm.name + "(" + index + ") is active, and " + inventory[inventoryIndex].gm.name + " (" + inventoryIndex + ") is deactivated");
            inventory[inventoryIndex].gm.SetActive(false);
            inventory[index].gm.SetActive(true);
            inventoryIndex = index;
        }
    }
    private bool CheckForException(){ return inventory[inventoryIndex] != null; }
    private bool FindReturnButton() { return Input.GetButtonDown("P" + affix + "Return"); }
    private float FindLeftTrigger() { return Input.GetAxis("P" + affix + "TriggerLeft"); }
    private float FindRightTrigger() { return Input.GetAxis("P" + affix + "TriggerRight"); }
    private bool CheckForOutBoundIndex(int index){
        if (index < 0 || index > 2){ Debug.Log("Player " + affix + " attempted to access out of bound weapon at index " + index); return false; }
        if (inventory[index].gm == null){ Debug.Log("Player tried to access a null invetory item at index " + index + ". Player does not have a weapon here"); return false; }
        return true;
    }
    private void DeactivateAllWeapons(){
        for (int i = 0; i < inventory.Length; i++){
            inventory[i].gm.SetActive(false);
        }
    }
    public void AddWeapon(weapon wp)
    {
        int index = FindNextFreeSpace();
        inventory[index] = wp;

        Debug.Log(wp.Name + " given at index " + index);
        if (index != inventoryIndex)
        {
            UnityEngine.Object.Destroy(inventory[index].gm);
            inventory[index] = wp;
        }
    }
    public void Attack()
    {
        inventory[inventoryIndex].Attack();
    }

    private int FindNextFreeSpace(){
        for (int i = 0; i < 3; i++){
            if (inventory[i].gm.name != null){
                Debug.Log("Space " + i + " at Player " + affix + " inventory is free!");
                return i;
            }
        }
        Debug.Log("No Free Spaces Left, placing item at position 0");
        return 0;
    }
    private void ActivateIcons(){
        for (int i = 0; i < 3; i++){
            Display[i].icon.SetActive(true);
            Display[i].boarders.SetActive(true);
        }
        isDisplayed = true;
    }
    private void HideInventory()
    {
        for (int i = 0; i < 3; i++)
        {
            Display[i].boarders.SetActive(false);
            Display[i].icon.SetActive(false);
        }
        isDisplayed = false;
    }
    private void UpdateInventoryDisplay()
    {
        for (int i = 0; i < 3; i++)
        {
            if (inventory[i] != null)
            {
                Display[i].icon.GetComponent<SpriteRenderer>().sprite = inventory[i].Sprite;
            }
            Display[i].icon.transform.position = gameObject.transform.position + new Vector3(i * 1.1f, 1, 0);
            Display[i].boarders.transform.position = gameObject.transform.position + new Vector3(i * 1.1f, 1, 0);

            if (i == inventoryIndex)
            {
                Display[i].boarders.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
            else
            {
                Display[i].boarders.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}

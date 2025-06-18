using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = new TextMeshProUGUI();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = 
        gameObject.name + " \n" +
        gameObject.GetComponent<PlayerMisc>().ReturnClass();
    }
}

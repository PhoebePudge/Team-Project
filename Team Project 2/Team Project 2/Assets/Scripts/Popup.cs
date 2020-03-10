using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup{
    //attributes
    private GameObject popup;
    private Image border;
    private TextMeshProUGUI title;
    private TextMeshProUGUI description;
    //constructor for title and description
    public Popup(string TITLE, string DESCRIPTION){
        Start(TITLE, DESCRIPTION);
        ExtensionMethodHelper.Instance.StartCoroutine(Disapear(2f));

    }
    //constructor for title, description and timer
    public Popup(string TITLE, string DESCRIPTION, float TIMER){
        Start(TITLE, DESCRIPTION);
        ExtensionMethodHelper.Instance.StartCoroutine(Disapear(TIMER));
    }
    //void used for both constructor
    private void Start(string TITLE, string DESCRIPTION){
        //popup
        popup = new GameObject();
        popup.name = "Popup Message";
        popup.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        popup.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        //border
        border = new GameObject().AddComponent<Image>();
        border.name = "Border";
        border.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0.0f, 0.0f, 4, 4), new Vector2(0.5f, 0.5f), 100.0f);
        border.color = Color.grey;
        border.transform.parent = popup.transform;
        border.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 200);
        border.transform.position = popup.transform.position;
        //title
        title = new GameObject().AddComponent<TextMeshProUGUI>();
        title.name = "Title";
        title.transform.parent = popup.transform;
        title.GetComponent<TextMeshProUGUI>().text = TITLE;
        title.transform.position = popup.transform.position + new Vector3(0, border.GetComponent<RectTransform>().sizeDelta.y / 3, 0);
        title.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.CenterGeoAligned;
        title.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 20);
        //description
        description = new GameObject().AddComponent<TextMeshProUGUI>();
        description.name = "Description";
        description.transform.parent = popup.transform;
        description.GetComponent<TextMeshProUGUI>().text = DESCRIPTION;
        description.transform.position = popup.transform.position - new Vector3(0, border.GetComponent<RectTransform>().sizeDelta.y / 8, 0);
        description.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.CenterGeoAligned;
        description.GetComponent<TextMeshProUGUI>().fontSize = 20f;
        description.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 120);

        description.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
        description.GetComponent<TextMeshProUGUI>().fontSizeMin = 10f;
        description.GetComponent<TextMeshProUGUI>().overflowMode = TextOverflowModes.ScrollRect;
    }
    /// <summary>
    ///Counts down using the timer specified with countdown. This is ran though the Extension Method Helper as  IEnumerators can only be ran through Monobehaviour
    /// </summary>
    /// <param name="countdown"></param>
    /// <returns>yield return null</returns>
    IEnumerator Disapear(float countdown)
    {
        //loop until countdown is met
        //increasing by Time.deltaTime
        for (float time = 0; time < countdown; time = time + Time.deltaTime)
        {
            yield return null;
        }
        Debug.Log("Disapear IEnumerator Complete");
        //destroy popup to avoid needless objects
        GameObject.Destroy(popup);
        
    }
}

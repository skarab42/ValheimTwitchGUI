using UnityEngine.UI;
using UnityEngine;

public class ValheimTwitchGUIScript : MonoBehaviour
{
    public MainButton mainButton;
    public MainPanel mainPanel;
    public RewardGrid rewardGrid;

    //public Text mainButtonText;
    //public GameObject gui;
    //public GameObject panels;
    //public GameObject rewardGrid;
    //public GameObject rewardButton;

    //public void ToggleGUI()
    //{
    //    gui.SetActive(!gui.activeSelf);
    //}

    //public void SetMainButtonText(string text)
    //{
    //    mainButtonText.text = text;
    //}

    //public void HideAllPanels()
    //{
    //    for (int i = 0; i < panels.transform.childCount; i++)
    //    {
    //        panels.transform.GetChild(i).gameObject.SetActive(false);
    //    }
    //}

    //public void ShowPanel(string name)
    //{
    //    for (int i = 0; i < panels.transform.childCount; i++)
    //    {
    //        var go = panels.transform.GetChild(i).gameObject;

    //        go.SetActive(go.name == name);
    //    }
    //}

    //public GameObject AddReward(string title, Color32 color, Texture2D texture)
    //{
    //    var go = Instantiate(rewardButton, rewardGrid.transform);

    //    var bgImage = go.GetComponent<Image>();
    //    bgImage.color = color;

    //    var image = go.transform.GetChild(0).GetComponent<Image>();
    //    var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    //    image.preserveAspect = true;
    //    image.sprite = sprite;

    //    var text = go.transform.GetChild(1).GetComponent<Text>();
    //    text.text = title;

    //    return go;
    //}
}

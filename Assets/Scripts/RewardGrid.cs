using UnityEngine;
using UnityEngine.UI;

public class RewardGrid : MonoBehaviour
{
    public GameObject rewardButton;

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public GameObject Add(string title, Color32 color, Texture2D texture)
    {
        var go = Instantiate(rewardButton, gameObject.transform);

        var bgImage = go.GetComponent<Image>();
        bgImage.color = color;

        var image = go.transform.GetChild(0).GetComponent<Image>();
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        
        image.preserveAspect = true;
        image.sprite = sprite;

        var text = go.transform.GetChild(1).GetComponent<Text>();
        text.text = title;

        return go;
    }
}

using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RewardGridItem
{
    public string id;
    public string title;
    public Color color;
    public Image image;
    public Texture2D imageTexture;
    public JToken data;

    public RewardGridItem(string id, string title, Color color, Texture2D imageTexture, JToken data = null)
    {
        this.id = id;
        this.title = title;
        this.color = color;
        this.imageTexture = imageTexture;
        this.data = data;
    }
}
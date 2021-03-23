using UnityEngine;
using UnityEngine.UI;

public class RewardGrid : MonoBehaviour
{
    public GameObject rewardButton;
    public RewardSettings rewardSettings;

    public void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public GameObject Add(RewardGridItem item)
    {
        var go = Instantiate(rewardButton, gameObject.transform);

        var script = go.GetComponent<RewardButton>();
        script.rewardSettings = rewardSettings;
        script.reward = item;

        var bgImage = go.GetComponent<Image>();
        bgImage.color = item.color;

        item.image = go.transform.GetChild(0).GetComponent<Image>();
        var rect = new Rect(0, 0, item.imageTexture.width, item.imageTexture.height);
        var sprite = Sprite.Create(item.imageTexture, rect, new Vector2(0.5f, 0.5f));

        item.image.preserveAspect = true;
        item.image.sprite = sprite;

        var text = go.transform.GetChild(1).GetComponent<Text>();
        text.text = item.title;

        return go;
    }
}

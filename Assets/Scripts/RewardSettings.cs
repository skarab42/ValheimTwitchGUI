using UnityEngine;
using UnityEngine.UI;

public class RewardSettings : MonoBehaviour
{
    public RewardGridItem reward;

    public Text title;
    public Image image;
    public Button closeButton;

    public void Awake()
    {
        closeButton.onClick.AddListener(() => SetActive(false));
    }

    public void SetReward(RewardGridItem reward)
    {
        this.reward = reward;
        title.text = reward.title;
        image.sprite = reward.image.sprite;

        Debug.Log($"SetReward -> {reward.title}");
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}

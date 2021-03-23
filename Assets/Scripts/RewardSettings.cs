using System;
using UnityEngine;
using UnityEngine.UI;

public class RewardSettings : MonoBehaviour
{
    public RewardGridItem reward;

    public Text title;
    public Image image;
    public Button closeButton;
    public Dropdown actionsDropdown;
    public RewardButton rewardButton;

    public void Awake()
    {
        closeButton.onClick.AddListener(() => SetActive(false));
        actionsDropdown.onValueChanged.AddListener(OnDropDownChanged);
    }

    private void OnDropDownChanged(int index)
    {
        rewardButton.image.color = reward.color;
        
        if (index == 0)
        {
            rewardButton.image.color = new Color32(0, 0, 0, 127);
        }
    }

    public void SetReward(RewardButton button, RewardGridItem reward)
    {
        this.reward = reward;
        rewardButton = button;
        title.text = reward.title;
        image.sprite = reward.image.sprite;
        actionsDropdown.value = reward.actionIndex;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}

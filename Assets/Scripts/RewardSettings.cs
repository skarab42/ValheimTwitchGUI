using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMessageData
{
    public int Action = 0;
}

public class SettingsChangedArgs : EventArgs
{
    public SettingsMessageData Data { get; set; }
}

public delegate void SettingsChangedHandler(object sender, SettingsChangedArgs e);

public class RewardSettings : MonoBehaviour
{
    public RewardGridItem reward;

    public Text title;
    public Image image;
    public Button closeButton;
    public Dropdown actionsDropdown;
    public RewardButton rewardButton;

    public RavenMessageSettings ravenActionSettings;
    public SpawnCreatureSettings spawnCreatureSettings;
    public HUDMessageSettings hudMessageSettings;

    public event SettingsChangedHandler OnSettingsChanged;

    public List<string> actions = new List<string> {
        "None",
        "Raven messenger",
        "Spawn creature",
        "HUD message"
    };

    private void Start()
    {
        actionsDropdown.AddOptions(actions);
    }

    public void Awake()
    {
        closeButton.onClick.AddListener(OnPanelClosed);
        actionsDropdown.onValueChanged.AddListener(OnDropDownChanged);
    }

    private void OnPanelClosed()
    {
        SettingsMessageData data = null;

        switch (actionsDropdown.value)
        {
            case 0:
                data = new SettingsMessageData();
                break;
            case 1:
                data = ravenActionSettings.GetData();
                break;
            case 2:
                data = spawnCreatureSettings.GetData();
                break;
            case 3:
                data = hudMessageSettings.GetData();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnSettingsChanged?.Invoke(this, new SettingsChangedArgs { Data = data });

        SetActive(false);
    }

    private void OnDropDownChanged(int index)
    {
        if (rewardButton == null)
            return;
        
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

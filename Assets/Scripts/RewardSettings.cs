using Newtonsoft.Json.Linq;
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

public abstract class MessageSettings : MonoBehaviour
{
    public abstract SettingsMessageData GetData();
    public abstract void SetData(JToken data);
    public static int GetInt(JToken data, string key, int defaultValue = 0)
    {
        if (data == null || data[key] == null)
            return defaultValue;
        return data[key].Value<int>();
    }
    public static string GetString(JToken data, string key, string defaultValue = "1")
    {
        if (data == null || data[key] == null)
            return defaultValue;
        return data[key].Value<string>();
    }
}

public delegate void SettingsChangedHandler(object sender, SettingsChangedArgs e);

public class RewardSettings : MonoBehaviour
{
    public RewardGridItem reward;

    public Text title;
    public Image image;
    public Button saveButton;
    public Button closeButton;
    public Dropdown actionsDropdown;
    public RewardButton rewardButton;

    public RavenMessageSettings ravenActionSettings;
    public SpawnCreatureSettings spawnCreatureSettings;
    public HUDMessageSettings hudMessageSettings;
    public RandomEventSettings randomEventSettings;
    public EnvironmentSettings environmentSettings;

    public MessageSettings currentSettingsPanel;

    public event SettingsChangedHandler OnSettingsChanged;

    private List<string> actions = new List<string> {
        "None",
        "Raven messenger",
        "Spawn creature",
        "HUD message",
        "Start event",
        "Set environment"
    }; 

    public void Awake()
    {
        actionsDropdown.ClearOptions();
        actionsDropdown.AddOptions(actions);
        actionsDropdown.RefreshShownValue();

        saveButton.onClick.AddListener(OnSave);
        closeButton.onClick.AddListener(OnClose);
    }

    private void OnClose()
    {
        SetActive(false);
    }

    private void OnSave()
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
            case 4:
                data = randomEventSettings.GetData();
                break;
            case 5:
                data = environmentSettings.GetData();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnSettingsChanged?.Invoke(this, new SettingsChangedArgs { Data = data });

        OnClose();
    }

    public void SetReward(RewardGridItem reward)
    {
        SetActive(true);
        
        this.reward = reward;
        title.text = reward.title;
        image.sprite = reward.image.sprite;

        var action = reward.data?["Action"]?.Value<int>();

        actionsDropdown.value = action??0;
        actionsDropdown.Select();

        if (action != null)
            currentSettingsPanel.SetData(reward.data);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}

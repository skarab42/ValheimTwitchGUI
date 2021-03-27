using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnvironmentData : SettingsMessageData
{
    public new int Action = 5;
    public int Index { set; get; }
    public string Name { set; get; }
    public int Duration { get; set; }
}

public class EnvironmentSettings : MessageSettings
{
    public Dropdown envList;
    public InputField duration;

    private readonly List<string> envNames = new List<string>
    {
        "Reset to default",
        "Ashrain",
        "Bonemass",
        "Clear",
        "Crypt",
        "Darklands_dark",
        "DeepForest Mist",
        "Eikthyr",
        "GDKing",
        "GoblinKing",
        "Heath clear",
        "LightRain",
        "Misty",
        "Moder",
        "nofogts",
        "Rain",
        "Snow",
        "SnowStorm",
        "SunkenCrypt",
        "SwampRain",
        "ThunderStorm",
        "Twilight_Clear",
        "Twilight_Snow",
        "Twilight_SnowStorm"
    };

    private void Awake()
    {
        envList.ClearOptions();
        envList.AddOptions(envNames);
    }

    public override SettingsMessageData GetData()
    {
        var payload = new EnvironmentData();

        payload.Index = envList.value;
        payload.Name = envNames[envList.value];
        payload.Duration = int.Parse(duration.text);

        return payload;
    }

    public override void SetData(JToken data)
    {
        envList.value = GetInt(data, "Index", 0);
        duration.text = GetString(data, "Duration", "1");
    }
}

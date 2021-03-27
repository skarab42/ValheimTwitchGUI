using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomEventData : SettingsMessageData
{
    public new int Action = 4;
    public int EventIndex { set; get; }
    public string EventName { set; get; }
    public int Distance { get; set; }
    public int Duration { get; set; }
}

public class RandomEventSettings : MessageSettings
{
    public Dropdown eventList;
    public InputField distance;
    public InputField duration;

    private readonly List<string> eventNames = new List<string>
    {
        "blobs",
        "foresttrolls",
        "skeletons",
        "surtlings",
        "wolves",

        "army_bonemass",
        "army_eikthyr",
        "army_goblin",
        "army_moder",
        "army_theelder",

        "boss_bonemass",
        "boss_eikthyr",
        "boss_gdking",
        "boss_goblinking",
        "boss_moder"
    };

    private void Awake()
    {
        eventList.ClearOptions();
        eventList.AddOptions(eventNames);
    }

    public override SettingsMessageData GetData()
    {
        var payload = new RandomEventData();

        payload.EventIndex = eventList.value;
        payload.EventName = eventNames[eventList.value];
        payload.Distance = int.Parse(distance.text);
        payload.Duration = int.Parse(duration.text);

        return payload;
    }

    public override void SetData(JToken data)
    {
        eventList.value = GetInt(data, "EventIndex", 0);
        distance.text = GetString(data, "Distance", "80");
        duration.text = GetString(data, "Duration", "1");
    }
}

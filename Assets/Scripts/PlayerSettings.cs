using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerData : SettingsMessageData
{
    public new int Action = 6;
    public int Index { set; get; }
    public string Name { set; get; }
}

public class PlayerSettings : MessageSettings
{
    public Dropdown actionList;

    private readonly List<string> actionNames = new List<string>
    {
        "puke",
        "heal"
    };

    private void Awake()
    {
        actionList.ClearOptions();
        actionList.AddOptions(actionNames);
    }

    public override SettingsMessageData GetData()
    {
        var payload = new PlayerData();

        payload.Index = actionList.value;
        payload.Name = actionNames[actionList.value];

        return payload;
    }

    public override void SetData(JToken data)
    {
        actionList.value = GetInt(data, "Index", 0);
    }
}

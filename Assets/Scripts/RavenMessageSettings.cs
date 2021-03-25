using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RavenMessageData : SettingsMessageData
{
    public new int Action = 1;
    public int Type { set; get; }
}

public class RavenMessageSettings : MessageSettings
{
    public Dropdown type;

    public override SettingsMessageData GetData()
    {
        var payload = new RavenMessageData();

        payload.Type = type.value;

        return payload;
    }

    public override void SetData(JToken data)
    {
        type.value = GetInt(data, "Type", 0);
    }
}

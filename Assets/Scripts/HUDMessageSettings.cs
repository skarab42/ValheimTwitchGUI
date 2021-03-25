using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class HUDMessageData : SettingsMessageData
{
    public new int Action = 3;
    public int Position { set; get; }
}

public class HUDMessageSettings : MessageSettings
{
    public Dropdown positionDropdown;

    public override SettingsMessageData GetData()
    {
        var payload = new HUDMessageData();

        payload.Position = positionDropdown.value;

        return payload;
    }

    public override void SetData(JToken data)
    {
        positionDropdown.value = GetInt(data, "Position", 0);
    }
}

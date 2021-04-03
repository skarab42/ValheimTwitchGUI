using UnityEngine;
using UnityEngine.UI;

public class RewardForm : MonoBehaviour
{
    public InputField title;
    public InputField cost;
    public InputField prompt;
    public Toggle userInputRequired;
    public Toggle shouldRedemptionsSkipRequestQueue;

    public NewRewardArgs GetData()
    {
        return new NewRewardArgs
        {
            Title = title.text,
            Cost = cost.text,
            Prompt = prompt.text,
            IsUserInputRequired = userInputRequired.isOn ? "true" : "false",
            ShouldRedemptionsSkipRequestQueue = shouldRedemptionsSkipRequestQueue.isOn ? "true" : "false"
        };
    }
}

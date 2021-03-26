using UnityEngine;
using UnityEngine.UI;

public class RewardForm : MonoBehaviour
{
    public InputField title;
    public InputField cost;
    public InputField prompt;
    public Toggle userInputRequired;

    public NewRewardArgs GetData()
    {
        return new NewRewardArgs
        {
            Title = title.text,
            Cost = cost.text,
            Prompt = prompt.text,
            IsUserInputRequired = userInputRequired.enabled ? "true" : "false"
        };
    }
}

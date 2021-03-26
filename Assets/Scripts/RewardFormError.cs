using UnityEngine;
using UnityEngine.UI;

public class RewardFormError : MonoBehaviour
{
    public Text text;

    public void Show(string message)
    {
        text.text = message;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

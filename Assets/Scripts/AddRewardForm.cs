using System;
using UnityEngine;
using UnityEngine.UI;

public class NewRewardArgs : EventArgs
{
    public string Title { get; set; }
    public string Cost { get; set; }
    public string Prompt { get; set; }
    public string IsUserInputRequired { get; set; }
    public string ShouldRedemptionsSkipRequestQueue { get; set; }
}

public delegate void NewRewardHandler(object sender, NewRewardArgs e);

public class AddRewardForm : MonoBehaviour
{
    public Button saveButton;
    public Button closeButton;
    public RewardForm rewardForm;
    public RewardFormError error;

    public event NewRewardHandler OnSave;

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void Show()
    {
        SetActive(true);
    }

    public void Hide()
    {
        error.Hide();
        SetActive(false);
    }

    private void Awake()
    {
        closeButton.onClick.AddListener(() => Hide());
        saveButton.onClick.AddListener(() => {
            OnSave?.Invoke(this, rewardForm.GetData());
            //SetActive(false);
        });
    }
}

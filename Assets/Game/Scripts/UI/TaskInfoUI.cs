using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskInfoUI : MonoBehaviour
{
    [SerializeField] private Toggle checkmarkToggle;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }

    public void SetCheckmark(bool value)
    {
        checkmarkToggle.isOn = value;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

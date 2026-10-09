using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class UnitUI
{
    public UnitType type;
    public string stringValue;
    public TextMeshProUGUI textUI;
}
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<UnitUI> units = new List<UnitUI>();

    public void UpdateUI(UnitType selectedType, int value)
    {
        foreach (UnitUI item in units)
        {
            if (selectedType == item.type)
            {
                if (item.stringValue != null)
                {
                    item.textUI.text = $"{item.stringValue}{value}";
                }
                else
                {
                    item.textUI.text = value.ToString();
                }
            }
        }
    }
}

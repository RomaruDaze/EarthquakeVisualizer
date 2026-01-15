using System;
using TMPro;
using UnityEngine;

public class DateText : MonoBehaviour
{
    [Tooltip("表示用 TextMeshProUGUI")]
    public TextMeshProUGUI dateText;

    public void SetDate(DateTime utcTime)
    {
        if (dateText == null) return;

        dateText.text =
            $"Date (UTC): {utcTime:yyyy-MM-dd HH:mm:ss}";
    }
}
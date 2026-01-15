using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateJumpUI : MonoBehaviour
{
    [Header("Target")]
    public EarthquakePlayer player;

    [Header("UI")]
    public TMP_Dropdown yearDropdown;
    public TMP_Dropdown monthDropdown;
    public TMP_Dropdown dayDropdown;

    private const int MinYear = 1983;
    private const int MaxYear = 2024;

    void Start()
    {
        InitYear();
        InitMonth();
        UpdateDayOptions();
    }

    void InitYear()
    {
        yearDropdown.ClearOptions();
        var list = new List<string>();

        for (int y = MinYear; y <= MaxYear; y++)
            list.Add(y.ToString());

        yearDropdown.AddOptions(list);
        yearDropdown.onValueChanged.AddListener(_ => UpdateDayOptions());
    }

    void InitMonth()
    {
        monthDropdown.ClearOptions();
        var list = new List<string>();

        for (int m = 1; m <= 12; m++)
            list.Add(m.ToString());

        monthDropdown.AddOptions(list);
        monthDropdown.onValueChanged.AddListener(_ => UpdateDayOptions());
    }

    void UpdateDayOptions()
    {
        int year = MinYear + yearDropdown.value;
        int month = monthDropdown.value + 1;

        int days = DateTime.DaysInMonth(year, month);

        dayDropdown.ClearOptions();
        var list = new List<string>();

        for (int d = 1; d <= days; d++)
            list.Add(d.ToString());

        dayDropdown.AddOptions(list);
    }

    // Button から呼ぶ
    public void OnJumpButton()
    {
        int year = MinYear + yearDropdown.value;
        int month = monthDropdown.value + 1;
        int day = dayDropdown.value + 1;

        player.JumpToDateFromUI(year, month, day);
    }
}
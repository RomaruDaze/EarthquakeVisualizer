using System;
using UnityEngine;
using TMPro;

/// <summary>
/// 地震情報ポップアップUI
/// クリックされた地震のみ表示される
/// </summary>
public class EarthquakePopupUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private RectTransform root;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI bodyText;

    [Header("Settings")]
    [SerializeField] private Vector2 screenOffset = new Vector2(20, -20);

    private Camera _mainCamera;

    void Awake()
    {
        _mainCamera = Camera.main;
        Hide();
    }

    public void Show(EarthquakeEvent ev, Vector3 worldPosition)
    {
        if (root == null || _mainCamera == null) return;

        Vector3 screenPos =
            _mainCamera.WorldToScreenPoint(worldPosition);

        root.position = screenPos + (Vector3)screenOffset;
        root.gameObject.SetActive(true);

        titleText.text = ev.place;
        bodyText.text =
            $"Time (UTC): {ev.timeUtc:yyyy-MM-dd HH:mm:ss}\n" +
            $"Magnitude: {ev.magnitude:F1}\n" +
            $"Depth: {ev.depthKm:F1} km\n" +
            $"Lat: {ev.latitude:F3}, Lon: {ev.longitude:F3}";
    }

    public void Hide()
    {
        if (root != null)
            root.gameObject.SetActive(false);
    }
}
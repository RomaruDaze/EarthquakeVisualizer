using UnityEngine;

/// <summary>
/// 個々の地震マーカーに付与
/// ・波紋エフェクトあり
/// ・クリックしたときのみ情報表示
/// </summary>
[RequireComponent(typeof(Collider))]
public class EarthquakeMarker : MonoBehaviour
{
    private EarthquakeEvent _data;
    private EarthquakePopupUI _popupUI;

    [Header("Effect Settings")]
    public float lifeTime = 3f;        // 表示される時間
    public float startScale = 0.05f;   // 出現時の大きさ
    public float endScale = 1.0f;      // 最大サイズ

    private float _time;
    private Material _mat;
    private Color _startColor;

    /// <summary>
    /// EarthquakePlayer から呼ばれる初期化
    /// </summary>
    public void SetData(EarthquakeEvent data, EarthquakePopupUI popupUI)
    {
        _data = data;
        _popupUI = popupUI;

        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // material をコピー（全マーカー共通にならないように）
            _mat = renderer.material;
            _startColor = _mat.color;
        }

        transform.localScale = Vector3.one * startScale;
        _time = 0f;
    }

    void Update()
    {
        if (_mat == null) return;

        _time += Time.deltaTime;
        float t = _time / lifeTime;

        // 拡大
        float scale = Mathf.Lerp(startScale, endScale, t);
        transform.localScale = Vector3.one * scale;

        // フェードアウト
        Color c = _startColor;
        c.a = Mathf.Lerp(1f, 0f, t);
        _mat.color = c;

        // 寿命
        if (_time >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ★ クリックしたときだけ情報表示
    /// </summary>
    void OnMouseDown()
    {
        if (_popupUI == null) return;

        _popupUI.Show(_data, transform.position);
    }
}
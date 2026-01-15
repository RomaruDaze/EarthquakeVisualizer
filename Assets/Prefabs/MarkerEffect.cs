using UnityEngine;

public class RippleEffect : MonoBehaviour
{
    public float expandSpeed = 0.3f;  // 広がる速さ
    public float fadeSpeed = 1f;      // 消える速さ
    private Material _mat;
    private Color _color;

    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        _color = _mat.color;
    }

    void Update()
    {
        // 徐々に拡大
        transform.localScale += Vector3.one * expandSpeed * Time.deltaTime;

        // 徐々に透明に
        _color.a -= fadeSpeed * Time.deltaTime;
        _mat.color = _color;

        // 完全に透明になったら削除
        if (_color.a <= 0f)
            Destroy(gameObject);
    }
}

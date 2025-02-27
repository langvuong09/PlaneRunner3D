using UnityEngine;
[AddComponentMenu("TienCuong/CanvasSizeFix")]
public class CanvasSizeFix : MonoBehaviour
{
    void Awake()
    {
        RectTransform r = gameObject.GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        r.sizeDelta = new Vector2(ratio * 1800, 1800);
    }
}

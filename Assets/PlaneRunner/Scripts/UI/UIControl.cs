using UnityEngine;
[AddComponentMenu("TienCuong/UIControl")]
public class UIControl : MonoBehaviour
{
    private static UIControl m_Current;
    public static UIControl Current
    { get { return m_Current; } }
    public GameObject m_LoseUI;
    public GameObject m_WinUI;
    public GameObject m_InGameUI;
    [SerializeField]
    public Camera m_EventCamera;
    void Awake()
    {
        m_Current = this;
    }

    void Start()
    {
        Canvas[] allCanvas = GetComponentsInChildren<Canvas>(true);
        foreach (Canvas c in allCanvas)
        {
            c.worldCamera = m_EventCamera;
        }
    }
}


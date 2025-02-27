using UnityEngine;
[AddComponentMenu("TienCuong/CameraControl")]
public class CameraControl : MonoBehaviour
{
    private static CameraControl m_Current;
    public static CameraControl Current
    {
        get { return m_Current; }
    }

    private float m_ShakeTimer;
    private float m_ShakeRadius = 1;
    [HideInInspector]
    public bool m_ShakeEnabled = true;
    [HideInInspector]
    public float m_CameraMoveLerp = 0;
    [HideInInspector]
    public int m_CameraMod = 0;

    void Awake()
    {
        m_Current = this;
    }
    void Start()
    {
        m_ShakeEnabled = true;
    }

    void Update()
    {
        m_ShakeTimer -= Time.deltaTime;

        if (m_ShakeTimer <= 0)
            m_ShakeTimer = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 finalPosition = Vector3.zero;
        Quaternion finalRotation = Quaternion.identity;
        Vector3 ShakeOffset = Vector3.zero;
        float shakeSin = Mathf.Cos(30 * Time.time) * Mathf.Clamp(m_ShakeTimer, 0, 0.5f);
        float shakeCos = Mathf.Sin(50 * Time.time) * Mathf.Clamp(m_ShakeTimer, 0, 0.5f);
        ShakeOffset = new Vector3(m_ShakeRadius * shakeCos, 0, m_ShakeRadius * shakeSin);

        Vector3 speedShake = new Vector3(0.2f * Mathf.Cos(10 * Time.time), 0.1f * Mathf.Sin(16 * Time.time), 0);
        if (!m_ShakeEnabled) 
        {
            speedShake = Vector3.zero;
        }
        Vector3 camPos = new Vector3(0, 20, -30);
        camPos.x += .6f*PlayerPlane.m_Main.transform.position.x;
        camPos.y += .3f * PlayerPlane.m_Main.transform.position.y;
        transform.position = camPos + ShakeOffset + speedShake;
    }

    public void StartShake(float t, float r)
    {
        if (m_ShakeTimer == 0 || m_ShakeRadius < r)
            m_ShakeRadius = r;
        m_ShakeTimer = t;
    }

    public Ray GetRay(Vector3 screenPosition)
    {
        Ray outputRay;
        outputRay = GetComponent<Camera>().ScreenPointToRay(screenPosition);
        return outputRay;
    }

    public Vector3 WorldToScreenPoint(Vector3 WorldPos)
    {
        Vector3 pos = GetComponent<Camera>().WorldToScreenPoint(WorldPos);
        pos.x = pos.x / Screen.width;
        pos.y = pos.y / Screen.height;
        return pos;
    }

    public Vector3 ScreenToWorldPoint(Vector3 ScreenPos)
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(ScreenPos);
        Vector3 point = ray.origin;
        point.z = 0;
        return point;
    }

}

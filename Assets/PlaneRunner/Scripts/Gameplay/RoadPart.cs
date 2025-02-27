using UnityEngine;
[AddComponentMenu("TienCuong/RoadPart")]
public class RoadPart : MonoBehaviour
{
    public Transform EndPoint;
    [HideInInspector]
    public RoadPart m_NextPart;
    public float m_MoveSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += GameControl.m_Current.m_GameSpeed * Time.deltaTime * Vector3.back;
        if (transform.position.z <  - 400)
        {
            Destroy(gameObject);
        }
    }
}


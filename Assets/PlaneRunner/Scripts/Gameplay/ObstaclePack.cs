using UnityEngine;
[AddComponentMenu("TienCuong/ObstaclePack")]
public class ObstaclePack : MonoBehaviour
{
    public Transform m_EndPoint;     
    public float m_MoveSpeed = 0;
    // Update is called once per frame
    void Update()
    {
        transform.position += GameControl.m_Current.m_GameSpeed * Time.deltaTime * Vector3.back;
        if (transform.position.z < -50)
            Destroy(gameObject);
    }
}


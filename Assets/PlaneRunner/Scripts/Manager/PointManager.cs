using UnityEngine;
using System.Collections;
[AddComponentMenu("TienCuong/PointManager")]
public class PointManager : MonoBehaviour
{
    public int point = 1;
    void Start()
    {
        StartCoroutine(RepeatAction());
    }

    IEnumerator RepeatAction()
    {
        while (true)
        {
            if (Time.time > 0) // Thay Time thành điều kiện bạn muốn kiểm tra
            {
                GameManager.Instance.SetPoint(point);
            }
            yield return new WaitForSeconds(1f); // Đợi 1 giây rồi lặp lại
        }
    }
}

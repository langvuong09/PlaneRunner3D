using UnityEngine;
[AddComponentMenu("TienCuong/GameManager")]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get => instance;
    }
    private int point;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetPoint(int point)
    {
        this.point += point;
    }
    public int GetPoint()
    {
        return point;
    }
    public void ResetPoint()
    {
        point = 0;
    }
}

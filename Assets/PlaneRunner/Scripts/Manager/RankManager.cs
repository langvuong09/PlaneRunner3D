using TMPro;

using UnityEngine;
[AddComponentMenu("TienCuong/RankManager")]
public class RankManager : MonoBehaviour
{
    public TextMeshProUGUI textPoint;
    public TextMeshProUGUI textPoint1;
    public TextMeshProUGUI textPoint2;
    public TextMeshProUGUI textPoint3;
    private GameObject plane;
    private bool isRanked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = GameObject.Find("Plane");
        LoadRank();
    }

    // Update is called once per frame
    void Update()
    {
        if (plane != null)
        {
            if (plane.activeSelf)
            {
                isRanked = false; // Reset trạng thái nếu plane được bật lại
            }
            else if (!isRanked)
            {
                Rank();
                isRanked = true;
            }
        }
    }


    public void Rank()
    {
        int presentPoint = int.Parse(textPoint.text);
        int point1 = int.Parse(textPoint1.text);
        int point2 = int.Parse(textPoint2.text);
        int point3 = int.Parse(textPoint3.text);
        if (presentPoint >= point1)
        {
            point3 = point2;
            point2 = point1;
            point1 = presentPoint; 
        }
        else if (presentPoint >= point2 && presentPoint < point1) 
        {
            point3 = point2;
            point2 = presentPoint;
        }
        else if (presentPoint > point3 && presentPoint < point2)
        {
            point3 = presentPoint;
        }

        PlayerPrefs.SetInt("Point1", point1);
        PlayerPrefs.SetInt("Point2", point2);
        PlayerPrefs.SetInt("Point3", point3);
        PlayerPrefs.Save();

        textPoint1.text = point1.ToString();
        textPoint2.text = point2.ToString();
        textPoint3.text = point3.ToString();
    }
    void LoadRank()
    {
        textPoint1.text = PlayerPrefs.GetInt("Point1", 0).ToString();
        textPoint2.text = PlayerPrefs.GetInt("Point2", 0).ToString();
        textPoint3.text = PlayerPrefs.GetInt("Point3", 0).ToString();
    }
}

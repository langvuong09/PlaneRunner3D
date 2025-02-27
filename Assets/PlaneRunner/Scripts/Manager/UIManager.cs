using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Rendering;
[AddComponentMenu("TienCuong/UIManager")]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UpdateUI());
    }

    private IEnumerator UpdateUI()
    {
        while (true)
        {
            textPoint.text = GameManager.Instance.GetPoint().ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}

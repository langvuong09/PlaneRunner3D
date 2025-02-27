using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("TienCuong/LoseUI")]
public class LoseUI : MonoBehaviour
{
    public void BtnRestart()
    {
        GameManager.Instance.ResetPoint();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BtnExit()
    {
        Application.Quit();
    }
}


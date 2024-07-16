using UnityEngine;

public class 打开指定链接 : MonoBehaviour
{
    public GameObject about;
    public void openurl(string url)
    {
        Application.OpenURL(url);
    }

    public void showAbout()
    {
        if (about.activeSelf)
        {
            about.SetActive(false);
        }
        else
        {
            about.SetActive(true);
        }
    }
}

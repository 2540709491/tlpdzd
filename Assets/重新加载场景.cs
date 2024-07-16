using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 重新加载场景 : MonoBehaviour
{
    private void Awake()
    {
       
        
    }

    public void ReloadScene(string sc)
    {
        SceneManager.LoadSceneAsync(sc);
    }
}

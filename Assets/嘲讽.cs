using System;
using UnityEngine;
using UnityEngine.UI;

public class 嘲讽 : MonoBehaviour
{
  public 随机生成 sjsc;
  public RawImage 就位状态;
  public 特朗普移动 tlpyd;
  public AudioSource _嘲讽;
  public bool 嘲讽就位=true;
  public Button 嘲讽按钮;

  private void Start()
  {
    嘲讽按钮.onClick.AddListener(按下嘲讽);
  }

  void 按下嘲讽()
  {
    _嘲讽.Play();
    if (嘲讽就位)
    {
      开始嘲讽();
    }

  }
  private void Update()
  {
    if (嘲讽就位)
    {
      就位状态.color=Color.green;
    }
    else
    {
      就位状态.color=Color.red;
    }

    if (Input.GetKeyDown(KeyCode.F))
    {
      _嘲讽.Play();
      if (嘲讽就位)
      {
        开始嘲讽();
      }
      
    }
  }

  void 开始嘲讽()
  {
    嘲讽就位 = false;
    tlpyd.enabled = false;
    
    Invoke("恢复就位",2f);
  }

  void 恢复就位()
  {
    sjsc.总分数 += 100;
    嘲讽就位 = true;
    tlpyd.enabled = true;
  }
}

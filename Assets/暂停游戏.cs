using System.Collections.Generic;
using UnityEngine;

public class 暂停游戏 : MonoBehaviour
{

 public 随机生成 _随机生成;

 public void 暂停()
 {
  _随机生成.enabled = false;
  GameObject[] gs = GameObject.FindGameObjectsWithTag("狙击");
  foreach (var item in gs)
  {
   Destroy(item);
  }

  
 }
}

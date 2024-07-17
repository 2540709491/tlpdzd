using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 随机生成 : MonoBehaviour
{
    public GameObject 特朗普;
    public GameObject prefab; // 预制体
    private float 生成时间 = 0.05f;
    public int 一次生成的个数 = 20;
    public int 当前个数 = 0;
    public int 躲过子弹数;
    public int 发射子弹数;
    public TextMeshProUGUI 躲过子弹;
    public TextMeshProUGUI 总子弹数;// 生成间隔时间
    public TextMeshProUGUI 总分;
    public RawImage 就位状态;
    private bool 允许生成 = true;
    public int 总分数;
    private void Update()
    {
        躲过子弹.text = 躲过子弹数.ToString("躲过子弹数:0000");
        总子弹数.text = 当前个数.ToString("当前子弹数:0000");
        总分.text = 总分数.ToString("总分:0000");
        if (发射子弹数>500)
        {
            允许生成 = false;
            发射子弹数 = 0;
            Invoke("恢复生成", 4f);
            就位状态.color=Color.red;
        }
    }

    void 恢复生成()
    {
        允许生成 = true;
        就位状态.color=Color.green;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        就位状态.color = Color.red;
        prefab.GetComponent<狙击>().特朗普 = 特朗普;
        prefab.GetComponent<狙击>().sjsc = this;
        InvokeRepeating("生成预制体", 2f, 生成时间);
        
    }
    
    void 生成预制体()
    {
        if (!允许生成)
        {
            return;
        }

        if (就位状态.color == Color.red)
        {
            就位状态.color = Color.green;
        }
        
        if (当前个数>300)
        {
            return;
        }

        Vector3 position = 特朗普.GetComponent<BoxCollider2D>().bounds.center;
        
        Instantiate(prefab, position, Quaternion.identity);
        当前个数 += 1;
        发射子弹数 += 1;
        for (int i = 1; i < 一次生成的个数; i++)
        {
            float offsetX = Random.Range(-10f, 10f);
            float offsetY = Random.Range(-10f, 10f);
            var newposition = new Vector3(position.x + offsetX, position.y + offsetY, position.z);
            Instantiate(prefab, newposition, Quaternion.identity);
            当前个数 += 1;
            发射子弹数 += 1;
        }


        
        
    }

}
using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class 狙击 : MonoBehaviour
{
    public GameObject 特朗普; // 假设特朗普是一个公共变量，指向特朗普的GameObject
    private BoxCollider2D myCollider; // 假设这个脚本附加在你想要检测的碰撞器上
    private bool is检测;
    public 随机生成 sjsc;
    
    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        if (myCollider == null)
        {
            Debug.LogError("没有找到BoxCollider2D组件。");
        }
    }

    private void Update()
    {
        if (IsOverlappingWithTrump())
        {
            // 这里两个触发器重叠了
            this.gameObject.GetComponent<SpriteRenderer>().color=Color.red;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color=Color.yellow;
        }
    }
    bool IsOverlappingWithTrump()
    {
        // 获取特朗普的BoxCollider2D组件
        BoxCollider2D trumpCollider = 特朗普.GetComponent<BoxCollider2D>();
        if (trumpCollider == null) return false;

        // 检查两个触发器是否重叠
        return myCollider.bounds.Intersects(trumpCollider.bounds);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (is检测)
        {
            if (other.gameObject == 特朗普.gameObject)
            {
                // 这里两个触发器重叠了
                HandleOverlap();
                
            }
            
        }
        

    }

    void HandleOverlap()
    {
        
        特朗普.GetComponent<特朗普移动>().死亡();

    }

    void 开始检测()
    {
        
        is检测 = true;
    }

    void 删除自己()
    {
        // 获取AudioSource组件
        AudioSource audioSource = GetComponent<AudioSource>();


        // 播放音乐
        audioSource.Play();

        // 等待音频播放完毕后删除游戏对象
        // 音频长度（秒）乘以1000转换为毫秒
        Invoke("DestroyGameObject", audioSource.clip.length);
        sjsc.当前个数 -= 1;
        sjsc.躲过子弹数 += 1;
        sjsc.总分数 += 1;
    }

    private void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
    private void Start()
    {
        var 开枪时间 = Random.Range(1f, 2.5f);
        Invoke("开始检测",开枪时间 );
        Invoke("删除自己", 开枪时间+0.05f);// 2秒后开始检测
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class shoot : MonoBehaviour
{
    public 图片晃动 tphd;
    public  int 子弹数 = 3;
    public BoxCollider2D 真实碰撞;
    public BoxCollider2D 虚拟碰撞;

    public AudioSource 枪声;
    public AudioSource 惨叫;
    public AudioSource Fight;

    public AudioClip 枪声1;
    public AudioClip 枪声2;
    public AudioResource 惨叫声;
    public Sprite 失败图片;
    public Sprite 成功图片;

    public GameObject 刺杀失败面板;
    public GameObject 刺杀成功面板;

    public GameObject 信息展示面板;
    public TextMeshProUGUI 击中检查;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI 计时显示;
    public GameObject UI父;
    private bool 计时;
    private float timer;
    private void Start()
    {
        计时 = true;
    }

    void Update()
    {
        if (计时)
        {
            
            timer += Time.deltaTime;
        }

        计时显示.text = timer.ToString("用时:000.000");
        if (Input.GetMouseButtonDown(0))
        {
            if (子弹数<=0)
            {
                刺杀失败面板.SetActive(true);
                return;
            }
            else
            {
                子弹数 -= 1;
            }
            枪声.clip = (子弹数%2 == 0) ? 枪声1 : 枪声2;
            枪声.Play();
            Debug.Log("鼠标按下");
            // 检查鼠标是否在真实碰撞器的范围内
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            tphd.enabled = true;
   

            
            if (hit.collider != null && hit.collider == 真实碰撞)
            {
                tphd.enabled = false;

                    惨叫.Play();
                    刺杀成功面板.SetActive(true);
                    击中检查.text = "刺杀成功!";
                    计时 = false;

            }
            else if (hit.collider != null && hit.collider == 虚拟碰撞)
            {
                tphd.enabled = false;

                    Fight.Play();
                    刺杀失败面板.SetActive(true);
                    击中检查.text = "命中特朗普的耳朵!特勤局将你击毙,刺杀失败!";
                    计时 = false;
                    this.enabled = false;

            }
            else if (hit.collider.gameObject.tag == "特勤局")
            {
                Fight.Play();
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                击中检查.text = "命中特勤局,特勤局发出惨叫!计时+20s";
                timer += 20;

            }
            else
            {
                击中检查.text = "未命中!";
                Fight.Play();
            }
        }

        tmp.text = "当前子弹数:" + (子弹数).ToString();
    }

}

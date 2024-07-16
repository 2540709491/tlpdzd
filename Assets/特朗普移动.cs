using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 特朗普移动 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject 失败面板;
    public TextMeshProUGUI tmp;
    public 暂停游戏 zt;
    public AudioSource _惨叫;
    public Button 上移动按钮;
    public Button 下移动按钮;
    public Button 左移动按钮;
    public Button 右移动按钮;
    private float timer;
    private Vector2 moveDirection = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 为按钮添加点击事件监听
        上移动按钮.onClick.AddListener(() => SetMoveDirection(0, 1));
        下移动按钮.onClick.AddListener(() => SetMoveDirection(0, -1));
        左移动按钮.onClick.AddListener(() => SetMoveDirection(-1, 0));
        右移动按钮.onClick.AddListener(() => SetMoveDirection(1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        tmp.text = timer.ToString("存活时间:0.000秒");

        // 处理键盘输入
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // 将键盘输入和按钮点击事件的移动方向合并
        rb.velocity = (new Vector2(moveHorizontal, moveVertical) + moveDirection) * 5f;
    }

    public void 死亡()
    {
        _惨叫.Play();
        失败面板.SetActive(true);
        zt.暂停();
        Invoke("delgb",_惨叫.clip.length);
    }

    void delgb()
    {
        Destroy(gameObject);
    }
    void SetMoveDirection(float xDir, float yDir)
    {
        // 这里可以添加逻辑来处理同时按下多个按钮的情况
        // 例如，如果按下左和上，moveDirection将是(-1, 1)
        moveDirection = new Vector2(xDir, yDir);
    }
}
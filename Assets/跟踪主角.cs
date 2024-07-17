using UnityEngine;

public class 跟踪主角 : MonoBehaviour
{
    public GameObject 主角;

    void Update()
    {
        transform.position = 主角.transform.position;
        if (GetComponent<Camera>()!=null)
        {
            transform.position =new Vector3(transform.position.x,transform.position.y, -10);
        }
        
    }
}

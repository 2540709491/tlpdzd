using UnityEngine;

public class 图片晃动 : MonoBehaviour
{
    public float speed = 10f;
    public float amplitude = 10f;
    public float minScale = 0.4f;
    public float maxScale = 1.8f;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private bool scaleUp = true;
    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    void Update()
    {
        float offsetX = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y, originalPosition.z);
        if (scaleUp)
        {
            transform.localScale = new Vector3(originalScale.x * Mathf.Lerp(minScale, maxScale, Mathf.Sin(Time.time * speed)),
                originalScale.y * Mathf.Lerp(minScale, maxScale, Mathf.Sin(Time.time * speed)),
                originalScale.z);

            if (transform.localScale.x >= maxScale)
            {
                scaleUp = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(originalScale.x * Mathf.Lerp(maxScale, minScale, Mathf.Sin(Time.time * speed)),
                originalScale.y * Mathf.Lerp(maxScale, minScale, Mathf.Sin(Time.time * speed)),
                originalScale.z);

            if (transform.localScale.x <= minScale)
            {
                scaleUp = true;
            }
        }
    }
    }


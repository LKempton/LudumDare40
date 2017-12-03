using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSize : MonoBehaviour {

    [SerializeField]
    private float maxSize = 5.0f;
    [SerializeField]
    private float stepSize = 0.1f;
    Vector3 startSize;

    private void Start()
    {
        GameManager.instance.AddCook(this);
        startSize = transform.localScale;
    }

    public void IncreaseSize(float multiplier)
    {
        float size = stepSize * multiplier;
        transform.localScale = new Vector3(startSize.x +size, startSize.y + size, transform.localScale.z);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1, maxSize), Mathf.Clamp(transform.localScale.y, 1, maxSize));
    }

    public void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + stepSize, transform.localScale.y + stepSize, transform.localScale.z);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1, maxSize), Mathf.Clamp(transform.localScale.y, 1, maxSize));
    }
}

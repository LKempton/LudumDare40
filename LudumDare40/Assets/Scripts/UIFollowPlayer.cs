using UnityEngine.UI;
using UnityEngine;

public class UIFollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private RectTransform pos;
    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        pos = GetComponent<RectTransform>();    
    }
    private void Update()
    {
        pos.position = RectTransformUtility.WorldToScreenPoint(Camera.main, player.transform.position + offset);
    }
}

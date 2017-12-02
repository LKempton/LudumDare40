using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private CircleCollider2D col;

    [SerializeField]
    private float xClamp;
    [SerializeField]
    private float yClamp;

    private bool isOverPlayer = false;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            isOverPlayer = true;
            Cursor.visible = false;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xClamp, xClamp), Mathf.Clamp(transform.position.y, -yClamp, yClamp));
        }    
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isOverPlayer = false;
            Cursor.visible = true;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

        float radius = col.radius;

        float difference = Vector3.Distance(transform.position, mousePos);

        if (Input.GetMouseButton(0) && (difference > radius) && isOverPlayer) 
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xClamp, xClamp), Mathf.Clamp(transform.position.y, -yClamp, yClamp));
        }
    }
}

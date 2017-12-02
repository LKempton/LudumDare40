using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooksMovement : MonoBehaviour {
    [SerializeField]
    float speed = 5, movementRate = 6, randomRange =2;
   
    Rigidbody2D rbody;

	// Use this for initialization
	void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
	}

    IEnumerator Move()
    {
        while (true)
        {
            transform.Rotate(0, 0, Random.Range(-90f, 90f), Space.Self);
            rbody.velocity = transform.right * speed;
            yield return new WaitForSeconds(movementRate + Random.Range(-0.5f*randomRange,0.5f*randomRange));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision occured");
        transform.Rotate(0, 0, 180, Space.Self);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame

}

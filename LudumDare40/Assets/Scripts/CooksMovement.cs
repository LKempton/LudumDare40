﻿using System.Collections;
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
            transform.Rotate(0, 0, Random.Range(0, 359.999f));
            rbody.velocity = transform.right * speed;
            yield return new WaitForSeconds(movementRate + Random.Range(-0.5f*randomRange,0.5f*randomRange));
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame

}

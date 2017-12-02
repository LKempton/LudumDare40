using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour {

    private LevelGeneration lg;

    private void Start()
    {
        lg = GameObject.FindWithTag("GameController").GetComponent<LevelGeneration>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Node"))
        {
            GameObject node = col.gameObject;

            lg.TriggerNode(node);
        }
        else if (col.gameObject.CompareTag("Cook"))
        {
            lg.FailureState();
        }
    }
}

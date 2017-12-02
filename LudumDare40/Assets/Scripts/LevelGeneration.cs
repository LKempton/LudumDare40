using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    [SerializeField]
    private GameObject[] firstNodes;
    [SerializeField]
    private GameObject[] secondNodes;
    [SerializeField]
    private GameObject[] thirdNodes;
    [SerializeField]
    private GameObject[] fourthNodes;

    private GameObject nextNode;
    private int nextIndex;
    private GameObject[] nodePath; 

    void GeneratePath()
    {
        nodePath = new GameObject[4];

        nodePath[0] = firstNodes[Random.Range(0, firstNodes.Length - 1)];
        nodePath[1] = secondNodes[Random.Range(0, secondNodes.Length - 1)];
        nodePath[2] = thirdNodes[Random.Range(0, thirdNodes.Length - 1)];
        nodePath[3] = fourthNodes[Random.Range(0, fourthNodes.Length - 1)];
    }

    void TogglePulses(GameObject next)
    {
        for (int i = 0; i < nodePath.Length; i++)
        {
            nodePath[i].GetComponent<OverlayPulse>().TogglePulse();
        }

        next.GetComponent<OverlayPulse>().TogglePulse();
    }

    public void TriggerNode(GameObject node)
    {
        if (node == nextNode)
        {
            nextIndex++;

            if (nextIndex >= nodePath.Length)
            {
                GeneratePath();
                nextIndex = 0;
            }

            nextNode = nodePath[nextIndex];
            TogglePulses(nextNode);
        }
        else
        {
            Debug.Log("Wrong node");
        }
    }
}

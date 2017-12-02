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

    private void Start()
    {
        Invoke("IntiateGame", 3);
    }

    void IntiateGame()
    {
        GeneratePath();

        nextIndex = 0;
        nextNode = nodePath[nextIndex];

        TogglePulses(nextNode);
    }

    void GeneratePath()
    {
        nodePath = new GameObject[4];

        nodePath[0] = firstNodes[Random.Range(0, firstNodes.Length)];
        nodePath[1] = secondNodes[Random.Range(0, secondNodes.Length)];
        nodePath[2] = thirdNodes[Random.Range(0, thirdNodes.Length)];
        nodePath[3] = fourthNodes[Random.Range(0, fourthNodes.Length)];
    }

    void TogglePulses(GameObject next)
    {
        DisableAllPulses();

        next.GetComponent<OverlayPulse>().TogglePulse(true);
    }

    public void TriggerNode(GameObject node)
    {
        if (node == nextNode)
        {
            Debug.Log("Correct Node");

            nextIndex++;

            if (nextIndex >= nodePath.Length)
            {
                GeneratePath();
                nextIndex = 0;
            }

            nextNode = nodePath[nextIndex];
            TogglePulses(nextNode);
        }
        else if (node != nextNode)
        {
            Debug.Log("Wrong node");
            nextIndex = 0;
            nextNode = nodePath[nextIndex];
            TogglePulses(nextNode);
        }
    }

    void DisableAllPulses()
    {
        for (int i = 0; i < firstNodes.Length; i++)
        {
            firstNodes[i].GetComponent<OverlayPulse>().TogglePulse(false);
        }

        for (int i = 0; i < secondNodes.Length; i++)
        {
            secondNodes[i].GetComponent<OverlayPulse>().TogglePulse(false);
        }

        for (int i = 0; i < thirdNodes.Length; i++)
        {
            thirdNodes[i].GetComponent<OverlayPulse>().TogglePulse(false);
        }

        for (int i = 0; i < fourthNodes.Length; i++)
        {
            fourthNodes[i].GetComponent<OverlayPulse>().TogglePulse(false);
        }
    }
}

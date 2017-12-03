using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGeneration : MonoBehaviour {

    [SerializeField]
    private GameObject[] firstNodes;
    [SerializeField]
    private GameObject[] secondNodes;
    [SerializeField]
    private GameObject[] thirdNodes;
    [SerializeField]
    private GameObject[] fourthNodes;

    [SerializeField]
    private GameObject cookSpawn;
    [SerializeField]
    private GameObject cookPrefab;
    [SerializeField]
    private GameObject cookParent;
    [SerializeField]
    private int maxCookSpawn = 15;
    private int currentCookCount = 0;

    private Transform[] cookSpawnLocations;
    

    private GameObject nextNode;
    private int nextIndex = 0;
    private GameObject[] nodePath;

    [SerializeField]
    private GameObject readyText;
    private bool gameHasStarted;

    private void Start()
    {
        GeneratePath();

        DisableAllPulses();
        cookSpawnLocations = cookSpawn.GetComponentsInChildren<Transform>();

        SpawnCook();

        nextIndex = 0;
        nextNode = nodePath[nextIndex];

        //Invoke("IntiateGame", 1);

        gameHasStarted = false;
        StartCoroutine(StartTime());
    }

    void SpawnCook()
    {
        if (currentCookCount>= maxCookSpawn)
        {
            return;
        }
        currentCookCount++;

        GameObject newCook = GameObject.Instantiate(cookPrefab);

        newCook.transform.position = cookSpawnLocations[Random.Range((int)0, cookSpawnLocations.Length - 1)].position;

        newCook.transform.Rotate(0, 0, Random.Range(0,359.999f));
        newCook.transform.parent = cookParent.transform;
    }

    void IntiateGame()
    {
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
            GameManager.instance.PlayStationAudio(nextIndex);
            node.GetComponent<ParticleSystem>().Play();

            nextIndex++;
            if (nextIndex >= nodePath.Length)
            {
                SpawnCook();
                GameManager.instance.GainPoints(1);
                GeneratePath();
                nextIndex = 0;
            }

            nextNode = nodePath[nextIndex];
            TogglePulses(nextNode);
        }
        else if (node != nextNode)
        {
            FailureState();
        }
    }

    public void FailureState()
    {
        if (gameHasStarted)
        {
            GameManager.instance.SmashAudio();
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

    IEnumerator StartTime()
    {
        readyText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        readyText.GetComponent<Text>().text = "Steady?";

        yield return new WaitForSeconds(1.5f);

        IntiateGame();

        readyText.GetComponent<Text>().text = "COOK!";

        yield return new WaitForSeconds(2f);

        gameHasStarted = true;
        readyText.SetActive(false);
        readyText.GetComponent<Text>().text = "Ready?";

    }
}

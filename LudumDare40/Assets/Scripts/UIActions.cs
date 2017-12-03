using UnityEngine.SceneManagement;
using UnityEngine;

public class UIActions : MonoBehaviour {

    [SerializeField]
    private GameObject tutorialPanel;
    [SerializeField]
    private GameObject creditsPanel;

    private bool isTutorialOpen = false;
    private bool isCreditsOpen = false;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        if (isTutorialOpen)
        {
            tutorialPanel.SetActive(false);
            isTutorialOpen = false;
        }
        else if (!isTutorialOpen)
        {
            tutorialPanel.SetActive(true);
            isTutorialOpen = true;
        }
    }

    public void ShowCredits()
    {
        if (isCreditsOpen)
        {
            creditsPanel.SetActive(false);
            isCreditsOpen = false;
        }
        else if (!isCreditsOpen)
        {
            creditsPanel.SetActive(true);
            isCreditsOpen = true;
        }
    }
}

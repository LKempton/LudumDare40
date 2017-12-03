using UnityEngine.SceneManagement;
using UnityEngine;

public class UIActions : MonoBehaviour {

    [SerializeField]
    private GameObject panel;

    private bool isOpen = false;

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowTutorial()
    {
        if (isOpen)
        {
            panel.SetActive(false);
            isOpen = false;
        }
        else if (!isOpen)
        {
            panel.SetActive(true);
            isOpen = true;
        }
    }
}

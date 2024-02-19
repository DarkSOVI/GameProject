using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject HowToPlayPage;
    [SerializeField] private GameObject MainPage;

    public void Start()
    {
        MainPage.SetActive(true);
        HowToPlayPage.SetActive(false);
    }
    public void ChangeScene (int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void OpenHowToPlay()
    {
        MainPage.SetActive(false);
        HowToPlayPage.SetActive(true);
    }

    public void ReturnToMainPage()
    {
        HowToPlayPage.SetActive(false);
        MainPage.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

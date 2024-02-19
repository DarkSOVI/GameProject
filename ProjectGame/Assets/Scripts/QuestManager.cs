using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [Header("Phone UI")]
    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject storeButton;
    [SerializeField] private GameObject antivirusButton;
    [SerializeField] private GameObject virusButton;
    [SerializeField] private GameObject downloadButton;
    [SerializeField] private GameObject storePage;
    [SerializeField] private GameObject homePage;
    [SerializeField] private GameObject downloadPage;
    [SerializeField] private GameObject downloadedPage;
    [SerializeField] private GameObject antivirusPage;
    [SerializeField] private GameObject scanningPage;
    [SerializeField] private GameObject scanPage;
    [SerializeField] private GameObject deletingPage;
    [SerializeField] private GameObject deletedPage;

    [Header("Game Comp")]
    [SerializeField] private GameObject board;
    public LevelChanger changer;

    public static bool questIsFinished;
    public static bool antivirusDownloaded;
    public static bool virusDeleted;
    public static bool homePageActive;
    private void Start()
    {
        homePageActive = false;
        questIsFinished = false;
        antivirusDownloaded = false;
        virusDeleted = false;
        antivirusButton.SetActive(false);
        storePage.SetActive(false);
        downloadPage.SetActive(false);
        downloadedPage.SetActive(false);
        antivirusPage.SetActive(false);
        scanningPage.SetActive(false);
        scanPage.SetActive(false);
        deletingPage.SetActive(false);
        deletedPage.SetActive(false);
        board.SetActive(false);

    }
    public void OpenStore()
    {
        if (antivirusDownloaded == false)
        {
            homePage.SetActive(false);
            storePage.SetActive(true);
            homePageActive = false;
        }
    }
    public IEnumerator DownloadAntivirus()
    {
        storePage.SetActive(false);
        downloadPage.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        antivirusDownloaded = true;
        downloadPage.SetActive(false);
        downloadedPage.SetActive(true);
        homePageActive = false;
    }
    public void DownloadProgram ()
    {
        StartCoroutine(DownloadAntivirus());
    }
    public void AntivirusDownloaded ()
    {
        if (antivirusDownloaded == true)
        {
            antivirusButton.SetActive(true);
        }
    }
    public void OpenAntivirus ()
    {
        if (antivirusDownloaded == true && virusDeleted == false)
        {
            homePage.SetActive(false);
            antivirusPage.SetActive(true);
            homePageActive = false;
        }
    }
    public IEnumerator ScanForVirus()
    {
        antivirusPage.SetActive(false);
        scanningPage.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        scanningPage.SetActive(false);
        scanPage.SetActive(true);
        homePageActive = false;
    }
    public void ScanPhone ()
    {
        StartCoroutine(ScanForVirus());
    }
    public IEnumerator RemoveVirus()
    {
        scanPage.SetActive(false);
        deletingPage.SetActive(true);
        yield return new WaitForSeconds(3.1f);
        virusDeleted = true;
        deletingPage.SetActive(false);
        deletedPage.SetActive(true);
        homePageActive = false;
    }
    public void DeleteVirus ()
    {
        StartCoroutine(RemoveVirus());
    }
    public void ReturnToHome ()
    {
        homePageActive = true;
        homePage.SetActive(true);
        storePage.SetActive(false);
        downloadPage.SetActive(false);
        downloadedPage.SetActive(false);
        antivirusPage.SetActive(false);
        scanningPage.SetActive(false);
        scanPage.SetActive(false);
        deletingPage.SetActive(false);
        deletedPage.SetActive(false);
    }
    public void Update()
    {
        AntivirusDownloaded();
        if (virusDeleted == true)
        {
            virusButton.SetActive(false);
        }
        if (virusDeleted == true && homePageActive == true)
        {
            EndQuest();
        }


    }
    public void EndQuest ()
    {
            board.SetActive(true);
        if (InputManager.GetInstance().GetSubmitPressed())
        {
            changer.FadeToLevel();
        }
    }

}

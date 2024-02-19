using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlekseyQuest : MonoBehaviour
{
    public bool questCompleted;
    public LevelChanger changer;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject visualCue;

    public void Awake()
    {
        questCompleted = false;
        wall.SetActive(true);
        board.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (DialogueManager.dialogueIsFinished == true)
        {
            TransferToPhone();
        }
        
    }
    public void TransferToPhone ()
    {
        board.SetActive(true);
        Destroy(visualCue);

        if (InputManager.GetInstance().GetSubmitPressed())
        {
            changer.FadeToLevel();
        }
    }
}

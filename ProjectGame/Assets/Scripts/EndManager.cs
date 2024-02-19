using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static bool questFinished;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject visualCue;
    public LevelChanger changer;
    public void Awake()
    {
        questFinished = false;
        board.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.dialogueIsFinished == true)
        {
            questFinished = true;
        }
        if (questFinished == true)
        {
            board.SetActive(true);
            Destroy(visualCue);
            if(InputManager.GetInstance().GetSubmitPressed())
            {
                changer.FadeToLevel();
            }
        }
        
    }
}

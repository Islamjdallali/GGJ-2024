using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGamesBase : MonoBehaviour
{
    public bool isCompleted;
    public float timer;
    public float duration;
    public MMLGameManager gameManager;

    [SerializeField] private GameObject punchlineGO;
    [SerializeField] private Animator stageAnim;
    [SerializeField] private AudioSource minigameMusic;

    public void Init()
    {
        Debug.Log("Initialised Microgame");
        punchlineGO.SetActive(false);
        timer = duration;
        gameManager = GameObject.Find("GameManager").GetComponent<MMLGameManager>();
        stageAnim = GameObject.Find("Stage").GetComponent<Animator>();
        minigameMusic = GameObject.Find("Minigame Music").GetComponent<AudioSource>();
        minigameMusic.Play();
        //log any null references here
    }

    public void Tick()
    {
        timer -= Time.deltaTime * gameManager.gameSpeed;

        if ( timer <= 0)
        {
            timer = 0;
            DetermineResult();
        }

        if (isCompleted) 
        {
            punchlineGO.SetActive(true);
        }
    }

    private void DetermineResult()
    {
        if (isCompleted) 
        {
            gameManager.WinMicroGame();
        }
        else
        {
            gameManager.LoseMicroGame();
        }

        stageAnim.Play("TransitionToStage");

        Destroy(this.gameObject);
    }

    public void ShowPunchline()
    {
        punchlineGO.SetActive(true);
    }
}

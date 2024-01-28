using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGamesBase : MonoBehaviour
{
    public bool isCompleted;
    public float timer;
    public float duration;
    public MMLGameManager gameManager;

    [SerializeField] private bool useMusic2;

    [SerializeField] private GameObject punchlineGO;
    [SerializeField] private Animator stageAnim;
    [SerializeField] private AudioSource minigameMusic;
    [SerializeField] private AudioSource minigameWinJingle;

    private bool isplayed;

    public void Init()
    {
        Debug.Log("Initialised Microgame");
        punchlineGO.SetActive(false);
        timer = duration;
        gameManager = GameObject.Find("GameManager").GetComponent<MMLGameManager>();
        stageAnim = GameObject.Find("Stage").GetComponent<Animator>();

        //hacky solution cus I only have 2 hours left
        if (useMusic2)
        {
            minigameMusic = GameObject.Find("Minigame Music 2").GetComponent<AudioSource>();
        }
        else
        {
            minigameMusic = GameObject.Find("Minigame Music").GetComponent<AudioSource>();
        }

        minigameWinJingle = GameObject.FindGameObjectWithTag("MGWin").GetComponent<AudioSource>();
        minigameMusic.Play();
        isplayed = false;
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

            if (!isplayed)
            {
                minigameWinJingle.Play();
                isplayed = true;
            }
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
        minigameMusic.Stop();

        Destroy(this.gameObject);
    }

    public void ShowPunchline()
    {
        punchlineGO.SetActive(true);
    }
}

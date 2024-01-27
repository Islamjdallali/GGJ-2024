using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGamesBase : MonoBehaviour
{
    public bool isCompleted;
    public int speed;
    public float timer;
    public float duration;

    [SerializeField] private GameObject punchlineGO;
    [SerializeField] private MMLGameManager gameManager;
    [SerializeField] private Animator stageAnim;

    public void Init()
    {
        Debug.Log("Initialised Microgame");
        punchlineGO.SetActive(false);
        timer = duration;
        gameManager = GameObject.Find("GameManager").GetComponent<MMLGameManager>();
        stageAnim = GameObject.Find("Stage").GetComponent<Animator>();
        //log any null references here
    }

    public void Tick()
    {
        timer -= Time.deltaTime * speed;

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

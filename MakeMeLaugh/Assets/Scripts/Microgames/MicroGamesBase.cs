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

    public void Init()
    {
        Debug.Log("Initialised Microgame");
        punchlineGO.SetActive(false);
        timer = duration;
        //log any null references here
    }

    public void Tick()
    {
        timer -= Time.deltaTime * speed;

        if ( timer <= 0)
        {
            timer = 0;
            //fail
            isCompleted = false;
        }
    }

    public void ShowPunchline()
    {
        punchlineGO.SetActive(true);
    }
}

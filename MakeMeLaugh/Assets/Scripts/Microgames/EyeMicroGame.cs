using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMicroGame : MicroGamesBase
{
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Tick();

        if (score >= 2)
        {
            isCompleted = true;
        }
    }
}

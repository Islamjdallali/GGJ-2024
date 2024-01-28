using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Profiling;

public class FrogMicroGame : MicroGamesBase
{
    [SerializeField] private GameObject fliesGO;
    [SerializeField] private int fliesNo;
    private Vector2 spawnDimension;
    public int score;

    private void Start()
    {
        Init();
        fliesNo = Random.Range(3, 6);
        SpawnBugs();
    }

    private void Update()
    {
        Tick();
        if (score >= fliesNo) 
        {
            isCompleted = true;
        }
    }

    void SpawnBugs()
    {
        for (int i = 0; i < fliesNo; i++)
        {
            spawnDimension = new Vector2(Random.Range(-340, 341), Random.Range(200, -200));
            var fly = Instantiate(fliesGO, transform);
            fly.transform.localPosition = spawnDimension;
        }
    }
}

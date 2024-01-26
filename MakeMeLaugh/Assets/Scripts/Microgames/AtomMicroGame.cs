using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class AtomMicroGame : MicroGamesBase
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject atomObject;
    [SerializeField] private List<GameObject> spawnedAtomObjects;

    private int numberToSpawn;

    void Start()
    {
        Init();

        numberToSpawn = Random.Range(3,spawnPoints.Length);

        int liarNo = Random.Range(0,numberToSpawn);

        for (int i = 0; i < numberToSpawn; i++) 
        {
            spawnedAtomObjects.Add(Instantiate(atomObject, spawnPoints[i].transform));
        }

        spawnedAtomObjects[liarNo].GetComponent<AtomBehaviour>().isLiar = true;
    }

    private void Update()
    {
        Tick();
    }

    public void AtomSelected()
    {
        for (int i = 0; i < spawnedAtomObjects.Count; i++)
        {
            spawnedAtomObjects[i].GetComponent<Button>().interactable = false;
        }
    }
}

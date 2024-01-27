using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] microGames;
    [SerializeField] private Animator transitionToMicrogameAnim;
    [SerializeField] private GameObject[] microGameJoke;
    [SerializeField] private MMLGameManager gameManager;

    public bool isChoosing;
    public enum EMicrogames
    {
        eAtoms
    }

    public EMicrogames microgamesEnum;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log((EMicrogames)Random.Range(0,System.Enum.GetValues(typeof(EMicrogames)).Length));
        isChoosing = true;
    }

    private void Update()
    {
        if (isChoosing && gameManager.health > 0)
        {
            ChooseMicroGameJoke();
            isChoosing = false;
        }
    }

    void ChooseMicroGameJoke()
    {
        microGameJoke[Random.Range(0, System.Enum.GetValues(typeof(EMicrogames)).Length)].SetActive(true);
    }

    public void SpawnMicroGame()
    {
       Instantiate(microGames[Random.Range(0, System.Enum.GetValues(typeof(EMicrogames)).Length)]);
        microGameJoke[Random.Range(0, System.Enum.GetValues(typeof(EMicrogames)).Length)].SetActive(false);
    }
}

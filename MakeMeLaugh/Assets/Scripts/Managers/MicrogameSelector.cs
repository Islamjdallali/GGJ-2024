using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] microGames;
    [SerializeField] private Animator transitionToMicrogameAnim;
    [SerializeField] private GameObject[] microGameJoke;

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
        if (isChoosing)
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
    }
}

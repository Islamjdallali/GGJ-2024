using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] microGames;
    [SerializeField] private Animator transitionToMicrogameAnim;
    [SerializeField] private GameObject[] microGameJoke;
    [SerializeField] private MMLGameManager gameManager;
    [SerializeField] private AudioSource jingleIn;
    private int randNo;

    public bool isChoosing;
    public enum EMicrogames
    {
        eAtoms,
        eNoah
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
            jingleIn.Play();
            ChooseMicroGameJoke();
            isChoosing = false;
        }
    }

    void ChooseMicroGameJoke()
    {
        randNo = Random.Range(0, System.Enum.GetValues(typeof(EMicrogames)).Length);
        microGameJoke[randNo].SetActive(true);
    }

    public void SpawnMicroGame()
    {
       Instantiate(microGames[randNo]);
        microGameJoke[randNo].SetActive(false);
    }
}

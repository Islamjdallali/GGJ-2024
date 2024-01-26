using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] microGames;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < microGames.Length; i++) 
        {
            Instantiate(microGames[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

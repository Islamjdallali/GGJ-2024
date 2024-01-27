using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private MMLGameManager gameManager;

    [SerializeField] private AudioSource[] music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].pitch = gameManager.gameSpeed;
        }
    }
}

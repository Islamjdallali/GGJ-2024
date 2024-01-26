using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMicroGame : MonoBehaviour
{
    [SerializeField] private MicrogameSelector selector;

    public void ShowMicroGame()
    {
        selector.SpawnMicroGame();
    }
}

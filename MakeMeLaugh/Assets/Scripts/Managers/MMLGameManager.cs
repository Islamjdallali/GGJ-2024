using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMLGameManager : MonoBehaviour
{
    public int score;
    public int health;

    [SerializeField] private Animator standupAnim;

    public void WinMicroGame()
    {
        standupAnim.Play("Win");
        score += 1;
    }
}

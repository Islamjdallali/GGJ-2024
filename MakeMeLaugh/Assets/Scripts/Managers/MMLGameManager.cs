using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MMLGameManager : MonoBehaviour
{
    public int score;
    public int health;

    [SerializeField] private Animator standupAnim;
    [SerializeField] private Animator crowdAnim;
    [SerializeField] private Animator loseTextAnim;

    [SerializeField] private GameObject[] heartSprites;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score : " + score;
    }

    public void WinMicroGame()
    {
        standupAnim.Play("Win");
        crowdAnim.Play("Crowd Laugh");
        score += 1;
    }

    public void LoseMicroGame()
    {
        loseTextAnim.Play("LoseText");
        standupAnim.Play("Lose");
        heartSprites[health - 1].SetActive(false);
        health -= 1;
    }
}

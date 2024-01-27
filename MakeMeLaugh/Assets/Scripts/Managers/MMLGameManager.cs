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
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        gameOverText.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = "Score : " + score;

        if (health <= 0)
        {
            if (!standupAnim.GetCurrentAnimatorStateInfo(0).IsName("Lose"))
            {
                gameOverUI.SetActive(true);
                gameOverText.SetActive(true);
            }
        }
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

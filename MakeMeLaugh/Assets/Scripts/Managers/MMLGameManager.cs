using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MMLGameManager : MonoBehaviour
{
    public int score;
    public int health;
    public float gameSpeed;

    [SerializeField] private Animator standupAnim;
    [SerializeField] private Animator crowdAnim;
    [SerializeField] private Animator loseTextAnim;

    [SerializeField] private GameObject[] heartSprites;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private AudioSource jingleWin;
    [SerializeField] private AudioSource jingleLose;
    [SerializeField] private AudioSource MinigameMusic;

    private void Start()
    {
        gameOverText.SetActive(false);
        gameOverUI.SetActive(false);
        gameSpeed = 1;
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
        MinigameMusic.Stop();
        jingleWin.Play();
        standupAnim.Play("Win");
        crowdAnim.Play("Crowd Laugh");
        score += 1;
        if (gameSpeed < 2)
        {
            gameSpeed += 0.02f;
        }
    }

    public void LoseMicroGame()
    {
        MinigameMusic.Stop();
        jingleLose.Play();
        loseTextAnim.Play("LoseText");
        standupAnim.Play("Lose");
        heartSprites[health - 1].SetActive(false);
        health -= 1;
        if (gameSpeed < 2)
        {
            gameSpeed += 0.02f;
        }
    }
}

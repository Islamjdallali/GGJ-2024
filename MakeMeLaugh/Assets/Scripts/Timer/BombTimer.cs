using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    [SerializeField] private Sprite[] bombSprites = null;
    [SerializeField] private Image currentImage;
    [SerializeField] private int currentImageIndex;
    [SerializeField] private MicroGamesBase microGameBase;
    private float alpha;
    private float threshold;
    [SerializeField] private AudioSource tick;

    // Start is called before the first frame update
    void Start()
    {
        alpha = microGameBase.duration / bombSprites.Length;
        threshold = microGameBase.duration - alpha;
        currentImageIndex = 0;
        tick = GameObject.FindGameObjectWithTag("Clock").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (microGameBase.timer >= 0)
        {
            currentImage.sprite = bombSprites[currentImageIndex];
        }
        if (microGameBase.timer <= threshold)
        {
            if (currentImageIndex < bombSprites.Length - 1)
            {
                currentImageIndex++;
                if (currentImageIndex >= 4)
                {
                    tick.Play();
                }
            }
            threshold = threshold - alpha;
        }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public MicroGamesBase game;
    public BoatController boat;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (boat.isDead || boat.boatScore >= 3)
        {
            speed = 0;
        }

        transform.Translate(-Vector3.right * speed * Time.deltaTime * game.gameManager.gameSpeed);
    }
}

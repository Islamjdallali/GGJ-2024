using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoatController : MonoBehaviour
{
    public int boatScore;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        boatScore = 0;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isDead)
        {
            transform.position = Input.mousePosition;
        }

        if (boatScore >= 3)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cat")
        {
            other.gameObject.SetActive(false);
            boatScore += 1;
        }
        else if (other.tag == "Obstacle")
        {
            isDead = true;
        }
    }
}

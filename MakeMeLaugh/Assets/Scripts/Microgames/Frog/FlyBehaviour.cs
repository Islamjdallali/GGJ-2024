using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Frog")
        {
            other.GetComponent<FrogController>().microgame.score += 1;
            Destroy(this.gameObject);
        }
    }
}

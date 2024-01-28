using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] locations;

    // Start is called before the first frame update

    private void Awake()
    {
        transform.position = locations[Random.Range(0, locations.Length)].position;
    }
}

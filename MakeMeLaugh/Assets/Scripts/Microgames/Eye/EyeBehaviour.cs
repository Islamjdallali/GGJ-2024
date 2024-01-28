using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] referenceTransform;
    [SerializeField] private Transform[] targets;

    // Start is called before the first frame update
    void Start()
    {

        targets[0].localPosition = referenceTransform[0].localPosition;
        targets[1].localPosition = referenceTransform[1].localPosition;
    }

    private void Update()
    {
        //Debug.Log(referenceTransform[0].localPosition);
    }
}

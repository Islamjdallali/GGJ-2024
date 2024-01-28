using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueBehaviour : MonoBehaviour
{
    [SerializeField] private BoxCollider col;
    public Transform flyTransform;
    private bool followTongue;

    private void Update()
    {
        if (followTongue && flyTransform != null)
        {
            flyTransform.localPosition = col.center;
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fly")
        {
            flyTransform = other.transform;
            //followTongue = true;
        }
    }
}

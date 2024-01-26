using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronBehaviour : MonoBehaviour
{
    public Transform Target;

    public float RotationSpeed = 1;

    public float CircleRadius = 1;

    public float ElevationOffset = 0;

    private Vector3 positionOffset;

    private float angle;

    private void Start()
    {
        int randir = Random.Range(0, 2);

        if (randir == 0)
        {
            RotationSpeed = 1;
        }
        else
        {
            RotationSpeed = -1;
        }
    }

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            ElevationOffset
        );
        transform.position = Target.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
    }
}

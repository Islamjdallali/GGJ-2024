using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeSetupText : MonoBehaviour
{

    [SerializeField] private Animator transitionAnim;

    public void TransitionToMicrogame()
    {
        transitionAnim.Play("TransitionToMicrogame");
    }
}

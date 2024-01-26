using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandupAnimationEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private MicrogameSelector gameSelector;

    public void StopLaughing()
    {
        anim.Play("Idle");
        gameSelector.isChoosing = true;
    }
}

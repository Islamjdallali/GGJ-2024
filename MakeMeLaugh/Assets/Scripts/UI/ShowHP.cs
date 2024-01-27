using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHP : MonoBehaviour
{
    [SerializeField] private Animator standupAnim;
    [SerializeField] private GameObject HP;

    // Update is called once per frame
    void Update()
    {
        if (standupAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            HP.SetActive(false);
        }
        else
        {
            HP.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EyeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    private bool canDrag;
    [SerializeField] private EyeMicroGame game;

    void Start()
    {
        canDrag = true;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (canDrag) 
        {
            dragging = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        dragging = false;
    }

    private void Update()
    {
        if (dragging == true)
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            dragging = false;
            canDrag = false;
            game.score += 1;
        }
    }
}

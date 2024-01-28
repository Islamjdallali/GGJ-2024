using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using UnityEngine.UIElements;

public class FrogController : MonoBehaviour
{
    [SerializeField] private UILineRenderer lr;
    [SerializeField] private int lineSpeed;
    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private BoxCollider col;
    [SerializeField] private Animator anim;
    [SerializeField] private TongueBehaviour tongue;
    public FrogMicroGame microgame;
    private bool retracting;
    private Vector2 movePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !retracting)
        {
            lr.enabled = true;
            anim.Play("FrogMouthOpen");
            StartGrapple();
        }
        if (retracting)
        {
            StartCoroutine(Retract());
        }
    }

    private void StartGrapple()
    {
        Vector2 direction = Input.mousePosition - transform.position;

        StartCoroutine(Grapple());
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;

        lr.SetPoints(0, transform.localPosition);
        Vector2 newPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        parentCanvas.transform as RectTransform,
        Input.mousePosition, parentCanvas.worldCamera,
        out movePos);

        for (; t < time; t += lineSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(Vector2.zero, movePos, t / time);
            col.center = newPos;
            lr.SetPoints(0, Vector2.zero);
            lr.SetPoints(1, newPos);
            yield return null;
        }

        col.center = movePos;
        lr.SetPoints(1, movePos);
        retracting = true;

    }

    IEnumerator Retract()
    {
        float t = 0;
        float time = 10;

        lr.SetPoints(0, transform.localPosition);
        Vector2 newPos;

        for (; t < time; t += lineSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(movePos, Vector2.zero, t / time);
            col.center = newPos;
            lr.SetPoints(0, Vector2.zero);
            lr.SetPoints(1, newPos);
            if (tongue.flyTransform != null)
            {
                tongue.flyTransform.localPosition = newPos;
                Debug.Log(tongue.flyTransform.position);
            }
            yield return null;
        }

        lr.SetPoints(1, movePos);
        anim.Play("FrogMouthClose");
        lr.enabled = false;
        retracting = false;
    }
}

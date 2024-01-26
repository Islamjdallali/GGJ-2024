using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AtomBehaviour : MonoBehaviour
{
    public bool isLiar;

    [SerializeField] private int electronNo;
    [SerializeField] private GameObject[] electrons;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private Animator anim;
    [SerializeField] private AtomMicroGame atomMicroGame;

    [SerializeField] private float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        //god forgive me for this but I am not bothered to implement a better solution
        atomMicroGame = GameObject.Find("Atom Microgame Canvas(Clone)").GetComponent<AtomMicroGame>();

        for (int i = 0; i < electrons.Length; i++)
        {
            electrons[i].SetActive(false);
        }

        electronNo = Random.Range(1, electrons.Length);

        for (int i = 0; i < electronNo; i++)
        {
            electrons[i].SetActive(true);
        }

        if (!isLiar && numberText)
        {
            numberText.text = electronNo.ToString();
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                numberText.text = (electronNo + 1).ToString();
            }
            else
            {
                numberText.text = (electronNo - 1).ToString();
            }
        }

        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }

    private void Update()
    {

        gameObject.transform.position = new Vector2(startingPos.x + Mathf.Sin(Time.time * speed) * amount, startingPos.y + (Mathf.Cos(Time.time * speed) * amount));
    }

    public void AtomClicked()
    {
        anim.Play("CaughtAnim");

        atomMicroGame.AtomSelected();

        if (isLiar) 
        {
            atomMicroGame.isCompleted = true;
        }
    }
}

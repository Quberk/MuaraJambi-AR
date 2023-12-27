using UnityEngine;
using UnityEngine.UI;

public class BoardingContoller : MonoBehaviour
{
    private int step = 1;

    [SerializeField] private int maxStep;

    [SerializeField] private GameObject container;

    [Header("Moving Panel Animation")]
    [SerializeField] private GameObject nextButtons;
    [SerializeField] private float movingSpeed;
    private Vector3 movingTarget;

    [Header("Step Panels")]
    [SerializeField] private Vector3 panelDistance;

    [Header("Step Boxes")]
    [SerializeField] private Image stepBox1;
    [SerializeField] private Image stepBox2;
    [SerializeField] private Image stepBox3;
    [SerializeField] private Image stepBox4;
    [SerializeField] private Image stepBox5;

    [SerializeField] private Sprite activeBox;
    [SerializeField] private Sprite unactiveBox;

    int lastStep;

    // Start is called before the first frame update
    void Start()
    {
        //First Panel
        stepBox1.sprite = activeBox;
        stepBox2.sprite = unactiveBox;
        stepBox3.sprite = unactiveBox;
        stepBox4.sprite = unactiveBox;
        stepBox5.sprite = unactiveBox;
    }

    private void Update()
    {
        RectTransform containerRect = container.GetComponent<RectTransform>();
        containerRect.localPosition = Vector3.MoveTowards(containerRect.localPosition, movingTarget, movingSpeed * Time.deltaTime);


        if (step >= 5)
        {
            nextButtons.SetActive(false);
            return;
        }

        nextButtons.SetActive(true);
    }

    public void GoToStep(int step)
    {
        this.step = step;

        stepBox1.sprite = unactiveBox;
        stepBox2.sprite = unactiveBox;
        stepBox3.sprite = unactiveBox;
        stepBox4.sprite = unactiveBox;
        stepBox5.sprite = unactiveBox;

        movingTarget = (step - 1) * panelDistance;

        switch (step)
        {
            case 1:
                stepBox1.sprite = activeBox;
                break;

            case 2:
                stepBox2.sprite = activeBox;
                break;

            case 3:
                stepBox3.sprite = activeBox;
                break;

            case 4:
                stepBox4.sprite = activeBox;
                break;

            case 5:
                stepBox5.sprite = activeBox;
                break;

            default:
                break;
        }
    }

    public void NextStep()
    {
        if ((step + 1) > maxStep)
            return;

        step++;

        stepBox1.sprite = unactiveBox;
        stepBox2.sprite = unactiveBox;
        stepBox3.sprite = unactiveBox;
        stepBox4.sprite = unactiveBox;
        stepBox5.sprite = unactiveBox;

        movingTarget = (step - 1) * panelDistance;

        switch (step)
        {
            case 1:
                stepBox1.sprite = activeBox;
                break;

            case 2:
                stepBox2.sprite = activeBox;
                break;

            case 3:
                stepBox3.sprite = activeBox;
                break;

            case 4:
                stepBox4.sprite = activeBox;
                break;

            case 5:
                stepBox5.sprite = activeBox;
                break;

            default:
                break;
        }
    }
}

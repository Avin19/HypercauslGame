using UnityEngine;
using TMPro;
public enum BouseType
{
    Addition,
    Difference,
    Multiple,
    Divided,
}
public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    [Header(" Elemeets ")]
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;

    [Header(" Setting ")]
    [SerializeField] private BouseType rightDoorBouseType;
    [SerializeField] private int rightDoorBouseAmount;
    [SerializeField] private BouseType leftDoorBouseType;
    [SerializeField] private int leftDoorBouseAmount;

    [SerializeField] private int levelMultipler;
    [Header(" Material")]
    [SerializeField] private Color bouseColor;
    [SerializeField] private Color penaltyColor;
    [SerializeField] private Material materialRightDoorShader;
    [SerializeField] private Material materialLeftDoorShader;

    private BouseType ReturnRandomEnum(int index)
    {
        if (index == 0)
        {
            return BouseType.Addition;
        }
        else if (index == 1)
        {
            return BouseType.Difference;
        }
        else if (index == 2)
        {
            return BouseType.Multiple;
        }
        else
        {
            return BouseType.Divided;
        }
    }

    public void Trigger()
    {
        rightDoorBouseAmount = Random.Range(1, 5 * levelMultipler);
        leftDoorBouseAmount = Random.Range(1, 5 * levelMultipler);
        rightDoorBouseType = ReturnRandomEnum(Random.Range(0, 4));
        leftDoorBouseType = ReturnRandomEnum(Random.Range(0, 4));
        transform.GetComponent<BoxCollider>().enabled = true;

        ConfigureDoor();


    }

    private void ConfigureDoor()
    {

        switch (rightDoorBouseType)
        {
            case BouseType.Addition:
                materialRightDoorShader.SetColor("_DotsColor", bouseColor);
                rightDoorText.text = "+" + rightDoorBouseAmount;
                break;
            case BouseType.Difference:
                materialRightDoorShader.SetColor("_DotsColor", penaltyColor);
                rightDoorText.text = "-" + rightDoorBouseAmount;
                break;
            case BouseType.Multiple:
                materialRightDoorShader.SetColor("_DotsColor", penaltyColor);
                rightDoorText.text = "x" + rightDoorBouseAmount;
                break;
            case BouseType.Divided:
                materialRightDoorShader.SetColor("_DotsColor", penaltyColor);
                rightDoorText.text = "/" + rightDoorBouseAmount;
                break;


        }
        switch (leftDoorBouseType)
        {
            case BouseType.Addition:
                materialLeftDoorShader.SetColor("_DotsColor", bouseColor);
                leftDoorText.text = "+" + leftDoorBouseAmount;
                break;
            case BouseType.Difference:
                materialLeftDoorShader.SetColor("_DotsColor", penaltyColor);
                leftDoorText.text = "-" + leftDoorBouseAmount;
                break;
            case BouseType.Multiple:
                materialLeftDoorShader.SetColor("_DotsColor", penaltyColor);
                leftDoorText.text = "x" + leftDoorBouseAmount;
                break;
            case BouseType.Divided:
                materialLeftDoorShader.SetColor("_DotsColor", penaltyColor);
                leftDoorText.text = "/" + leftDoorBouseAmount;
                break;

        }

    }
    public int GetDoorAmount(float xPosition)
    {
        if (xPosition < 0)
        {
            return leftDoorBouseAmount;
        }
        else
        {
            return rightDoorBouseAmount;
        }
    }
    public BouseType GetBouseType(float xPosition)
    {
        if (xPosition < 0)
        {
            return leftDoorBouseType;
        }
        else
        {
            return rightDoorBouseType;
        }
    }

    public void Disable()
    {
        transform.GetComponent<BoxCollider>().enabled = false;
    }


}

using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    enum BouseType
    {
        Addition, Difference
    }
    [Header(" Elemeets ")]
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [Header(" Setting ")]
    [SerializeField] private BouseType rightDoorBouseType;
    [SerializeField] private int rightDoorBouseAmount;
    [SerializeField] private BouseType leftDoorBouseType;
    [SerializeField] private int leftDoorBouseAmount;
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
        else
        {
            return BouseType.Difference;
        }
    }

    public void Trigger()
    {
        rightDoorBouseAmount = Random.Range(1, 30);
        leftDoorBouseAmount = Random.Range(1, 30);
        rightDoorBouseType = ReturnRandomEnum(Random.Range(0, 2));
        leftDoorBouseType = ReturnRandomEnum(Random.Range(0, 2));
        ConfigureDoor();

    }

    private void ConfigureDoor()
    {
        if (rightDoorBouseType == BouseType.Addition)
        {
            materialRightDoorShader.SetColor("_DotsColor", bouseColor);
            rightDoorText.text = "+" + rightDoorBouseAmount;
        }
        else if (rightDoorBouseType == BouseType.Difference)
        {
            materialRightDoorShader.SetColor("_DotsColor", penaltyColor);
            rightDoorText.text = "-" + rightDoorBouseAmount;
        }
        if (leftDoorBouseType == BouseType.Difference)
        {
            materialLeftDoorShader.SetColor("_DotsColor", penaltyColor);
            leftDoorText.text = "-" + leftDoorBouseAmount;

        }
        else if (leftDoorBouseType == BouseType.Addition)
        {
            materialLeftDoorShader.SetColor("_DotsColor", bouseColor);
            leftDoorText.text = "+" + leftDoorBouseAmount;
        }
    }


}

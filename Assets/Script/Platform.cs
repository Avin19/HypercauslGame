
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private LevelsDesign levelsDesign;

    private void Awake()
    {


        for (int i = 0; i < levelsDesign.panels.Capacity; i++)
        {

            Transform pf = Instantiate(levelsDesign.panels[i], new Vector3(0f, 0f, i * 50), Quaternion.identity, transform.parent);

        }
    }
}

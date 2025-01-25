
using UnityEngine;
public class PlatformGenerator

{
    private LevelsDesign level;
    private Transform parentTransform;


    public void SetLevel(LevelsDesign _level, Transform _transform)
    {
        this.level = _level;
        this.parentTransform = _transform;
        StartGenerating();
    }
    private void StartGenerating()
    {


        for (int i = 0; i < level.panels.Capacity; i++)
        {

            Transform pf = GameObject.Instantiate(level.panels[i], new Vector3(0f, 0f, i * 50), Quaternion.identity, parentTransform);

        }
    }
}

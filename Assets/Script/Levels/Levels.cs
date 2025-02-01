using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level List", menuName = " Level / Level list")]
public class Levels : ScriptableObject
{
    public List<LevelsDesign> LevelList = new List<LevelsDesign>();
}

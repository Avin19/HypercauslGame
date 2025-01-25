using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level#", menuName = " Level / Level Design")]
public class LevelsDesign : ScriptableObject
{
    public int level;
    public List<Transform> panels = new List<Transform>();



}

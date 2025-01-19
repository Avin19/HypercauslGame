using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class CrowdSystem : MonoBehaviour
{
   [SerializeField] private float radius, angle;
   [SerializeField] private TextMeshProUGUI countText;


   void Update()
   {
      PlacementOfRunner();
   }
   void PlacementOfRunner()
   {
      int i = 0;
      foreach (Transform child in transform.GetComponentInChildren<Transform>())
      {
         i++;
         child.localPosition = ChildrenPosition(i);
      }
      countText.SetText(i.ToString());
   }

   private Vector3 ChildrenPosition(int index)
   {
      float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
      float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
      return new Vector3(x, 0, z);
   }


}

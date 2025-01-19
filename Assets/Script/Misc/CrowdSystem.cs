using TMPro;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
   [SerializeField] private float radius, angle;
   [SerializeField] private TextMeshProUGUI countText;

   private void Start()
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

   // prevent overlapping 
   private Vector3 ChildrenPosition(int index)
   {
      float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * angle * index);
      float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * angle * index);
      return new Vector3(x, 0, z);
   }


}

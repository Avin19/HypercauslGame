using TMPro;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
   [Header(" Elements ")]
   [SerializeField] private GameObject runnerPf;

   [Header(" Setting ")]
   [SerializeField] private float radius;
   [SerializeField] private float angle;
   [SerializeField] private TextMeshProUGUI countText;

   private void Start()
   {
      PlacementOfRunner();
   }
   public void PlacementOfRunner()
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
   public void ApplyBonus(int doorAmount, BouseType type)
   {
      switch (type)
      {
         case BouseType.Addition:
            Debug.Log("Add");
            AddRunners(doorAmount);
            break;
         case BouseType.Difference:
            RemoveRunner(doorAmount);
            break;
         case BouseType.Multiple:
            Debug.Log("Multiple");
            int runnerToAdd = (transform.childCount * doorAmount) - transform.childCount;
            AddRunners(runnerToAdd);
            break;
         case BouseType.Divided:
            int runnerToRemove = transform.childCount - (transform.childCount / doorAmount);
            RemoveRunner(runnerToRemove);
            break;
      }
      PlacementOfRunner();

   }

   private void RemoveRunner(int doorAmount)
   {
      if (doorAmount < transform.childCount)
      {
         // Can implement object pooling here 
         for (int i = 0; i < doorAmount; i++)
         {
            Transform runner = transform.GetChild(i);
            runner.SetParent(null);
            Destroy(runner.gameObject);
         }
      }
      else
      {

         GameManager.instance.SetGameState(GameState.GameOver);
      }
   }

   private void AddRunners(int doorAmount)
   {
      for (int i = 0; i < doorAmount; i++)
      {
         Transform player = Instantiate(runnerPf, transform).transform;



      }
   }
}


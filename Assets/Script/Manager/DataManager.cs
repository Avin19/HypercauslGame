using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private TextMeshProUGUI coinText;
    private int coin;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        coin = PlayerPrefs.GetInt("Coin", 0);
    }
    private void Start()
    {
        SetCoin(coin);
    }
    public int GetCoin()
    {
        return coin;
    }
    public void SetCoin(int _coin)
    {
        coinText.text = _coin.ToString();
    }



}

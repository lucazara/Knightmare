using UnityEngine;
using TMPro;

public class CoinLabel : MonoBehaviour
{
    public int coins;
    public string type;

    private void Start()
    {
        coins = PlayerPrefs.GetInt(type + " coins", 0);
        UpdateLabel();
    }

    public void GetCoin()
    {
        coins++;
        PlayerPrefs.SetInt(type + " coins", coins);
        UpdateLabel();
        GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
        GetComponent<AudioSource>().Play();
    }    

    private void UpdateLabel()
    {
        GetComponent<TextMeshProUGUI>().text = coins.ToString();
    }
}

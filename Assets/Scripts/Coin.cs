using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{ 
    public float rotationSpeed;
    public int x, y;
    public GameObject knight;
    public GameObject darkCoinLabel;
    public GameObject lightCoinLabel;
    public string type;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        if (x == knight.GetComponent<Knight>().x && y == knight.GetComponent<Knight>().y)
        {
            if (type == "dark")
                darkCoinLabel.GetComponent<CoinLabel>().GetCoin();
            if (type == "light")
                lightCoinLabel.GetComponent<CoinLabel>().GetCoin();

            Destroy(gameObject);
        }
    }
}

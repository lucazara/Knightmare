using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    public GameObject knight;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        score = Mathf.Max(score, knight.GetComponent<Knight>().y + 3);


        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}

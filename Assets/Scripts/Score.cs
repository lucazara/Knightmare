using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    int score;
    int highscore;

    public GameObject knight;

    public GameObject highscoreLabel;
    

    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("hs", 0);
        highscoreLabel.GetComponent<TextMeshProUGUI>().text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("hs", 0);
            highscore = 0;
            Debug.Log("C");
            SceneManager.LoadScene(0);
        }

        score = Mathf.Max(score, knight.GetComponent<Knight>().y + 3);


        GetComponent<TextMeshProUGUI>().text = score.ToString();
        highscore = Mathf.Max(highscore, score);
        PlayerPrefs.SetInt("hs", highscore);

        highscoreLabel.GetComponent<TextMeshProUGUI>().text = highscore.ToString();
    }
}

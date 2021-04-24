using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int score;
    public int pickaxeUses;

    public Text scoreText;
    public Text pickaxeText;

    bool addingScore;
    bool takingScore;

    void Start()
    {
        addingScore = false;
        takingScore = false;
    }

    void Update()
    {
        if (!addingScore && int.Parse(scoreText.text) < score)
            StartCoroutine("AddScore");
        if (!takingScore && int.Parse(scoreText.text) > score)
            StartCoroutine("TakeScore");
        pickaxeText.text = pickaxeUses.ToString();
    }

    public void TakeDamage(int value)
    {
        int newScore = score - value;
        if (newScore >= 0)
            score = newScore;
        else
            score = 0;
    }

    IEnumerator AddScore()
    {
        addingScore = true;
        float timeStep = 0.01f;
        while (int.Parse(scoreText.text) < score)
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            yield return new WaitForSeconds(timeStep);
        }
        addingScore = false;
    }

    IEnumerator TakeScore()
    {
        addingScore = true;
        float timeStep = 0.01f;
        while (int.Parse(scoreText.text) < score)
        {
            scoreText.text = (int.Parse(scoreText.text) - 1).ToString();
            yield return new WaitForSeconds(timeStep);
        }
        addingScore = false;
    }
}

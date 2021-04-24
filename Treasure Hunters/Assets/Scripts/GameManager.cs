using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int pickaxeUses;

    public Text scoreText;
    public Text pickaxeText;

    void Update()
    {
        scoreText.text = score.ToString();
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
}

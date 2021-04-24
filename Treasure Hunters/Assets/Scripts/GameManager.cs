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
}

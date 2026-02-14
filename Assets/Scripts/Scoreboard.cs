using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;

    private int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();
    }
}

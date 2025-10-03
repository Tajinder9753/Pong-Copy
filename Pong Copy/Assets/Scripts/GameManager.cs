using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1_score;
    [SerializeField] TextMeshProUGUI player2_score;
    int player1_score_count = 0;
    int player2_score_count = 0;
    [SerializeField] GameObject ball;

    public void UpdateScore(string player)
    {
        if (player.Equals("RightGoal"))
        {
            player1_score_count++;
            player1_score.text = player1_score_count.ToString();
        }

        if (player.Equals("LeftGoal"))
        {
            player2_score_count++;
            player2_score.text = player2_score_count.ToString();
        }

        Instantiate(ball, new Vector3(0,0,0), Quaternion.identity);
    }
}

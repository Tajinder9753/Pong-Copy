using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1_score;
    [SerializeField] TextMeshProUGUI player2_score;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

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

        player1.transform.position = new Vector2(-8.25f, -0.1f);
        player2.transform.position = new Vector2(8.25f, -0.1f);
        Instantiate(ball, new Vector3(0,0,0), Quaternion.identity);
    }
}

//using TMPro;
//using UnityEngine;

//public class ScoreManager : MonoBehaviour
//{
//    public static ScoreManager Instance;

//    public int player1Score { get; private set; }
//    public int player2Score { get; private set; }
//    public int maxScore = 100;
//    public int pointsPerHit = 10;
//    public int winBonus = 100; // New variable for winner bonus

//    [Header("Game Timer")]
//    public float gameDuration = 60f; // 1 minute game
//    private float gameStartTime;

//    [Header("Game Over UI")]
//    public GameObject gameOverPanel;
//    public TMP_Text WinnerScoreText; // Add this line



//    private void Awake()
//    {
//        if (Instance == null) Instance = this;
//        else Destroy(gameObject);
//    }

//    public void StartGame()
//    {
//        gameStartTime = Time.time;
//        ResetScores();
//    }

//    public void RegisterHit(int playerID)
//    {
//        if (playerID == 1 && player1Score < maxScore)
//        {
//            player1Score += pointsPerHit;
//            if (player1Score > maxScore) player1Score = maxScore;
//        }
//        else if (playerID == 2 && player2Score < maxScore)
//        {
//            player2Score += pointsPerHit;
//            if (player2Score > maxScore) player2Score = maxScore;
//        }
//    }

//    //public void ShowGameOver()
//    //{
//    //    gameOverPanel.SetActive(true);

//    //    if (player1FinalScoreText != null)
//    //        player1FinalScoreText.text = "P1 Final Score: " + player1Score + "/100";

//    //    if (player2FinalScoreText != null)
//    //        player2FinalScoreText.text = "P2 Final Score: " + player2Score + "/100";
//    //}

//    public void ShowGameOver()
//    {
//        gameOverPanel.SetActive(true);

//        // Debug: Check if the TMP component is assigned
//        if (WinnerScoreText == null)
//        {
//            Debug.LogError("WinnerScoreText is not assigned in Inspector!", this);
//            return;
//        }

//        // Debug: Force visible test message
//        WinnerScoreText.text = "DEBUG: Script is working!";
//        WinnerScoreText.color = Color.red;
//        WinnerScoreText.fontSize = 2;


//        //gameOverPanel.SetActive(true);

//        //// Debug check
//        //if (WinnerScoreText == null)
//        //{
//        //    Debug.LogError("WinnerText is not assigned in Inspector!", this);
//        //    return;
//        //}

//        //// Calculate bonus
//        //float timeRemaining = Mathf.Max(0, gameDuration - (Time.time - gameStartTime));
//        //int timeBonus = Mathf.FloorToInt(timeRemaining);
//        //int totalBonus = winBonus + timeBonus;

//        //// Determine winner and set text
//        //if (player1Score > player2Score)
//        //{
//        //    player1Score += totalBonus;
//        //    WinnerScoreText.text = $"PLAYER 1 WINS!\nScore: {player1Score}\nBonus: +{totalBonus}";
//        //}
//        //else if (player2Score > player1Score)
//        //{
//        //    player2Score += totalBonus;
//        //    WinnerScoreText.text = $"PLAYER 2 WINS!\nScore: {player2Score}\nBonus: +{totalBonus}";
//        //}
//        //else
//        //{
//        //    WinnerScoreText.text = "DRAW!";
//        //}

//    }

//    public void ResetScores()
//    {
//        player1Score = 0;
//        player2Score = 0;
//    }
//}



using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int player1Score { get; private set; }
    public int player2Score { get; private set; }
    public int maxScore = 100;
    public int pointsPerHit = 10;
    public int winBonus = 100;

    [Header("Game Timer")]
    public float gameDuration = 60f;
    private float gameStartTime;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TMP_Text WinnerScoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        gameStartTime = Time.time;
        ResetScores();
    }

    public void RegisterHit(int playerID)
    {
        if (playerID == 1)
        {
            player1Score = Mathf.Min(player1Score + pointsPerHit, maxScore);
        }
        else if (playerID == 2)
        {
            player2Score = Mathf.Min(player2Score + pointsPerHit, maxScore);
        }
    }

    public void ShowGameOver()
    {
        // 1. First enable the panel
        gameOverPanel.SetActive(true);

        // 2. Safety check
        if (WinnerScoreText == null)
        {
            Debug.LogError("WinnerScoreText is not assigned!", this);
            return;
        }

        // 3. Make absolutely sure the text is active and visible
        WinnerScoreText.gameObject.SetActive(true);
        WinnerScoreText.raycastTarget = false;

        // 4. Set test message (large and colorful)
        WinnerScoreText.text = "PLAYER 1 WINS! TEST";
        WinnerScoreText.color = Color.green;
        WinnerScoreText.fontSize = 48;
        WinnerScoreText.alignment = TextAlignmentOptions.Center;

        /* 5. Uncomment this after test works
        if (player1Score > player2Score)
        {
            WinnerScoreText.text = $"PLAYER 1 WINS!\nScore: {player1Score}";
            WinnerScoreText.color = Color.red;
        }
        else if (player2Score > player1Score)
        {
            WinnerScoreText.text = $"PLAYER 2 WINS!\nScore: {player2Score}";
            WinnerScoreText.color = Color.blue;
        }
        else
        {
            WinnerScoreText.text = "DRAW!";
            WinnerScoreText.color = Color.yellow;
        }
        */
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
    }
}
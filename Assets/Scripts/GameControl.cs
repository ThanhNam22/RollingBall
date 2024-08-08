using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button startButton;
    private UpdateCountDown countdownScript;
    private PlayerController playerController;
    private CollectibleController[] collectibleControllers;
    public GameOverScreen gameOverScreen;
    public bool gameEnd = false;
    void Start()
    {
        countdownScript = FindObjectOfType<UpdateCountDown>();
        playerController = FindObjectOfType<PlayerController>();
        collectibleControllers = FindObjectsOfType<CollectibleController>();

        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    void OnStartButtonClicked()
    {
        if (countdownScript != null)
        {
            countdownScript.StartCountdown();
        }
        if (playerController != null)
        {
            playerController.StartMoving();
        }
        foreach (var collectible in collectibleControllers)
        {
            collectible.StartRotating();
        }

        // Optionally, hide the start button after starting the game
        startButton.gameObject.SetActive(false);
    }

    public void GameOver(string message)
    {
        gameEnd = true;
        gameOverScreen.SetUp(countdownScript.countTime, message);
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

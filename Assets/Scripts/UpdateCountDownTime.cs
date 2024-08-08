using UnityEngine;
using TMPro;

public class UpdateCountDown : MonoBehaviour
{
    private TextMeshProUGUI collectibleText;
    public float timer = 30f;
    public float countTime = 0f;
    private bool gameEnded = false;
    private bool isStarted = false;
    public GameController gameController;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCountDown script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
    }

    void Update()
    {
        if (!isStarted || gameEnded)
            return;

        timer -= Time.deltaTime;
        countTime += Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            ShowGameOver();
            gameEnded = true;
        }

        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        if (gameController.gameEnd)
        {
            return;
        }
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        collectibleText.text = $"Time left: {minutes:00}:{seconds:00}";
    }

    public void CollectibleCollected()
    {
        if (gameEnded)
            return;

        timer += 5f;
    }

    public void StartCountdown()
    {
        isStarted = true;
        UpdateCollectibleDisplay(); // Initial update when countdown starts
    }
    public void ShowGameOver()
    {
        audioManager.PlaySFX(audioManager.loseClip);
        if (gameController != null)
        {
            gameController.GameOver("GAME OVER");
        }
    }
}

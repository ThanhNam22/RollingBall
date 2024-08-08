using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public GameObject onCollectEffect;
    private bool isStarted = false;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (!isStarted)
            return;

        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateCountDown updateCountDown = FindObjectOfType<UpdateCountDown>();
        if (updateCountDown != null)
        {
            updateCountDown.CollectibleCollected();
        }

        if (onCollectEffect != null)
        {
            Instantiate(onCollectEffect, transform.position, Quaternion.identity);
        }
        audioManager.PlaySFX(audioManager.coinClip);
        Destroy(gameObject);
    }

    public void StartRotating()
    {
        isStarted = true;
    }
}

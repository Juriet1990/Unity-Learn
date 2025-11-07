using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfCoins {  get; private set; }

    public UnityEvent<PlayerInventory> OnCoinCollected;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip coinSound;

    public void CoinCollected()
    {
        NumberOfCoins++;
        OnCoinCollected.Invoke(this);

        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }

}

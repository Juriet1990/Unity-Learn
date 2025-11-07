using UnityEngine;

public class AudioDelay : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float delayInSeconds = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.PlayScheduled(delayInSeconds);
        }
    }
}

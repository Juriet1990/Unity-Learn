using UnityEngine;
using System.Collections;

public class ThunderEffect : MonoBehaviour
{
    private Animation thunderAnimator;
    public string thunderAnimationName = "ThunderEffect";
    public Light thunderLight;
    public float minDelay = 5f;
    public float maxDelay = 15f;

    public int minFlickers = 2;
    public int maxFlickers = 4;
    public float minFlickerTime = 0.05f;
    public float maxFlickerTime = 0.2f;

    private void Start()
    {
        thunderLight.intensity = 0f;

        thunderAnimator = GetComponent<Animation>();

        StartCoroutine(ThunderRoutine());
    }

    private IEnumerator ThunderRoutine()
    {
        while (true)
        {
            float thunderTimer = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(thunderTimer);

            thunderAnimator.Play();

            int flickers = Random.Range(minFlickers, maxFlickers + 1);

            for (int i = 0; i < flickers; i++)
            {
                thunderLight.intensity = 20f;

                float onTime = Random.Range(minFlickerTime, maxFlickerTime);
                yield return new WaitForSeconds(onTime);

                thunderLight.intensity = 0f;

                float offTime = Random.Range(minFlickerTime, maxFlickerTime);
                yield return new WaitForSeconds(offTime);
            }

            thunderLight.intensity = 0f;
        }
    }
}
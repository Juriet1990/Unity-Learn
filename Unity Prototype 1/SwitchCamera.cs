using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;
    public KeyCode switchKey = KeyCode.C;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SwitchCameras();
        }
    }

    void SwitchCameras()
    {
        firstCamera.enabled = !firstCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
}

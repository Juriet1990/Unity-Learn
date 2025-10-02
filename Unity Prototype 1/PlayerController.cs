using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private var
    private float speed = 25f;
    private float turnSpeed = 60;
    private float horizontalInput;
    private float forwardInput;
    public string prefix = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player input
        horizontalInput = Input.GetAxis(prefix + "Horizontal");
        forwardInput = Input.GetAxis(prefix + "Vertical");

        //
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}

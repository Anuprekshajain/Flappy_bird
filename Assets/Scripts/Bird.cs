using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bird : MonoBehaviour {
    public Text winText;
    public float speed = 2;
    // Flap force
    public float force = 300;
    // Use this for initialization
    void Start () {
        winText.text = "";
        // Fly towards the right
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        // Flap
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);

        
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            // Exit condition for Desktop devices
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
            // Exit condition for mobile devices
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        if (transform.position.x >= 29)
        {
            winText.text = "You win the game!";
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Restart
        Application.LoadLevel(Application.loadedLevel);
    }
}

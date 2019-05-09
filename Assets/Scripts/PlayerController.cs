using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector3 initialPos;
    public float speed;
    public Text countText;
    //public Text livesText;
    public Text winText;
    public Text startingLivesText;
    public Text endText;
    public float _YOffset;
    public Transform player;

    private Rigidbody rb;
    private int count;
    private int startingLives;

    //bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        startingLives = 3;
        SetCountText();
        SetLivesText();
        gameOver();
        winText.text = "";
        endText.text = "";
        initialPos = player.transform.position;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (transform.position.y < -20f && startingLives == 1)
        {
            startingLives = startingLives - 1;
            transform.position = initialPos;
            SetLivesText();
            gameOver();
        }

        else if (transform.position.y < -20f)
        {
            startingLives = startingLives - 1;
            transform.position = initialPos;
            SetLivesText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 3)
        {
            winText.text = "You Win!";

        }
    }

    void SetLivesText()
    {
        startingLivesText.text = "Lives: " + startingLives.ToString();

    }

    void gameOver()
    {
        endText.text = "GAME OVER!!!";
    }



}

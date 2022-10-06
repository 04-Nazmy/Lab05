using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollision : MonoBehaviour
{
    public GameObject coinsCollected;
    private int coinCount=10;
    private float totalCoin;
    private float scoreValue = 60;
    private float timeleft;
    private int timeRemaining;
    public Text TimerText;
    private float TimerValue = 20;
    public ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        ParticleSystem part = GetComponent<ParticleSystem>();
        timeleft = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCoin == coinCount)
        {
            SceneManager.LoadScene("GameWin");
        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("GameLose");
        }

        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        TimerText.text = "00:00:00" + timeRemaining.ToString();

        if(scoreValue == totalCoin)
        {
           if(timeleft <= TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        else if(timeleft <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;
            coinsCollected.GetComponent<Text>().text = "Score:" + coinCount;
            part.Play();
            Destroy(other.gameObject);
        }
    }
}

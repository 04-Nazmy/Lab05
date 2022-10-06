using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollision : MonoBehaviour
{
    public GameObject coinsCollected;
    private int coinCount=10;
    private int totalCoin;
    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++;
            coinsCollected.GetComponent<Text>().text = "Score:" + coinCount;
            Destroy(other.gameObject);
        }
    }
}

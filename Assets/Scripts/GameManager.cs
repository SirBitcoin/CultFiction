using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject coconut;
    public GameObject stone;
    public GameObject bigStone;

    private int totalClicks;

    private Vector3 origin;

    private int clicks;

    public Text clickText;

    private float r, g, b, a;

    public GameObject explosion;

    public GameObject[] endGame;
    
    void Start()
    {
        origin = stone.transform.position;
        
    }

    void Update()
    {
        ClickChecker();
    }

    public void Hit()
    {
        totalClicks++;
        clicks++;
        StartCoroutine(ChangeText());
        StartCoroutine(MoveRock());
    }

    IEnumerator ChangeText()
    {
        clickText.text = clicks.ToString();
        for (int i = 0; i < 10; i++)
        {
            clickText.fontSize += 1;
            yield return new WaitForSeconds(0.02f);
            Debug.Log("kek");
            clickText.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 100);
        }

        for (int i = 0; i < 10; i++)
        {
            clickText.color = Color.white;
            clickText.fontSize -= 1;
        }
    }

    IEnumerator MoveRock()
    {
        float step = 100f * Time.deltaTime;
        bool a = true;
        while (a == true)
        {
            stone.transform.position = Vector3.MoveTowards(stone.transform.position, coconut.transform.position, step);
            if (stone.transform.position.x == coconut.transform.position.x)
            {
                stone.transform.position = origin;
                a = false;
                Debug.Log("donedino");
            }
            yield return null;
        }

        
    } 

    void ClickChecker()
    {
        if (clicks > 5)
        {
           Instantiate(explosion);
            StartCoroutine(EndGame());
            clicks = 0;

        }
    }

    IEnumerator EndGame()
    {
        bigStone.SetActive(false);
        clickText.text = string.Empty;
        Destroy(explosion);
        Debug.Log("awa");
        endGame[0].SetActive(true);
        yield return new WaitForSeconds(5f);
        endGame[0].SetActive(false);
        endGame[1].SetActive(true);
        yield return new WaitForSeconds(5f);
        endGame[1].SetActive(false);
        endGame[2].SetActive(true);
    }

}
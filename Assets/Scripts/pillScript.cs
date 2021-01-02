using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pillScript : MonoBehaviour
{
    Vector3 startPos;
    static int Blue, Red, Green = 0;
    static int score;
    static int counter=0;
    public GameObject bottles;
    public Text scoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("OverAllScore");
        scoreText.text = "Score: " + score;
    }
    void OnMouseDown()
    {
        startPos = this.transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(newpos.x, newpos.y, 0);
    }

    void OnMouseUp()
    {
       // this.transform.position = startPos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (this.tag=="Blue" && col.tag=="Blue")
        {
            Blue++;
            score += 5;
            if (Blue == 4)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
            if (Blue == 8)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
        }
      
        if (this.tag == "Red" && col.tag == "Red")
        {
            Red++;
            score += 5;
            if (Red == 4)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
            if (Red == 8)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
        }
   
       
        if (this.tag == "Green" && col.tag == "Green")
        {
            Green++;
            score += 5;
            if (Green == 4)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
            if (Green == 8)
            {
                col.transform.GetChild(1).gameObject.SetActive(true);
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                counter++;
            }
        }

        if (this.tag != col.tag )
        {
            score -= 3;
        }
      
        if (counter==3)
        {
            bottles.GetComponent<Animator>().Play("Move2");
        }
        if (counter==6)
        {
            PlayerPrefs.SetInt("OverAllScore", score);
            SceneManager.LoadScene(2);
            Debug.Log("Over");
        }

        scoreText.text = "Score: " + score;
        Debug.Log("Red: " + Red + " Green: " + Green + " Blue: " + Blue);
        Destroy(this.gameObject);
    }
}

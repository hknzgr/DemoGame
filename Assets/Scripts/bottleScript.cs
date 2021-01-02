using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class bottleScript : MonoBehaviour
{
    Vector3 startPos;
    public GameObject Red, Green, Blue;
    bool redControl, blueControl, greenControl = false;
    static int score;
    static int counter;
    public Text scoreText;
    public GameObject bottles;
    public GameObject finish;

    private void Start()
    {
        score = PlayerPrefs.GetInt("OverAllScore");
        scoreText.text = "Score: " + score;
    }
    void OnMouseDown()
    {
        startPos = this.transform.position;
        this.transform.localScale = new Vector3(13, 13, 13);
    }

    void OnMouseDrag()
    {
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(newpos.x, newpos.y, 0);
    }

    void OnMouseUp()
    {
        if (blueControl==true)
        {
            Blue.SetActive(true);
            score += 8;
            scoreText.text = "Score: " + score;
            counter++;
            Destroy(this.gameObject);
        }
        if (redControl == true)
        {
            Red.SetActive(true);
            score += 8;
            scoreText.text = "Score: " + score;
            counter++;
            Destroy(this.gameObject);
        }
        if (greenControl == true)
        {
            Green.SetActive(true);
            score += 8;
            scoreText.text = "Score: " + score;
            counter++;
            Destroy(this.gameObject);
        }

        score = score - 3;
        scoreText.text = "Score: " + score;
        this.transform.localScale = new Vector3(20, 20, 20);
        this.transform.position = startPos;

        if (counter==3)
        {
            bottles.GetComponent<Animator>().Play("Move2");
        }
        if (counter==6)
        {
            finish.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (this.tag== "Blue" && col.tag== "Blue")
        {
            blueControl = true;   
        }
        if (this.tag == "Red" && col.tag == "Red")
        {
            redControl = true;  
        }
        if (this.tag == "Green" && col.tag == "Green")
        {
            greenControl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (this.tag == "Blue" && col.tag == "Blue")
        {
            blueControl = false;
        }
        if (this.tag == "Red" && col.tag == "Red")
        {
            redControl = false;
        }
        if (this.tag == "Green" && col.tag == "Green")
        {
            greenControl = false;
        }
    }
}

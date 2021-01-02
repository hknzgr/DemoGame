using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class labelScript : MonoBehaviour
{
    Vector3 startPos;
    public GameObject bottles;
    public Text scoreText;
    static int score = 0;
    static int counter = 0;

    private void Update()
    {
        if (counter==3)
        {
            bottles.GetComponent<Animator>().Play("Move2");
        }
        if (counter==6)
        {
            PlayerPrefs.SetInt("OverAllScore", score);
            SceneManager.LoadScene(1);
        }
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
        this.transform.position = startPos; 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.GetChild(0).GetComponent<MeshRenderer>().material.color != col.transform.GetChild(1).GetComponent<MeshRenderer>().material.color)
        {
            if (this.tag == col.tag)
            {
                counter++;
                score += 5;
            }
            else
            {
                score -= 3;
            }
            col.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = this.GetComponent<MeshRenderer>().material.color;
            Debug.Log(counter);
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void PlayButton()
    {
        bottles.GetComponent<Animator>().enabled = true;
        bottles.GetComponent<Animator>().Play("Move");
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameDirector : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    GameObject timerText;
    GameObject pointText;
    int point = 0;
    float time = 60.0f;

    GameObject generator;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;

    }
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
         this.gameOverText.gameObject.SetActive(false);

    }

    void Update()
    {
        this.time -= Time.deltaTime;
        if(this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
            this.gameOverText.gameObject.SetActive(true);
        }
        else if(this.time >= 0 && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.05f, 7);
        }
        else if(this.time >= 5 && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.6f, -0.05f, 5);
        }

        else if(this.time >= 10 && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.04f, 4);
        }

        else if(this.time >= 20 && this.time < 40)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, -0.03f, 3);
        }
        else if(this.time >= 40 && this.time <= 60)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.02f, 2);
        }
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
    }
}

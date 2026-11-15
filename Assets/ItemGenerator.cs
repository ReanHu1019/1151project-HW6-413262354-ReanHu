using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    public GameObject ApplePrefab;
    public GameObject BombPrefab;
    float span = 1.0f;
    float delta = 0;

    int ratio = 2;

    float speed = -0.03f;
    //span間隔時間, speed掉落速度, ratio炸彈出現比例
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;

            int dice = Random.Range(1, 11);

            if(dice <= this.ratio)
            {
                item = Instantiate(BombPrefab);
            }
            else
            {
                item = Instantiate(ApplePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }


}

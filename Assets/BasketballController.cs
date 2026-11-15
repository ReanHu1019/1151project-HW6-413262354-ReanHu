using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasketballController : MonoBehaviour
{

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
            Debug.Log("Tag=Apple");
        }

        else
        {
            this.aud.PlayOneShot(this.bombSE, 0.2f);
            this.director.GetComponent<GameDirector>().GetBomb();
            Debug.Log("Tag=Bomb");
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}

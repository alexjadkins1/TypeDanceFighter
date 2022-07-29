using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{

    public float speed;
    private SpriteRenderer sp;
    private float offset;

    void Start()
    {
        offset = GameObject.FindGameObjectWithTag("gm").GetComponent<GameController>().getOffset();
        speed = Random.Range(.2f,.4f+offset);
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Kill")
        {
            GameObject.FindGameObjectWithTag("gm").GetComponent<GameController>().remove(gameObject);
            Destroy(gameObject);
        }

    }

}

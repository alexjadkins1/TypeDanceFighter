using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{

    public GameObject key;
    private GameObject baby;
    private GameObject gc;

    public bool canSpawn;
    private bool isBabyAlive;

    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        isBabyAlive = false;
        gc = GameObject.FindGameObjectWithTag("gm");
    }

    // Update is called once per frame
    void Update()
    {

        if (baby == null)
            isBabyAlive = false;

        if (canSpawn && !isBabyAlive)
        {

            canSpawn = false;
            StartCoroutine("WaitSpawn");
        }
        
    }

    IEnumerator WaitSpawn()
    {

        waitTime = Random.Range(2f, 10f);
        yield return new WaitForSeconds(waitTime);
        if (gc.GetComponent<GameController>().canSpawn)
        {
            baby = Instantiate(key, transform.position, Quaternion.identity);
            baby.transform.localScale = new Vector3(0.15f, 0.15f, 1f);
            isBabyAlive = true;
            gc.GetComponent<GameController>().add(baby);
        }
        canSpawn = true;

    }
}

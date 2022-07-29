using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEnter : MonoBehaviour
{

    [SerializeField] private GameObject Good;
    [SerializeField] private GameObject Okay;
    [SerializeField] private GameObject Bad;
    
    public string key;
    public GameObject toExamine;
    private GameObject gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("gm");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(key))
        {

            toExamine = GameObject.FindGameObjectWithTag(key);
            if(toExamine == null || Vector2.Distance(transform.position, toExamine.transform.position) >= .75f)
            {
                Bad.SetActive(true);
                StartCoroutine("BadHit");
                gc.GetComponent<GameController>().comboCtr = 0;
            }

            else if(Vector2.Distance(transform.position, toExamine.transform.position) >= .1f)
            {
                Okay.SetActive(true);
                StartCoroutine("OkayHit");
                gc.GetComponent<GameController>().addScore(100);
               
            }

            else
            {
                Good.SetActive(true);
                StartCoroutine("GoodHit");
                gc.GetComponent<GameController>().addScore(200);
                gc.GetComponent<GameController>().comboCtr += 1;
            }

            gc.GetComponent<GameController>().remove(toExamine);
            Destroy(toExamine);

        }

    }

    IEnumerator GoodHit()
    {

        yield return new WaitForSeconds(.5f);
        Good.SetActive(false);
    }

    IEnumerator OkayHit()
    {
        yield return new WaitForSeconds(.5f);
        Okay.SetActive(false);
    }

    IEnumerator BadHit()
    {
        yield return new WaitForSeconds(.5f);
        Bad.SetActive(false);
    }
}

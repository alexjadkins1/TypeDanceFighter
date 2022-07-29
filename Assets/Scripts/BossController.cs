using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private Animator an;
    public int anim;
    public bool wait;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        anim = 0;
        wait = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (wait)
        {
            an.SetInteger("Anim", anim);
            wait = false;
            StartCoroutine("newAnim");
        }

    }

    IEnumerator newAnim()
    {

        anim = Random.Range(0, 7);
        yield return new WaitForSeconds(10f);
        wait = true;
    }
}

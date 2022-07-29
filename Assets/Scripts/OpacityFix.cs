using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityFix : MonoBehaviour
{

    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {

        sp = GetComponent<SpriteRenderer>();
        sp.color = new Color(1f, 1f, 1f, .5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

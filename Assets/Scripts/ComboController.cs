using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{

    private TMPro.TextMeshProUGUI combo;
    private TMPro.TextMeshProUGUI numFill;
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        combo = GetComponent<TMPro.TextMeshProUGUI>();
        numFill = GameObject.FindGameObjectWithTag("numFill").GetComponent<TMPro.TextMeshProUGUI>();
        gc = GameObject.FindGameObjectWithTag("gm").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        combo.text = "COMBO: " + gc.comboCtr;
        numFill.text = "" + gc.comboCtr;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> doesExist;
    public bool canSpawn;
    
   [SerializeField] private int keyCount;
    private int keyMax;
    private float Timer;
    private bool isTimer;
    private float offset;
    private int score;
    private GameObject sc;
    public int comboCtr;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        doesExist = new List<GameObject>();
        keyCount = 2;
        keyMax = 9;
        Timer = 30f;
        isTimer = false;
        offset = 0.0f;
        score = 0;
        sc = GameObject.Find("Score");
        comboCtr = 100;
    }

    // Update is called once per frame
    void Update()
    {

        sc.GetComponent<Text>().text = "Score: " + score;
        if (doesExist.Count >= keyCount)
            canSpawn = false;
        else
            canSpawn = true;

        if (!isTimer)
        {
            isTimer = true;
            StartCoroutine("countTimer");
        }
    }

    public void add(GameObject toAdd)
    {
        if(canSpawn)
            doesExist.Add(toAdd);
    }
    public void remove(GameObject toRemove)
    {
        doesExist.Remove(toRemove);
    }

    public void addScore(int toAdd)
    {
        score += toAdd;
    }
    public float getOffset()
    {
        return offset;
    }

    public float getCombo()
    {
        return comboCtr;
    }

    IEnumerator countTimer()
    {
        
        yield return new WaitForSeconds(Timer);
       
        if(keyCount < keyMax)
            keyCount += 1;
        isTimer = false;
        offset += .02f;

    }
}

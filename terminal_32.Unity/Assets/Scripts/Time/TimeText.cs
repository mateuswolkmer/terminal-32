using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    private Text text;
    private float time;
    private Text plus1;
    private Global G;

    void Start ()
    {
        text = GetComponent<Text>();
        G = GameObject.Find("Global").GetComponent<Global>();

        plus1 = GameObject.Find("+").GetComponent<Text>();
        plus1.text = "";
    }
	
	void Update ()
    {
        time = GameObject.Find("Global").GetComponent<Global>().time;

        if (time <= 9.99f)
            text.text = "TIME  " + time.ToString("F2");
        else
            text.text = "TIME " + time.ToString("F2");
    }

    public IEnumerator BatteryPickup()
    {
        if (G.GetDifficulty() == "easy")
            plus1.text = "+2";
        else if (G.GetDifficulty() == "hard")
            plus1.text = "+1";
        
        yield return new WaitForSeconds(2f);
        plus1.text = "";
    }
}

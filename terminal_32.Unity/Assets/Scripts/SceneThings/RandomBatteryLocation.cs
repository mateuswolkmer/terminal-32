using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBatteryLocation : MonoBehaviour 
{
	GameObject[] grounds;
    GameObject[] otherBatteries;
    
    void Start ()
    {
        bool found;
        do
        {
            found = false;
            grounds = GameObject.FindGameObjectsWithTag("Ground");
            this.transform.position = grounds[Random.Range(0, grounds.Length)].transform.position;

            otherBatteries = GameObject.FindGameObjectsWithTag("Battery");
            for (int i = 0; i < otherBatteries.Length; i++)
            {
                if (otherBatteries[i].name == this.name)
                    i++;
                else if (this.transform.position == otherBatteries[i].transform.position){
                    found = true;
                    break;
                }
            }
        } while (found);
    }
}

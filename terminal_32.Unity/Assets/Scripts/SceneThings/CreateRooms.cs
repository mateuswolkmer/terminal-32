using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRooms : MonoBehaviour 
{
	string[] usedRooms = new string[6];
	Vector3[] position = new Vector3[6];

	void Awake () 
	{
		position[1] = new Vector3(0, 0, 0);
		position[2] = new Vector3(0, 252, 0);
		position[3] = new Vector3(0, 504, 0);
		position[4] = new Vector3(0, 756, 0);
		position[5] = new Vector3(0, 1008, 0);

		for (int a = 1; a <= 5; a++) {
			string roomName = string.Concat("RRoom", Random.Range (1, 18));

			bool used = false;
			for (int b = 1; b <= a; b++) {
				if (roomName == usedRooms [b])
					used = true;			
			}
			if (used)
				a--;
			else {
				usedRooms [a] = roomName;
				Instantiate (Resources.Load (roomName), position [a], Quaternion.Euler (0, 0, 0));
			}
		}		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;
	public GameObject coinPrefab;
	public GameObject conePrefab;

	private GameObject unityChan;

	private int startPos = -150;
	private int goalPos = 120;
	private float posRange = 3.4f;

	private List<Vector3> coinList = new List<Vector3>();
	private int coinNum;

	private List<Vector3> coneList = new List<Vector3>();
	private int coneNum;

	private List<Vector3> carList = new List<Vector3>();
	private int carNum;

	//private int objNum = 0;

	// Use this for initialization
	void Start () {

		coinNum = 0;
		carNum = 0;
		coneNum = 0;

		unityChan = GameObject.Find ("unitychan");


		for (int i = startPos; i < goalPos; i += 15) {
			int num = Random.Range (1, 11);

			if (num <= 2) {
				for (float j = -1; j <= 1; j += 0.4f) {
					Vector3 conePos = new Vector3 (4 * j, conePrefab.transform.position.y, i);
					coneList.Add (conePos);
					//GameObject cone = Instantiate (conePrefab) as GameObject;
					//cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {

				for(int j = -1; j <= 1; j++){
					
					int item = Random.Range (1, 11);
					int offsetZ = Random.Range (-5, 6);
					if(1 <= item && item <= 6){
						Vector3 coinPos = new Vector3 (posRange * j, coinPrefab.transform.position.y, i + offsetZ);
						coinList.Add (coinPos);
						//GameObject coin = Instantiate (coinPrefab) as GameObject;
						//coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					}else if(item >= 7 && item <= 9){
						Vector3 carPos = new Vector3 (posRange * j, carPrefab.transform.position.y, i + offsetZ);
						carList.Add (carPos);
						//GameObject car = Instantiate (carPrefab) as GameObject;
						//car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}

		} 
	}
	
	// Update is called once per frame
	void Update () {
		GenerateCoin ();
		GenerateCar ();
		GenerateCone ();
	}


	void GenerateCoin(){
		if(coinNum < coinList.Count){
			if(coinList[coinNum].z < unityChan.transform.position.z + 40f){
				GameObject coin = Instantiate (coinPrefab) as GameObject;
				coin.transform.position = coinList [coinNum];
			
				coinNum += 1;
			}
		}
	}

	void GenerateCar(){
		if(carNum < carList.Count){
			if(carList[carNum].z < unityChan.transform.position.z + 40f){
				GameObject car = Instantiate (carPrefab) as GameObject;
				car.transform.position = carList [carNum];
			
				carNum += 1;
			}

		}
	}

	void GenerateCone(){
		if(coneNum < coneList.Count){
			if(coneList[coneNum].z < unityChan.transform.position.z + 40f){
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = coneList [coneNum];

				coneNum += 1;
			}

		}
	}
}

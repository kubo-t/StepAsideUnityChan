using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

	private GameObject unityChan;

	// Use this for initialization
	void Start () {
		unityChan = GameObject.Find ("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, unityChan.transform.position.z - 5f);
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("ffffffffff");
		if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag"){
			Destroy (other.gameObject);
		}

	}
}

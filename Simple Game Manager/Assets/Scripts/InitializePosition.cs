using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePosition : MonoBehaviour {
    
	private void OnTriggerEnter(Collider Hit){
		if(Hit.tag=="Edge"){
        this.transform.position = GameObject.Find("initialPos").transform.position;
		this.transform.rotation = Quaternion.Euler(GameObject.Find("initialPos").transform.rotation.eulerAngles);
		}
	}
}

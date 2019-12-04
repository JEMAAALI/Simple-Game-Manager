using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

	public GameObject[] m_controllers;
	public GameObject[] m_Instantiatedcontrollers;
	public Vector3 m_currentPos;
	public Vector3 m_currentRot;
	public Vector3[] m_lastPos;
	public Vector3[] m_lastRot;
	public GameObject m_pos;
	public int[] m_instantiated_State;
	public int i=-1;
	public int x=0;
    public bool allControllersInstantiated;
    public bool _m_btnClick;
	public  Vector3 m_cameraPos;
    public  Vector3 m_cameraRot;
	public GameObject _UIButtonText;

  	void Start () {
		m_cameraPos = GameObject.Find("Main Camera").transform.position;
		m_cameraRot = GameObject.Find("Main Camera").transform.rotation.eulerAngles;
	}
	
 	void Update () {
		 if(i>=0 && m_Instantiatedcontrollers[i].gameObject.activeInHierarchy==true)
		 {
			m_currentPos =  m_Instantiatedcontrollers[i].transform.position;
			m_currentRot =  m_Instantiatedcontrollers[i].transform.rotation.eulerAngles;
		 }
		 if(_m_btnClick == false && Input.GetButtonDown("Fire1")){
			switchControllers();
	  	 }
 
		

		 
	}

    

	public void switchControllers(){
	    i=i+1;
		x=x+1;
		if(x>=m_controllers.Length)
		{
			x=0;
		}
        if(i>=m_controllers.Length)
		{
			i=0;
			allControllersInstantiated=true; 
		}
		
		if(allControllersInstantiated==false)
		{ 
		if(i<m_controllers.Length)
		{ 
			for(int j=0;j<m_controllers.Length;j++)
	    	{
             if(j!=i && m_Instantiatedcontrollers[j]!=null)
		     {
			  m_Instantiatedcontrollers[j].gameObject.SetActive(false);
			  m_lastPos[j]=m_currentPos;
			  m_lastRot[j]=m_currentRot;
		     }
		    }
			
			if(m_instantiated_State[i]==0){
				m_Instantiatedcontrollers[i]= Instantiate(m_controllers[i].gameObject, m_pos.transform.position, Quaternion.identity);
				m_instantiated_State[i]=1;
						_UIButtonText.GetComponent<Text>().text=""+m_controllers[x].gameObject.name;

			}
		
		}
		}
		else
		 
		{
			for(int k=0;k<m_controllers.Length;k++)
	    	{
             if(k==i)
		     {
			  m_Instantiatedcontrollers[k].gameObject.SetActive(true);
			  m_currentPos=m_lastPos[k];
			  m_currentRot=m_lastRot[k];
			  initialiseCamera();
			  		_UIButtonText.GetComponent<Text>().text=""+m_controllers[x].gameObject.name;


			  
 		     }
			 else
			 {
				m_Instantiatedcontrollers[k].gameObject.SetActive(false);
				m_lastPos[k]=m_currentPos;
			    m_lastRot[k]=m_currentRot; 
				initialiseCamera();
						_UIButtonText.GetComponent<Text>().text=""+m_controllers[x].gameObject.name;

 			 }
		    }

		} 


	}


	public void Fire1_On(){
		_m_btnClick=true;
	}

	public void Fire1_Off(){
		_m_btnClick=false;
	}

	private void initialiseCamera(){
		GameObject.Find("Main Camera").transform.position=m_cameraPos;
		GameObject.Find("Main Camera").transform.rotation= Quaternion.Euler(m_cameraRot);
	}

	
		 
	 
}

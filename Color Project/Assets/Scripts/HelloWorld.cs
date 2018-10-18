using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

	GameObject enemy;
	public string var;

	/*
	GameObject.Find();
	GetComponent<SomeComponent>();
	*/

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find("Goblin");
		Debug.Log("hmmmm");
	}

	private void Awake()
	{
		Debug.Log(var);
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log("Hi!");
	}
}

using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerNew : MonoBehaviour {

	private float playerMoney = 1000000;
	private int playerColor;
	private Dictionary<string,int> playerItems = new Dictionary<string,int>();
	private List<string> friendList = new List<string>();
	private Renderer renderer;
	private float playerHeight;
	public Material[] materials;
	public Text moneyText;
	public Text ItemText;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		moneyText.text = "Money: " + playerMoney;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			setColor (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			setColor (2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			setColor (3);
		}
		moneyText.text = "Money: " + playerMoney;
	}

	public void changeItem(string itemName, int itemNumber, bool sell, float transMoney){
		if (!sell){
			if (playerMoney - transMoney >= 0)
			if (playerItems.ContainsKey(itemName)){
				playerItems[itemName] += itemNumber;
				playerMoney -= transMoney;
			}
			else{
				playerItems[itemName] = itemNumber;
				playerMoney -= transMoney;
			}
			else {
				Debug.LogError("not enough money");
			}

		}
		else{
			if (playerItems.ContainsKey(itemName)){
				if (playerItems[itemName] < itemNumber){
					Debug.LogError("not enough items to sell");
				}
				else{
					playerItems[itemName] -= itemNumber;
					playerMoney += transMoney;
				}
			}
			else{
				Debug.LogError("no such item");
			}
			if (playerItems[itemName]==0){
				playerItems.Remove(itemName);
			}
		}
	}
	public int getItemNumber(string itemName){
		return playerItems[itemName];
	}
	public int getColor(){
		return playerColor;
	}

	public void setColor(int num) {
		playerColor = num;

		renderer.material = materials [num - 1];

	}
	public void setHieght(float height){
		playerHeight = height;
	}
	public float getHight(){
		return playerHeight;
	}

}

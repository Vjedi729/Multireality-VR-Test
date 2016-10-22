using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	private float playerMoney = 0;
	private string playerColor;
	private Dictionary<string,int> playerItems = new Dictionary<string,int>();
	private List<string> friendList = new List<string>();

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
	public string getColor(){
		return playerColor;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

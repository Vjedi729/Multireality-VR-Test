using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

class player
{
	private float playerMoney = 0;
	private string playerColor;
	private Dictionary<string,int> playerItems = new Dictionary<string,int>();
	private List<string> friendList = new List<string>();


	public player(string colorIn){
		playerColor = colorIn;
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
	public int getNumber(string itemName){
		return playerItems[itemName];
	}
	public string getColor(){
		return playerColor;
	}


}
class Test{
	static void Main(){
		player player1 = new player("red");
		player1.changeItem("aaaaa",12, false, 100);
		player1.changeItem("aaaaa",-11, true, 200);
		Console.Write(player1.getNumber("aaaaa"));
	}
}

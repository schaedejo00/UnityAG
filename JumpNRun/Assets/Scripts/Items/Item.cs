using UnityEngine;
using System.Collections;

public interface Item {

	void use (); // Use should be called whenever the player uses a certain key

	void onEquip (); // OnEquip should be called whenever the player takes up the item
	// And the player class calls "EquipItem" of the eventhandler
}

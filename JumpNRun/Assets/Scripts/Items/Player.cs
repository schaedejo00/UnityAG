using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float itemEquipRadius;
	//public ItemEventHandler itemHandler;
	public Item equipped;

	void Update(){
		if(Input.GetKey(KeyCode.F)){
			Collider[] nearbyObjects = Physics.OverlapSphere (this.transform.position, itemEquipRadius);
			for (int i = 0; i < nearbyObjects.Length; i++) {
				Item item = nearbyObjects [i].GetComponent<Item> ();
				if(item != null){
					item.onEquip ();
				}
			}
		}

		//sinnloser Kommentar

		if (Input.GetKey (KeyCode.E)) {
			if (equipped != null) {
				equipped.use ();
			}
		}
	}
}

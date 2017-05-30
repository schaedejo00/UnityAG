using UnityEngine;
using System.Collections;

public class EndMapDetector : MonoBehaviour {

	void OnColission (Collider col) {
		if (col.tag  == ("OutMap")) {
			Debug.LogWarning ("Test");
		}
	}
}


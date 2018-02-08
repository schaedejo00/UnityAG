

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour {
	// An private vor ändern mich bitte fragen
	private int health;
    private Renderer[] renderers;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public Renderer[] Renderers
    {
        get
        {
            return renderers;
        }

        set
        {
            renderers = value;
        }
    }

    public delegate void Death ();
	public event Death onDeath;

	void Update () {
		if (Health <= 0) {
			Debug.Log ("Dead");
			onDeath ();
		}
	}

}
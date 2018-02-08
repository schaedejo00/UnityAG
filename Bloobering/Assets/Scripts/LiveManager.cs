

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour {
	// An private vor ändern mich bitte fragen
	private int health;
    public int startHealth=100;
    public delegate void Death();
    public event Death onDeath;

    private Renderer[] renderers;
    void Start()
    {
        Health = startHealth;
    }
    //Update Methode sinnloss Property Effektiver
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            if (Health <= 0)
            {
                Debug.Log("Dead");
                onDeath();
            }
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

    

}
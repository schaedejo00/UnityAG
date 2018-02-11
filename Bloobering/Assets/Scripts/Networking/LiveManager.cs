

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkLiveManager :NetworkBehaviour {
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
	public void takeDamage(int damage)
	{
		if (damage < 0)
		{
			return;
		}
		Health = Health - damage;
	}

    

}
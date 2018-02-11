

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkLiveManager :NetworkBehaviour {
	// An private vor ändern mich bitte fragen
	[SyncVar]
	private int health;
    public int startHealth=100;
    public delegate void Death();
    public event Death onDeath;

    void Start()
    {
        Health = startHealth;
    }
    
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
                Debug.LogError("Dead");
                onDeath();
            }
        }
    }

	public void takeDamage(int damage)
	{
		if (!isServer)
		{
			return;
		}
		if (damage < 0)
		{
			return;
		}
		Health = Health - damage;
	}

    

}
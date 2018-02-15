

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.Networking;

public class NetworkLiveManager :NetworkBehaviour {
	// An private vor ändern mich bitte fragen
	[SyncVar(hook = "OnChangeHealth")]
	private int health;
	public RectTransform healthBar;
	public Text text;
	public int startHealth=100;
    public delegate void Death();
    public event Death onDeath;

    void Start()
    {
        Health = startHealth;
		OnChangeHealth(health);
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
			healthBar.sizeDelta = new Vector2(health,healthBar.sizeDelta.y);
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

	void OnChangeHealth(int health)
	{
		healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
		text.text = health.ToString();
	}

}
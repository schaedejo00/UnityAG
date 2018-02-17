using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkPlayerMovement : NetworkBehaviour {

	
	[System.Serializable]
	public struct KeyManager
	{
		public KeyCode forward;
		public KeyCode left;
		public KeyCode back;
		public KeyCode right;
		public KeyCode dashKey;
		public KeyCode brakekey;
		public KeyCode fly;
		public KeyCode reset;
	}
	public GameObject Camera;
	public GameObject barrel;
	public GameObject scope;
	public GameObject particleSystemBlob;
	
	public float maxSpeed = 5;
	public float defaultSpeed = 400f;
	public float rotationSpeed = 50;
	public float dashMax = 150;
	public float dashTime = 10;
	public float dashSpeed = 5;
	public float brake = 0.05f;
	
	public float brakeStop = 0.2f;
	public float RotationSpeedy = 5;
	[SyncVar]
	private bool colorCreated=false;
	[SyncVar]
	public float red, green, blue;
	//public AudioSource motorSoundSource;
	//public AudioClip engineDriving;
	//public AudioClip engineIdle;

	private bool activeSpecialKeys = false;
	private float speed = 2.5f;
	private NetworkLiveManager liveManager;
	public bool randomColor;
	private MeshRenderer meshRenderer;
	[SyncVar]
	private bool isAlive=true;
	private Vector3 startPosition;
	private float gravityon = 1;
	private Rigidbody rb;
	//public GameObject text;
	private float rotation;
	private float dashon = 0;
	private float dashcount = 0;
	private float yrot;
	public KeyManager keySettings = new KeyManager();
	private GameObject cam;
	private Color playerColor;
    public GameObject gameOverCanvas;
    private GameObject gameOverPanel;
    private Text gameOverText;

    public Color PlayerColor
	{
		get
		{
			return playerColor;
		}

		set
		{
			playerColor = value;
		}
	}

	public bool IsAlive
	{
		get
		{
			return isAlive;
		}

		set
		{
			//isAlive = value;
		}
	}

	void Start () {
        gameOverPanel = Instantiate(gameOverCanvas).transform.GetChild(0).gameObject;
        gameOverPanel.SetActive(false);
        gameOverText = gameOverPanel.GetComponentInChildren<Text>();
		meshRenderer = GetComponentInChildren<MeshRenderer>();

		if (meshRenderer != null && randomColor)
		{
			
			if (colorCreated)
			{
				PlayerColor = new Color(red, green, blue);
			}
			else
			{
				red = Random.Range(0F, 1F);
				green = Random.Range(0F, 1F);
				blue = Random.Range(0F, 1F);
				PlayerColor = new Color(red, green, blue);
				colorCreated = true;
			}
			meshRenderer.material.color = PlayerColor;
			barrel.GetComponent<MeshRenderer>().material.color = PlayerColor;
			particleSystemBlob.GetComponent<ParticleSystemRenderer>().material.color = PlayerColor;
			var col = scope.GetComponent<ParticleSystem>().colorOverLifetime;
			Gradient gradient = new Gradient();
			gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(PlayerColor,0.0F), new GradientColorKey(Color.white, 1.0F) },new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) } );
			col.color = gradient;
		}
		if (isLocalPlayer)
		{
            gameOverPanel.SetActive(false);
            cam = Instantiate(Camera);
			cam.GetComponent<Follower>().target = this.transform;
			//Debug.LogWarning(gameObject.GetComponent<NetworkIdentity>().netId);
			//GameObject.FindGameObjectWithTag("StartCamera").SetActive(false);
		}
		scope.SetActive(isLocalPlayer);
		Cursor.visible = false;
		activeSpecialKeys = false;
		Cursor.lockState = CursorLockMode.Locked;
		speed = defaultSpeed;
		rb = GetComponent<Rigidbody> ();
		startPosition = transform.position;
		liveManager = GetComponent<NetworkLiveManager> ();
		liveManager.onDeath += die;
	}

	void die(){
		Cursor.lockState = CursorLockMode.None;
        //GameObject.FindGameObjectWithTag("StartCamera").SetActive(true);
        //Destroy(cam);
        if (isLocalPlayer)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Game Over. Press R for Respawn";
        }
		isAlive = false;
	}
    void die(string killer)
    {
        isAlive = false;
        Debug.Log(killer);
    }

    void Update () {
		if (!isLocalPlayer) {
			return;
		}
		
		
		//Debug.Log(transform.eulerAngles);
		//Physics.gravity = new Vector3(0, -20.0F, 0);
		if (isAlive) {
            fadeControll();
            movementControls ();
			if (Input.GetKey (KeyCode.Alpha2) && Input.GetKey (KeyCode.Alpha3) && Input.GetKeyDown (KeyCode.Alpha7)) {
				activeSpecialKeys = !activeSpecialKeys;
				Debug.Log (activeSpecialKeys);
			}
			if (Input.GetKey (keySettings.reset)) {
				resetPlayer ();
			}
			//if (rb.velocity.magnitude > 0) {
				//motorSoundSource.clip = engineDriving;
			//} else {
				//motorSoundSource.clip = engineIdle;
			//}
			//if (!motorSoundSource.isPlaying) {
				//motorSoundSource.Play () ;
			//}
			specialControls ();
            //if (isAir == true && Time.time > timer) {
            //rb.AddForce (new Vector3 (0, gravity * -jumpspeed, 0));
            //	print ("truejump is true");
            //	timer = Time.time + cooldown;

        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                respawn();
            }
        }
		}

    private void respawn()
    {
        liveManager.Health = liveManager.startHealth;
        isAlive = true;
        gameOverPanel.SetActive(false);
    }

    private void dash(){
		if (Input.GetKey (keySettings.dashKey) && dashcount < dashMax) {
			dashcount = dashcount + 1;
		}
		if (Input.GetKeyUp (keySettings.dashKey)) {
			dashon = dashTime;
			speed = 1000 + dashSpeed * dashcount;
			rotationSpeed = 50 + 0.1f * dashSpeed * dashcount;
			Debug.Log (speed);
		}
	}

	private void specialControls(){
		if (activeSpecialKeys) {
			if (Input.GetKeyDown (keySettings.fly)) {
				if (gravityon == 1) {
					gravityon = 0;
					rb.useGravity = false;
					rb.velocity = Vector3.zero;
				} else if (gravityon == 0) {
					gravityon = 1;
					rb.useGravity = true;
				}
			}	

			if (Input.GetKey (keySettings.brakekey)) {
				if (rb.velocity.magnitude > brakeStop) {
					rb.velocity = rb.velocity * (1 - brake);
				} else {
					rb.velocity = Vector3.zero;
				}
			}
			dash ();
		}
		if (dashon <= 0) {
			limitVelocity ();
			rotationSpeed = 50;
			speed = defaultSpeed;
		} else {
			dashon--;
			dashcount = 0;
		}
	}

	private void limitVelocity(){
		if (rb.velocity.magnitude >= maxSpeed) {
			Vector3 highSpeed = rb.velocity.normalized * maxSpeed;
			highSpeed.y = rb.velocity.y;
			rb.velocity = highSpeed;
		}
	}

	private void resetPlayer(){
		transform.position = startPosition;
		transform.rotation = Quaternion.Euler (Vector3.zero);
		speed = defaultSpeed;
	}

	private void movementControls(){
		if (Input.GetKey (keySettings.forward)) {
			rb.AddForce (transform.forward.normalized * speed);
		}
		if (Input.GetKey (keySettings.back)) {
			rb.AddForce (transform.forward.normalized * -speed);
		}
		if (Input.GetKey (keySettings.left)) {
			rb.AddForce (transform.right.normalized * -speed);
		}
		if (Input.GetKey (keySettings.right)) {
			rb.AddForce (transform.right.normalized * speed);
		}
        if (Input.GetKey(KeyCode.Comma))
        {
            liveManager.Health = 0;
        }
    }
	private void fadeControll()
	{
		yrot = (Input.GetAxis("Mouse X") * RotationSpeedy * Time.deltaTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + yrot, transform.eulerAngles.z);
		
	}
}
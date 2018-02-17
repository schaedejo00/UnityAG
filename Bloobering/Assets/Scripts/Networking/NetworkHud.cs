using UnityEngine;
using UnityEngine.Networking;

public class NetworkHud: MonoBehaviour
{
    public string IpAddress="localhost";
    public string Port="2006";
    public float GuiOffset;
    private bool _started=false;
    private KeyCode hostmodeKey = KeyCode.H;
    private KeyCode clientmodeKey = KeyCode.C;
    private KeyCode disconnectKey = KeyCode.X;
    public GameObject startCamera;

    public void OnGUI()
    {
        GUILayout.Space(GuiOffset);
        if (!_started)
        {
            if (GUILayout.Button("Host (H)"))
            {
                hostMode();
            }

            GUILayout.Space(25);
            IpAddress = GUILayout.TextField(IpAddress, GUILayout.Width(100));
            Port = GUILayout.TextField(Port, 5);
            if (GUILayout.Button("Connect (C)"))
            {
                clientMode();
            }
        }
        else
        {
            if (GUILayout.Button("Disconnect (X)"))
            {
                disconnect();
            }
        }
    }

    private void clientMode()
    {
        _started = true;
        NetworkManager.singleton.networkAddress = IpAddress;
        NetworkManager.singleton.networkPort = int.Parse(Port);
        NetworkManager.singleton.StartClient();
        startCamera.SetActive(false);
    }

    private void Update()
    {
        if (_started)
        {
            if (Input.GetKey(disconnectKey))
            {
                disconnect();
            }
        }
        else
        {
            if (Input.GetKey(hostmodeKey))
            {
                hostMode();
            }
            if (Input.GetKey(clientmodeKey))
            {
                clientMode();
            }
        }
        
       
    }
    private void hostMode()
    {
        _started = true;
        
        NetworkManager.singleton.networkPort = int.Parse(Port);
        NetworkManager.singleton.StartHost();
        startCamera.SetActive(false);

    }
    private void disconnect()
    {
        _started = false;
        startCamera.SetActive(true);
        NetworkManager.singleton.StopHost();
    }
}

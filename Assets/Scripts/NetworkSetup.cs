using UnityEngine;
using Mirror;

public class NetworkSetup : NetworkBehaviour
{
    public GameObject chatUIPrefab;

    public override void OnStartLocalPlayer()
    {
        GameObject ui = Instantiate(chatUIPrefab);
        ChatManager.Instance = ui.GetComponent<ChatManager>();
    }
}
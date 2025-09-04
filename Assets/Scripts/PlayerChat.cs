using Mirror;

public class PlayerChat : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        if (ChatManager.Instance != null)
            ChatManager.Instance.SetLocalPlayer(this);
    }

    [Command]
    public void CmdSendMessage(string msg)
    {
        RpcReceiveMessage(msg);
    }

    [ClientRpc(includeOwner = false)]  // 👈 don’t send back to sender
    void RpcReceiveMessage(string msg)
    {
        ChatManager.Instance.AddMessage(msg);
    }
}

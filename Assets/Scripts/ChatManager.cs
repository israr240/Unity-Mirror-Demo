using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance;

    public TMP_Text chatLog;
    public TMP_InputField inputField;

    private PlayerChat localPlayerChat;

    void Awake()
    {
        Instance = this;

        // Hook the input field submit
        inputField.onSubmit.AddListener(OnSubmit);
    }

    public void SetLocalPlayer(PlayerChat player)
    {
        localPlayerChat = player;
    }

    public void OnSubmit(string message)
    {
        if (string.IsNullOrWhiteSpace(message)) return;
        if (localPlayerChat == null) return;

        string senderType = localPlayerChat.isServer ? "Server" : "Client";

        // Send to server via player
        localPlayerChat.CmdSendMessage($"{senderType}: {message}");

        // Clear input
        inputField.text = "";
        inputField.ActivateInputField();

        chatLog.text += "\n" + $"{senderType}: {message}";
    }

    public void AddMessage(string msg)
    {
        Debug.Log("AddMessage called: " + msg);

        if (chatLog == null)
        {
            Debug.LogWarning("⚠️ chatLog is not assigned in the Inspector!");
            return;
        }

        chatLog.text += "\n" + msg;
    }
}
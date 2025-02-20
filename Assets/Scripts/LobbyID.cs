using TMPro;
using UnityEngine;

public class LobbyID : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_lobbyIdText;

    // Start is called before the first frame update
    void Start()
    {
        //ƒƒr[ì¬or“üº‚É‹L‰¯‚µ‚Ä‚¨‚¢‚½LobbyID‚ğİ’è
        m_lobbyIdText.text = SteamLobby.Instance.LobbyID.ToString();
    }
}

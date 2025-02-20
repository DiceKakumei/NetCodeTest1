using TMPro;
using UnityEngine;

public class LobbyID : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_lobbyIdText;

    // Start is called before the first frame update
    void Start()
    {
        //���r�[�쐬or�������ɋL�����Ă�����LobbyID��ݒ�
        m_lobbyIdText.text = SteamLobby.Instance.LobbyID.ToString();
    }
}

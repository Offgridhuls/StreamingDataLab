using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PartySharingManager : MonoBehaviour
{

    public GameObject enterSharingRoomButton, sharingRoomNameText,
        sharingRoomInputField, sendPartyButton;

    public NetworkedClient networkedClient;
    // Start is called before the first frame update
    void Start()
    {
        enterSharingRoomButton.GetComponent<Button>().onClick.AddListener(JoinSharingRoomButtonPressed);
        sendPartyButton.GetComponent<Button>().onClick.AddListener(SendPartyButtonPressed);

        networkedClient = GetComponent<NetworkedClient>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SendPartyButtonPressed()
    {
        AssignmentPart2.SendOnScreenPartyToServerForSharing(networkedClient);

    }
    private void JoinSharingRoomButtonPressed()
    {

        string name = sharingRoomInputField.GetComponent<InputField>().text;
        networkedClient.SendMessageToHost(ClientToServerSignifiers.JoinSharingRoom + "," + name);
    }
}

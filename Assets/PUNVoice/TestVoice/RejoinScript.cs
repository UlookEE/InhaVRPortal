using UnityEngine;

public class RejoinScript : MonoBehaviour
{
    private void OnConnectionFail(DisconnectCause cause)
    {
        Debug.LogFormat("OnConnectionFail={0}", cause);
        if (cause == DisconnectCause.DisconnectByServerTimeout)
        {
            Debug.Log("ReconnectAndRejoin");
            //PhotonNetwork.Disconnect();
            PhotonNetwork.ReconnectAndRejoin();
        }
    }

    private void OnEnable()
    {

    }
}

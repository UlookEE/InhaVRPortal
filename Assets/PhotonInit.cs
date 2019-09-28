using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public string gameVersion = "1.0";
    public string nickName = "Boyun";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        OnLogin();
    }
    
    void OnLogin()
    {
        PhotonNetwork.GameVersion = this.gameVersion;
        // 게임버전 설정, 같은 버전끼리 공유 됨
        PhotonNetwork.NickName = this.nickName;
        PhotonNetwork.ConnectUsingSettings(); 
        // 포톤을 이용한 온라인 연결
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected !!!");
        PhotonNetwork.JoinRandomRoom(); 
        // 생성 룸 랜덤 접속
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed join Room!!");
        this.CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, 0), Quaternion.identity);
    }

    void CreateRoom()
    {
        //CreateRoom(방이름,방옵션)
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }


}

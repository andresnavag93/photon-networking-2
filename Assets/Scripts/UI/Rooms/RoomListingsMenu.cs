using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listing = new List<RoomListing>();
    private RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("On Joined Joined room successfully");
        _roomCanvases.CurrentRoomCanvas.Show();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo roomInfo in roomList)
        {
            //Remove from rooms list.
            if (roomInfo.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);
                if (index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            else
            {
                RoomListing listing = Instantiate(_roomListing, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(roomInfo);
                    _listing.Add(listing);
                }
            }
        }
    }
}

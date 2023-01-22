using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    public Transform MainPlayer;
    public Transform Player;
    public Transform Car;

    void OnTriggerEnter(Collider col)
    {
        Car.transform.SetParent(MainPlayer);
        Player.gameObject.SetActive(false);
        Car.transform.rotation = Player.transform.rotation;
    }
}

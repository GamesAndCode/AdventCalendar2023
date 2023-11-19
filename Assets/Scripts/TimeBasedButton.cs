using System;
using UnityEngine;

public class TimeBasedButton : MonoBehaviour
{
    [SerializeField] private int startingYear = 2023;
    [SerializeField] private int startingMonth = 12;

    private void InitializeDoor(int doorNumber)
    {
        DateTime currentDateTime = DateTime.Now;

        bool canOpenDoor = (currentDateTime.Day >= doorNumber && currentDateTime.Month == startingMonth) || currentDateTime.Year > startingYear ? true : false;
        gameObject.SetActive(canOpenDoor);
    }

    public void SetDoorNumber(int doorNumber) => InitializeDoor(doorNumber);
}

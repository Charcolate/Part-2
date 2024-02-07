using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject axePrefab;

    public void spawner()
    {

        Instantiate(axePrefab);
    }
}

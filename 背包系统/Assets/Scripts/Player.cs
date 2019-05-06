using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player类用作测试
public class Player : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 2);
            Knapsack.Instance.StoreItem(id);
        }
    }
}

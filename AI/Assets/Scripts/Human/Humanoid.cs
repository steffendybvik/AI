using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : Mammal {
    public float inventory = 0;
    public float maxInventory = 100;
	
    public void AddToInventory(float amount) {
        inventory += amount;
    }
}

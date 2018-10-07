using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : AiBehavior {

    private float utilityValue = 0.15f;
    private Humanoid humanoid;

    private void Start() {
        humanoid = GetComponent<Humanoid>();
    }

    public override float GetUtiltyValues() {
        Debug.Log("Returned utility value");
        return utilityValue;
    }

    public override void Execute() {
        if (humanoid.statusText.text != "Idle") {
            humanoid.statusText.text = "Idle";
        }
        StartCoroutine( IdleEnum());
    }
    
    public IEnumerator IdleEnum() {
        while (humanoid.statusText.text == "Idle") {
            Debug.Log("ran idle enum");
            yield return null;
        }

    }
}

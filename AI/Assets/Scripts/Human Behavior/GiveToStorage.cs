using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveToStorage : AiBehavior {

    private float utilityValue = 0.0f;
    private Humanoid humanoid;

    private void Start() {
        humanoid = GetComponent<Humanoid>();
    }

    public override float GetUtiltyValues() {
        if (Vector3.Distance(humanoid.target.transform.position, this.transform.position) >= 1) {
            utilityValue = 0.4f;
        }
        else {
            utilityValue = 0f;
        }
        Debug.Log("Returned GiveToStorage value");
        return utilityValue;
    }

    public override void Execute() {
        if (humanoid.statusText.text != "Walking") {
            humanoid.statusText.text = "Walking";
        }
        humanoid.agent.SetDestination(humanoid.target.transform.position);
        StartCoroutine(IdleEnum());
    }

    public IEnumerator IdleEnum() {
        while (humanoid.statusText.text == "Walking") {
            Debug.Log("ran walking enum");
            yield return null;
        }

    }
}

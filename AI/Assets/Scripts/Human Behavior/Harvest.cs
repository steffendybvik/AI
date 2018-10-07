using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : AiBehavior {

    private float utilityValue = 0.0f;
    private Humanoid humanoid;

    private void Start() {
        humanoid = GetComponent<Humanoid>();
    }

    public override float GetUtiltyValues() {
        if (humanoid.inventory >= humanoid.maxInventory) {
            utilityValue = 0f;
            humanoid.target = null;
        }
        else if (Vector3.Distance(humanoid.target.transform.position, this.transform.position) <= 1.5) {
            utilityValue = 0.6f;
        }
        else {
            utilityValue = 0f;
        }
        Debug.Log("Returned utility value");
        return utilityValue;
    }

    public override void Execute() {
        if (humanoid.statusText.text != "Harvesting") {
            humanoid.statusText.text = "Harvesting";
        }
        StartCoroutine(IdleEnum());
    }

    public IEnumerator IdleEnum() {

        float timeElapsed = 0f;
        float waitTime = 2f;

        while (humanoid.statusText.text == "Harvesting") {

            timeElapsed += Time.deltaTime;
            if (timeElapsed >= waitTime) {
                Debug.Log("ran harvest enum");
                humanoid.AddToInventory(1);
                timeElapsed = 0f;

            }


            yield return null;
        }

    }
}

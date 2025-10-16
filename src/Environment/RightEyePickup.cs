using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEyePickup : MonoBehaviour {

	public float TheDistance;
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCross;
    public GameObject theLeftEye;

    public GameObject halfFade;
    public GameObject eyeImg;
    public GameObject eyeText;

    public GameObject fakeWall;
    public GameObject realWall;

	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver () {
		if (TheDistance <= 2) {
			ExtraCross.SetActive (true);
			ActionText.GetComponent<Text> ().text = "Pick Up Right Eye";
			ActionDisplay.SetActive (true);
			ActionText.SetActive (true);
		}
		if (Input.GetButtonDown("Action")) {
			if (TheDistance <= 2) {
				this.GetComponent<BoxCollider>().enabled = false;
				ActionDisplay.SetActive(false);
				ActionText.SetActive(false);
				ExtraCross.SetActive (false);
                GlobalInventory.rightEye = true;
                StartCoroutine(EyePickedUp());
			}
		}
	}

	void OnMouseExit() {
		ExtraCross.SetActive (false);
		ActionDisplay.SetActive (false);
		ActionText.SetActive (false);
	}

    IEnumerator EyePickedUp()
    {
        fakeWall.SetActive(false);
        realWall.SetActive(true);
        eyeText.GetComponent<Text>().text = "YOU GOT THE RIGHT EYE PIECE";
        halfFade.SetActive(true);
        eyeImg.SetActive(true);
        eyeText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        halfFade.SetActive(false);
        eyeImg.SetActive(false);
        eyeText.SetActive(false);
        theLeftEye.SetActive(false);
    }
}

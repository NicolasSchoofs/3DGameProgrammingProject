using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at

	void Start () {
        //dit script is in de finale versie niet in gebruik
        if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
			transform.LookAt(target.transform);
	}
}

using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class CreateTeacherNpc : MonoBehaviour {

	public GameObject teacherNpc;
	private bool instantiated;

	void Update () {

		float x = 0;
		float y = 0;

		GameObject classThatIsearchForGameObject = GameObject.FindGameObjectWithTag ("Class That I Search For");
	
		Transform classThatISearchFor = classThatIsearchForGameObject.transform.parent;

		if (classThatISearchFor.tag != "Class Four Number" && classThatISearchFor.tag != "Class Five Number") {
			x = classThatISearchFor.transform.position.x - 10;
			y = classThatISearchFor.transform.position.y + 7;
		} else if (classThatISearchFor.tag == "Class Four Number") {
			x = classThatISearchFor.transform.position.x - 5;
			y = classThatISearchFor.transform.position.y - 7;
		} else {
			x = classThatISearchFor.transform.position.x + 5;
			y = classThatISearchFor.transform.position.y - 7;
		}

		if (classThatISearchFor.tag != null && !instantiated) {
			instantiated = true;

			Debug.Log ("class # = " + classThatISearchFor.tag);


			GameObject spawnedTeacherNpc = Instantiate (teacherNpc, new Vector3 (x, y, -91), Quaternion.identity) as GameObject;
			spawnedTeacherNpc.transform.parent = GameObject.FindGameObjectWithTag ("NPC").transform;
			spawnedTeacherNpc.name="Teacher NPC";
		}
	}
}

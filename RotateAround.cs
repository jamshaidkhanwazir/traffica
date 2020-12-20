using UnityEngine;

public class RotateAround : MonoBehaviour 
{
	[Range(10, 30)]
	public int Speed;
	public GameObject Target;
	
	private void Update () 
	{
		transform.RotateAround(Target.GetComponent<Transform> ().position, Vector3.up, Speed * Time.deltaTime);
	}
}

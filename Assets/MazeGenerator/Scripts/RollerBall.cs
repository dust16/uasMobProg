using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RollerBall : MonoBehaviour
{
	//kamera
	public GameObject ViewCamera = null;


	public bool isFlat=true;	
	private Rigidbody rigidbody;

	void Start()
	{
		//kasih berat/body
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//ambil input accelerometer
		Vector3 tilt = Input.acceleration*3;

		if (isFlat)
			tilt = Quaternion.Euler (90, 0, 0) * tilt;

		//agar kamera mengikuti bola dan zoom saat ada object yang menghalangi
		if (ViewCamera != null) {
			Vector3 direction = (Vector3.up*2+Vector3.back)*2;
			RaycastHit hit;
			Debug.DrawLine(transform.position,transform.position+direction,Color.red);

				ViewCamera.transform.position = transform.position+direction;

			ViewCamera.transform.LookAt(transform.position);
		}

		rigidbody.AddForce (tilt);
		Debug.DrawRay (transform.position + Vector3.up, tilt, Color.cyan);
	}

	//hilangkan koin saat bola mengenai koin
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Coin")) {
			
			Destroy(other.gameObject);
			SceneManager.LoadScene ("gameover");
		}


	}

	public void onJumpClick()
	{
		
		if (rigidbody.position.y <=0.5) {
			rigidbody.AddForce (Vector3.up * 300);
		}
	}

}
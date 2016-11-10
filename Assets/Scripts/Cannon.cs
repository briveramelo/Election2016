using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Cannon : MonoBehaviour {

    [SerializeField] GameObject cBall;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            LaunchBall(KeyCode.UpArrow);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            LaunchBall(KeyCode.LeftArrow);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            LaunchBall(KeyCode.RightArrow);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            LaunchBall(KeyCode.DownArrow);
        }
    }

    float launchForce = 10000000;
    void LaunchBall(KeyCode direction) {
        Vector3 launchDirection = Vector3.zero;
        Vector3 spawnPosition = Vector3.zero;
        switch (direction) {
            case KeyCode.UpArrow:
                launchDirection = Vector3.up;
                spawnPosition = -Vector3.up * 20f;
                break;
            case KeyCode.DownArrow:
                launchDirection = Vector3.down;
                spawnPosition = -Vector3.down * 20f;
                break;
            case KeyCode.LeftArrow:
                launchDirection = Vector3.left;
                spawnPosition = -Vector3.left * 40f;
                break;
            case KeyCode.RightArrow:
                launchDirection = Vector3.right;
                spawnPosition = -Vector3.right * 40f;
                break;
        }

        GameObject ball = Instantiate(cBall, spawnPosition, Quaternion.identity) as GameObject;
        ball.GetComponent<Rigidbody>().AddForce(launchDirection * launchForce);
        Destroy(ball, 10f);
    }


}

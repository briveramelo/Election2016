using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    [SerializeField] Rigidbody myBody;
    [SerializeField, Range(500,5000)] float attractionForce;

    // Use this for initialization
    void Start() {
        attractionForce = 500;
    }

    Attraction myAttractionState = Attraction.None;
    enum Attraction {
        In=0,
        Out=1,
        None=2
    }

    struct GrenadeStats {
        public Vector3 origin;
        public float radius;
        public GrenadeStats(Vector3 origin, float radius) {
            this.origin = origin;
            this.radius = radius;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ToggleState();
        }
    }

    void OnTriggerStay(Collider col) {
        if (col.GetComponent<Ball>()) {
            switch (myAttractionState) {
                case Attraction.In:
                    Magnetize(col.GetComponent<Rigidbody>());
                    break;
                case Attraction.Out:
                    Repel(col.GetComponent<Rigidbody>());
                    break;
            }            
        }
    }

    void Magnetize(Rigidbody rigBod) {
        Vector3 otherPos = rigBod.transform.position;
        Vector3 pointAtMe = transform.position - otherPos;

        rigBod.AddForce(attractionForce * pointAtMe);
    }

    void Repel(Rigidbody rigBod) {
        Vector3 otherPos = rigBod.transform.position;
        Vector3 pointAway = otherPos - transform.position;
        float repulsionForce = attractionForce *  1/ Vector3.Distance(otherPos, transform.position);
        rigBod.AddForce(repulsionForce * pointAway);
    }

    
    public void ToggleState() {
        myAttractionState++;
        if ((int)myAttractionState >= 3) {
            myAttractionState = 0;
        }
    }
}

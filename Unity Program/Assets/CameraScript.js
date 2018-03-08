#pragma strict

function Start () {

}

var hFOV : float = 30;
 
 function FixedUpdate() {
 var hFOVrad : float = hFOV*Mathf.Deg2Rad;
 var camH : float = Mathf.Tan(hFOVrad*.5)/GetComponent.<Camera>().aspect;
 var vFOVrad : float = Mathf.Atan(camH)*2;
 GetComponent.<Camera>().fieldOfView = vFOVrad * Mathf.Rad2Deg;
 }
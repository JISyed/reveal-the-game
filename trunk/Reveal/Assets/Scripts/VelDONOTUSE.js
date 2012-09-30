#pragma strict
var targetObj: Transform;
function Start() {
}
function Update() {
    // Spin the object around the world origin at 20 degrees/second.
    
    transform.RotateAround (targetObj.position, Vector3.up, 80 * Time.deltaTime);
}
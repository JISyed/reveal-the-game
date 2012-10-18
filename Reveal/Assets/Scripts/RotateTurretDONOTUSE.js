// Credit to FTheCloud
// http://answers.unity3d.com/questions/156436/turret-range-script.html

var distanceTillShoot : float;
var LookAtTarget : Transform;
var damp : float = 6.0;
var bulletPrefab : GameObject;
var savedTime = 0;

function Start() {}

function Update ()
{
	 var playerObj = GameObject.FindGameObjectWithTag("Player");
	 if(playerObj)
	 {
	 	LookAtTarget = playerObj.transform;
	 }
	 
     if(LookAtTarget)
     {
          var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position); 
          transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
          var seconds : int = Time.time;
          Shoot(seconds);
          //transform.LookAt(LookAtTarget);
     }

}

function Shoot(seconds)
{
 var distance = Vector3.Distance(LookAtTarget.transform.position, transform.position);
   if (distance <= distanceTillShoot){
     //if(seconds!=savedTime)
     //{
          var bullet = Instantiate(bulletPrefab, transform.Find("spawnPoint").transform.position , transform.rotation);
     //}


     //savedTime=seconds;
    }
}
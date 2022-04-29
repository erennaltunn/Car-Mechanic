using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CustomerMover : MonoBehaviour
{

    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    [SerializeField] private Taker taker;

    public bool isMechanicPurchased = true;

    private Transform currentWayPoint;

    [SerializeField] private int wayPointIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        taker = GetComponent<Taker>();
        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        transform.position = currentWayPoint.transform.position;
        transform.LookAt(currentWayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMechanicPurchased)
        {
            //transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
            if(wayPointIndex != 5)
            transform.DOMove(currentWayPoint.transform.position, 2f);


            if(Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
            {
                if(wayPointIndex == 0){//start position
                    wayPointIndex++;
                    currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
                    transform.LookAt(currentWayPoint);
                }
                else if(wayPointIndex == 1){//first rotation
                    wayPointIndex++;
                    currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
                    transform.LookAt(currentWayPoint);
                }
                else if(wayPointIndex == 2){//mechanic
                    taker.enabled = true;
                    if(taker.TakedObjectsCount == 4){
                        wayPointIndex++;
                        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
                        transform.LookAt(currentWayPoint);
                    }
                }
                else if(wayPointIndex == 3){//cashier
                    wayPointIndex++;
                    currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
                    transform.LookAt(currentWayPoint);
                }
                else if(wayPointIndex == 4){
                    //Shake and Destroy Gameobject
                    //transform.DOShakeRotation(2f);
                    Debug.Log("4");
                    
                    transform.position = waypoints.GetStartWayPoint().transform.position;
                    transform.LookAt(currentWayPoint);
                    wayPointIndex++;
                }
                else if(wayPointIndex == 5){
                    Debug.Log("lastpart");
                    //transform.position = waypoints.GetStartWayPoint().transform.position;
                    wayPointIndex = 0;
                }
                
            }
        }
        
    }


    public IEnumerator Paying()
    {   
        yield return new WaitForSeconds(3f);
    }
}

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

    public Transform parentForWaypoints;

    public bool isMechanicPurchased = true;

    public bool isCustomerOnMove = true;

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
        if(isMechanicPurchased && isCustomerOnMove)
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
                    //stop at cashier
                    currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
                    transform.LookAt(currentWayPoint);
                    Taker tk = this.gameObject.GetComponent<Taker>();
                    for(int i=0;i<4;i++)
                    {
                        GameObject _convertedObj = tk.TakedObjects[i];
                        Destroy(_convertedObj);
                    }
                    tk.TakedObjects.Clear();
                    tk.TakedObjectsCount = 0;
                    GameObject customer = Instantiate(this.gameObject, new Vector3(-14f,1.4f,-6.5f), Quaternion.identity, parentForWaypoints);
                    customer.GetComponent<CustomerMover>().isMechanicPurchased = true;
                    Destroy(this.gameObject);
                    isCustomerOnMove = false; //stop loop;
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

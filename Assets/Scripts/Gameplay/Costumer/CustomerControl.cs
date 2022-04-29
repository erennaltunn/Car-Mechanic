using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CustomerControl : MonoBehaviour
{
    public Transform[] wayPoints;
    public Vector3 firstWayPoint;
    public Vector3 mechanicPosition;
    public Vector3 secondWayPoint;
    public Vector3 cashierPosition;
    public Vector3 endPosition;

    public GameObject Customer;

    private GameObject customer;

    public int mechanicID=0;

    public int cashierID=0;
    public Vector3 customerStartPosition;

    public CustomerSystem customerSystem;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToMechanic(){
        //Debug.Log("MovingTOMechanic");
        transform.DOMove(mechanicPosition, 5f, false);
    }

    public void MoveToCashier(){
        //Debug.Log("MovingToCashier");
        transform.DOMove(cashierPosition, 5f); 
    }

    public void MoveToEndPoint(){
        //Debug.Log("MovingToEndPoint");
        endPosition = cashierPosition + new Vector3(0,0,5);
        //transform.DOMove(endPosition, 5f).OnComplete(() => Destroy(this.gameObject)); 
    }

}

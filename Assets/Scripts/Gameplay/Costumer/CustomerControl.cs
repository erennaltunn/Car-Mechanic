using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class CustomerControl : MonoBehaviour
{
    public Vector3 mechanicPosition;

    public Vector3 cashierPosition;

    public Vector3 destroyPosition;

    public GameObject Customer;

    private GameObject customer;

    public int mechanicID=0;

    public int cashierID=0;
    public Vector3 customerStartPosition = new Vector3(2,-1,-10);

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
        Debug.Log("MovingTOMechanic");
        transform.DOMove(mechanicPosition, 5f, false);
    }

    public void MoveToCashier(){
        Debug.Log("MovingToCashier");
        transform.DOMove(cashierPosition, 5f); 
    }

    public void MoveToEndPoint(){
        Debug.Log("MovingToEndPoint");
        transform.DOMove(destroyPosition, 5f).OnComplete(() => Destroy(this.gameObject)); 
    }

}

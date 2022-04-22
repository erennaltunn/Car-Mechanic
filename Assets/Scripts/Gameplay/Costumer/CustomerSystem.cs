using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{

    public List<GameObject> mechanics = new List<GameObject>();

    public List<GameObject> cashiers = new List<GameObject>();

    public List<GameObject> customers = new List<GameObject>();

    public Vector3 customerStartPosition = new Vector3(2,-1,-10);


    public GameObject Customer;

    private GameObject customer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitCustomer(int MechanicID, int cashierID)
    {
        customer = Instantiate(Customer, customerStartPosition, Quaternion.identity);
        customer.GetComponent<CustomerControl>().mechanicPosition = mechanics[MechanicID].transform.position;
        customer.GetComponent<CustomerControl>().cashierPosition = cashiers[cashierID].transform.position;;
        customer.GetComponent<CustomerControl>().MoveToMechanic();
    }


    public void ActivateTaker(Collider other)
    {
        other.gameObject.GetComponent<Taker>().enabled = true;
        Debug.Log("Car entered mechanic");
    }

    public void DisableTaker(Collider other)
    {
        other.gameObject.GetComponent<Taker>().enabled = false;
        Debug.Log("Car exited mechanic");
    }


    public void SendToCashier()
    {
  
        Debug.Log("sendtocahsier");
        
        
    }


}

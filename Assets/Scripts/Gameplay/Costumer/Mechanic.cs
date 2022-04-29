using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    [Tag]
    public string targetTag;

    public int mechanicID;

    public bool isCustomerInit = false;
    public CustomerSystem customerSystem;
    public Vector3 customerStartPosition = new Vector3(2,-1,-10);

    public Vector3 cashierPosition;

    public Vector3 endPosition;

    public GameObject Customer;

    private GameObject customer;

    private bool instantiateNewCustomer = true;

    // Start is called before the first frame update
    void Start()
    {
        //cashierPosition = customerSystem.GetComponent<CustomerSystem>().cashiers[mechanicID].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCustomer() {
        if(isCustomerInit == false){
            Debug.Log("init cutomer");
            isCustomerInit = true;
            customer = Instantiate(Customer, customerStartPosition, Quaternion.identity);
            customer.GetComponent<CustomerControl>().mechanicID = mechanicID;
            customer.GetComponent<CustomerControl>().mechanicPosition = transform.position;
            customer.GetComponent<CustomerControl>().cashierPosition = cashierPosition;
            //customer.GetComponent<CustomerControl>().endPosition = endPosition;
            //customerSystem.customers.Add(customer);
            customer.GetComponent<CustomerControl>().MoveToMechanic();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == targetTag)
        {   
            
            other.gameObject.GetComponent<Taker>().enabled = true;
            other.gameObject.GetComponent<CustomerControl>().mechanicID = mechanicID;
            Debug.Log("Car entered mechanic");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == targetTag && other.gameObject.GetComponent<Taker>().TakedObjectsCount == 4){
            other.gameObject.GetComponent<CustomerControl>().MoveToCashier();           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            other.gameObject.GetComponent<Taker>().enabled = false;
            Debug.Log("Car exited mechanic");
            isCustomerInit = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    [Tag]
    public string targetTag;

    public int mechanicID;

    public CustomerSystem customerSystem;
    public Vector3 customerStartPosition = new Vector3(2,-1,-10);

    public Vector3 cashierPosition = new Vector3(14.5f,-1f,0f);

    public GameObject Customer;

    private GameObject customer;

    private bool instantiateNewCustomer = true;

    // Start is called before the first frame update
    void Start()
    {
        Customer.GetComponent<CustomerControl>().mechanicPosition = transform.position;
        Customer.GetComponent<CustomerControl>().cashierPosition = cashierPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateCustomer() {
        customer = Instantiate(Customer, customerStartPosition, Quaternion.identity);
        customer.GetComponent<CustomerControl>().mechanicID = mechanicID;
        customer.GetComponent<CustomerControl>().mechanicPosition = transform.position;
        customer.GetComponent<CustomerControl>().cashierPosition = cashierPosition;
        customerSystem.customers.Add(customer);
        customer.GetComponent<CustomerControl>().MoveToMechanic();
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
        if(other.gameObject.tag == targetTag && other.gameObject.GetComponent<Taker>().TakedObjectsCount == 4 && instantiateNewCustomer){
            other.gameObject.GetComponent<CustomerControl>().MoveToCashier();           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            other.gameObject.GetComponent<Taker>().enabled = false;
            Debug.Log("Car exited mechanic");
            instantiateNewCustomer = true;
        }
    }

}

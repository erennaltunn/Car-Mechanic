using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private bool enteredCashier = false;

    public CustomerSystem customerSystem;

    public int cashierID=0;

    public Vector3 customerStartPosition = new Vector3(-13, -1, -10);

    public Vector3 mechanicPosition;
    public GameObject Customer;

    public GameObject customer;
    void Start()
    {
        //mechanicPosition = customerSystem.GetComponent<CustomerSystem>().mechanics[cashierID].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        enteredCashier = false;

        //int id = other.gameObject.GetComponent<CustomerControl>().mechanicID;
        //Debug.Log(id);

        customer = other.gameObject;

        
        if(other.tag == "Car"){
            StartCoroutine(Paying(other.gameObject));
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(!enteredCashier && other.tag == "Car"){
            enteredCashier = true;
            
            
            Debug.Log("exitcashier: " + cashierID.ToString());
            InitCustomer();

        }

    }

    public void InitCustomer()
    {
        customer = Instantiate(Customer, customerStartPosition, Quaternion.identity);
        customer.GetComponent<CustomerControl>().mechanicID = cashierID;
        customer.GetComponent<CustomerControl>().mechanicPosition = mechanicPosition;
        customer.GetComponent<CustomerControl>().cashierPosition = transform.position;
        //customerSystem.customers.Add(customer);
        customer.GetComponent<CustomerControl>().MoveToMechanic();
    }


    public IEnumerator Paying(GameObject gameObject)
    {   
        Debug.Log("Paying");
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<CustomerControl>().MoveToEndPoint();
        
    }
}

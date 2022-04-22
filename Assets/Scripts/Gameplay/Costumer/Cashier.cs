using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private bool enteredCashier = false;

    public CustomerSystem customerSystem;

    public GameObject customer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        enteredCashier = false;

        int id = other.gameObject.GetComponent<CustomerControl>().mechanicID;
        Debug.Log(id);

        customer = other.gameObject;

        if(other.tag == "Car"){
            StartCoroutine(Paying(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other) {
        if(!enteredCashier){
            enteredCashier = true;
            
            int id = other.gameObject.GetComponent<CustomerControl>().mechanicID;
            
            Debug.Log("exitcashier" + id.ToString());
            customerSystem.InitCustomer(id,0);

        }

    }



    public IEnumerator Paying(GameObject gameObject)
    {   

        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<CustomerControl>().MoveToEndPoint();

        
    }
}

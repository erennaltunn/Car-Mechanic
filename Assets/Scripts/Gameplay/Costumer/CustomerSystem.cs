using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    public Vector3 customerStartPosition = new Vector3(2,-1,-10);

    public CustomerMover[] Customers;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCustomer(int id)
    {
        Customers[id].isMechanicPurchased = true;
        
    }

    public void DisableCustomer(int id)
    {
        Customers[id].isMechanicPurchased = false;
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage;
    public bool isOnRoad;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dog") 
        {
            Debug.Log("You Bastard!");
            Destroy(collision.gameObject);
        }

        if (collision.tag == "DedDog") 
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (collision.tag == "Package" && !hasPackage) 
        {
            Debug.Log("Package picked");
            Destroy(collision.gameObject);
            hasPackage = true;
            gameObject.GetComponent<SpriteRenderer>().color = hasPackageColor;

        }

        if (collision.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
            gameObject.GetComponent<SpriteRenderer>().color = noPackageColor;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bump!");    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer : MonoBehaviour
{
    public float speed;
    public bool isTouchU;
    public bool isTouchD;
    public bool isTouchL;
    public bool isTouchR;

    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if((isTouchR &&  h== 1)||(isTouchL && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchU && v == 1) || (isTouchD && v == -1))
            v = 0;

        Vector3 cuPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0)* speed * Time.deltaTime;
        transform.position = cuPos + nextPos;

        anim.SetInteger("Input", (int)h);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchU = true;
                    break;
                case "Bottom":
                    isTouchD = true;
                    break;
                case "Left":
                    isTouchL = true;
                    break;
                case "Right":
                    isTouchR = true;
                    break;
            }
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchU = false;
                    break;
                case "Bottom":
                    isTouchD = false;
                    break;
                case "Left":
                    isTouchL = false;
                    break;
                case "Right":
                    isTouchR = false;
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    private Animator animator;
    private bool isSliding = false;

    private BoxCollider2D collider2D;

    [SerializeField]
    private float offsetY = -0.05f;
    private float sizeY = 0.05f;

    private Vector2 startOffset;
    private Vector2 startSize;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canSlide = animator.GetBool("isFly")==false;
        if (canSlide)
        {
            if (isSliding)
            {
                bool isKeyUp = (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.DownArrow));
                if (isKeyUp)
                {
                    StartSlide();
                }
            }
            else
            {
                bool isKeyDown = (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.DownArrow));
                if (isKeyDown)
                {
                    EndSlide();
                }
            }
        }
    }

    private void StartSlide()
    {
        collider2D.offset = new Vector2(startOffset.x , offsetY);
        collider2D.size = new Vector2(startSize.x, sizeY);

        isSliding = false;
        animator.SetBool("isCrouch", isSliding);
    }

    private void EndSlide()
    {
        collider2D.offset = startOffset;
        collider2D.size = startSize;

        isSliding = true;
        animator.SetBool("isCrouch", isSliding);

        
    }
}

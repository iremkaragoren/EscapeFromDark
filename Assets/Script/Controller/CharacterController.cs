using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private List<TrailRenderer> trailRenderers;
    [SerializeField] private Color dashColor;
    [SerializeField] private Color normalColor;

    private bool isGrounded = true;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDashing)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Plane"))
        {
            isGrounded = true;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        ChangeTrailsColor(true);
        yield return new WaitForSeconds(dashingTime);
        ChangeTrailsColor(false);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void ChangeTrailsColor(bool isDashing)
    {
        Color colorToChange = isDashing ? dashColor : normalColor;

        foreach (var trail in trailRenderers)
            trail.material.color = colorToChange;
    }
}

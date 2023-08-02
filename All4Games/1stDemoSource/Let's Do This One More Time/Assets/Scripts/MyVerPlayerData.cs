using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class MyVerPlayerData : ScriptableObject

{
	

	//Gravity
	[Header("Gravity")]
	[HideInInspector] public float gravityStrength;
	[HideInInspector] public float gravityScale;

	public float fallGravityMult;
	public float maxFastFallSpeed;

	//Look up what [Space(5)] Does when we get the chance. 
	public float maxFallSpeed;
	public float fastFallGravityMult;



	[Header("Run")]
	public float runMaxSpeed;
	public float runAcceleration;

	public float runDecceleration;

	[HideInInspector] public float runAccelAmount;
	[HideInInspector] public float runDeccelAmount;

	[Range(0f, 1)] public float accellInAir;
	[Range(0f, 1)] public float decellInAir;
	public bool doConserveMomentum = true; //Reminder to see what this looks like on and off but with the same values. 

	[Header("Jump")]
	public float jumpHeight;
	public float jumpTimeToTop; // Time between applying force and reaching the desired jump height. I'm changing this from apex to top because that's what I would have called it and I'm trying to add even the smallest amount of 'me' to this.

	[HideInInspector] public float jumpForce;

	[Header("Wall Jump")]
	public Vector2 wallJumpForce;

	[Range(0f, 1f)] public float wallJumpRunLerp;
	[Range(0f, 1.5f)] public float wallJumpTime;

	public bool doTurnAwayAfterWallJump; //Originally doTurnOnWallJump I feel this is a more accurate description


	[Header("Both Jumps")]
	public float jumpCutGravityMult;
	[Range(0f, 1)] public float jumpHangGravityMult;
	public float jumpHangTimeThreshold;
	[Space(0.5f)]
	public float jumpHangAccelerationMult;
	public float jumpHangMaxSpeedMult;
	//Got to learn if this is slide down a wall or like a ground slide.
	[Header("Slide")]
	public float slideSpeed;
	public float slideAccel;

	[Header("Assists")]
	[Range(0.01f, 0.5f)] public float coyoteTime; //Grace time from falling off a ledge and then when you can jump. Think Wil E. Coyote
	[Range(0.01f, 0.5f)] public float jumpInputBufferTime;

	//Unity Callback, called when the inspector updates
	private void OnValidate()
	{
		////Calculate gravity strength using the formula (gravity = 2 * jumpHeight / timeToJumpApex^2)
		gravityStrength = -(2 * jumpHeight) / (jumpTimeToTop * jumpTimeToTop);

		gravityScale = gravityStrength / Physics2D.gravity.y;

		runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
		runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

		jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToTop;

		#region Variable Ranges
		runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxSpeed);
		runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxSpeed);
		#endregion
	}

}


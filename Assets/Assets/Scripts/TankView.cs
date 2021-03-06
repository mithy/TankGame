﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

	private const string IS_MOVING_ANIM = "isMoving";

	[SerializeField]
	private Transform _rotationNode;

	[SerializeField]
	private Transform _bulletFire;

	[SerializeField]
	private GameObject _explosionNode;

	private DirectionsEnum _currentFacingDirection = DirectionsEnum.Left;
	public DirectionsEnum CurrentFacingDirection {
		get {
			return _currentFacingDirection;
		}
	}

	public Vector3 TurretPosition {
		get {
			return _bulletFire.position;
		}
	}

	private Animator _animator;

	private void Awake() {
		_animator = _rotationNode.GetComponent<Animator>();
		_explosionNode.SetActive(false);
	}

	public void Rotate(DirectionsEnum direction) {
		switch (direction) {
			case DirectionsEnum.Up:
				_rotationNode.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
				break;
			
			case DirectionsEnum.Down:
				_rotationNode.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
				break;

			case DirectionsEnum.Left:
				_rotationNode.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
				break;

			case DirectionsEnum.Right:
				_rotationNode.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
				break;
		}

		if (direction != DirectionsEnum.None) {
			_currentFacingDirection = direction;
		}
	}

	public void ToggleAnimation(bool shouldAnimate) {
		_animator.SetBool(IS_MOVING_ANIM, shouldAnimate);
	}

	public void ToggleExplosion(bool shouldExplore) {
		_explosionNode.SetActive(shouldExplore);
		_rotationNode.gameObject.SetActive(!shouldExplore);
	}
}
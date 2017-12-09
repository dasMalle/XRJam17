namespace Demo.Utilities
{
	using UnityEngine;

	public class POITouchable : MonoBehaviour, ITouchable
	{
		[SerializeField]
		Animator _animator;

		[SerializeField]
		AnimationCurve _activationCurve;

		Vector3 _originalScale;

		bool _isActive;

		public string Description
		{
			get
			{
				return "";
			}
		}

		void Start()
		{
			_originalScale = transform.localScale;
		}

		public void Activate()
		{
			_animator.SetTrigger("Activate");
			_isActive = true;
		}

		public void Focus()
		{
			_animator.SetTrigger("Bounce");
		}

		public void Deactivate()
		{
			transform.localScale = _originalScale;
			if (_isActive)
			{
				_animator.SetTrigger("Deactivate");
			}
			else
			{
				_animator.SetTrigger("Bounce");
			}
			_isActive = false;
		}
	}
}
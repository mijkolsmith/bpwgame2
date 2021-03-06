using UnityEngine;

namespace Pathfinding
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;
		Transform player;
		[SerializeField]
		float range = 5;
		public float timer = 0f;
		public float timer2 = 1000f;

		void OnEnable()
		{
			ai = GetComponent<IAstarAI>();

			//the range at which enemies can see the player, and the delay in between shots
			if (gameObject.tag == "Enemy1")
			{
				range = 5;
				timer = 0f;
			}

			if (gameObject.tag == "Enemy2")
			{
				range = 7;
				timer = 2f;
			}

			if (gameObject.tag == "Enemy3")
			{
				range = 6;
				timer = 3f;
			}

			if (gameObject.tag == "Magic")
			{
				range = 20;
				timer = 0f;
			}

			if (gameObject.tag == "Boss")
			{
				range = 6;
				timer = 3f;
				timer2 = 4f;
			}

			if (gameObject.tag == "BossMagic")
			{
				range = 20;
				timer = 0f;
			}

			player = GameObject.Find("Player").transform;

			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable()
		{
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update()
		{
			if (player != null)
			{
				if (ai.position.x - player.localPosition.x <= range && ai.position.y - player.localPosition.y <= range && ai.position.x - player.localPosition.x >= -range && ai.position.y - player.localPosition.y >= -range)
				{
					target = player;
					timer -= Time.deltaTime;
					timer2 -= Time.deltaTime;
				}
				else
				{
					target = null;
				}
			}

			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}

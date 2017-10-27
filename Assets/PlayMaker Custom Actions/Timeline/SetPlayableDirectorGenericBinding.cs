// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Set Generic Binding for a PlayableDirector")]
	public class  SetPlayableDirectorGenericBinding : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("The game object To Bind to the PlayableDirector Timeline")]
		public FsmOwnerDefault bindingObject;
	
		PlayableDirector timeline;
		TimelineAsset timelineAsset;
		PlayableBinding _playableBinding;
		public override void Reset()
		{
			gameObject = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			timeline = go.GetComponent<PlayableDirector>();

			timelineAsset = (TimelineAsset)timeline.playableAsset;

			timelineAction();
		}

		void timelineAction()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null || timeline == null || timelineAsset == null)
			{
				return;
			}

			_playableBinding = timelineAsset.outputs.FirstOrDefault ();

			timeline.SetGenericBinding(_playableBinding.sourceObject,Fsm.GetOwnerDefaultTarget (bindingObject));

		}

	}
}
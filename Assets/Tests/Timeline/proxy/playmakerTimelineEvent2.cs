/*
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

using HutongGames.PlayMaker;

using HutongGames.PlayMaker.Ecosystem.Utils;

public class PlayMakerTimelineEvent2 : PlayableAsset
{

	public PlayMakerTimelineEventTarget eventTarget = new PlayMakerTimelineEventTarget(false);

	[EventTargetVariable("eventTarget")]
	//[ShowOptions]
	public PlayMakerEvent OnPlay;

	// The pause is weird, you get it at the beginning of the graph when it starts, and at the end of this component
//	[EventTargetVariable("eventTarget")]
//	//[ShowOptions]
//	public PlayMakerEvent OnPause;

	[EventTargetVariable("eventTarget")]
	//[ShowOptions]
	public PlayMakerEvent OnFinished;

	public bool debug;

	private GameObject _owner;

	bool isPlaying;

	//
	// Methods
	//
	public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
	{
		_owner = owner;
		eventTarget.SetOwner (owner);
		eventTarget.Resolve (graph.GetResolver ());

		return ScriptPlayable<PlayMakerTimelineEvent2>.Create (graph, this, 0);
	}
//
//	public void OnBehaviourPause (Playable playable, FrameData info)
//	{
//		if (isPlaying)
//		{
//			isPlaying = false;
//			SendPlayMakerEvent (OnFinished);
//		} else
//		{
//		//	SendPlayMakerEvent (OnPause);
//		}
//	}
//
//	public void OnBehaviourPlay (Playable playable, FrameData info)
//	{
//		isPlaying = true;
//		SendPlayMakerEvent (OnPlay);
//	}


	string _debug ="";

	protected void SendPlayMakerEvent(PlayMakerEvent pmEvent)
	{
		
		if (debug )
		{
			_debug = string.Empty;
			if (!Application.isPlaying)
			{
				_debug = "<color=RED>Application must run to send a PlayMaker Event, but the proxy at least works</color>\n";
			
			}

			_debug += "Send " + pmEvent.ToString () + " on " + eventTarget.ToString ();

			UnityEngine.Debug.Log (_debug);
		}

		if (Application.isPlaying)
		{
			pmEvent.SendEvent (null, eventTarget);
		}
	}


}
*/

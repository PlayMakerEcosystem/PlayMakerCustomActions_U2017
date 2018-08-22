using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using HutongGames.PlayMaker;

using HutongGames.PlayMaker.Ecosystem.Utils;

public class playmakerTimelineEvent1 : BasicPlayableBehaviour
{
	
	public PlayMakerTimelineEventTarget eventTarget = new PlayMakerTimelineEventTarget(false);

	[EventTargetVariable("eventTarget")]
	//[ShowOptions]
	public PlayMakerEvent OnPlay;

	public bool debug;

	private GameObject _owner;

	public override void OnGraphStart(Playable playable) 
	{

	//	fsm = playmakerObject.Resolve(playable.GetGraph().GetResolver());

		eventTarget.Resolve (playable.GetGraph ().GetResolver ());
	}


	public override Playable CreatePlayable( PlayableGraph graph, GameObject owner )
	{
		if (debug)
		{
			UnityEngine.Debug.Log(owner,this);
		}
		_owner = owner;
		eventTarget.SetOwner (owner);

		return base.CreatePlayable(graph,owner);
	}


	public override void OnBehaviourPlay(Playable playable, FrameData info)
	{
		SendPlayMakerEvent (OnPlay);
	}



	protected void SendPlayMakerEvent(PlayMakerEvent pmEvent)
	{
		if (debug || !Application.isPlaying)
		{
			UnityEngine.Debug.Log("Send "+pmEvent.ToString()+" on "+eventTarget.ToString(),this);
		}

		if (!Application.isPlaying)
		{
			UnityEngine.Debug.Log("<color=RED>Application must run to send a PlayMaker Event, but the proxy at least works</color>",this);
			return;
		}

		pmEvent.SendEvent(null,eventTarget);
	}


}

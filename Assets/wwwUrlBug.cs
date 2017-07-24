// this is a test for bug https://issuetracker.unity3d.com/issues/www-dot-url-truncates-redirected-url-if-it-should-have-contained-spaces
// it is present in 2017.0 and 2017.1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwwUrlBug : MonoBehaviour {

	public string url = "http://www.fabrejean.net/projects/playmaker_ecosystem/download?repository=jeanfabre%2FPlayMaker--Unity--UI&file=PlayMaker%2FEcosystem%2FCustom%20Packages%2FuGui%2FuGuiProxyFull.unitypackage&uid=1";

	// this one is raw spaces and / but still it doesn't work.
	public string url2 = "http://www.fabrejean.net/projects/playmaker_ecosystem/download?repository=jeanfabre/PlayMaker--Unity--UI&file=PlayMaker/Ecosystem/Custom Packages/uGui/uGuiProxyFull.unitypackage&uid=1";

	IEnumerator Start () {

		WWW _www = new WWW (url2);
		Debug.Log ("Downloading " + url);
		yield return _www;

		Debug.Log ("the _www.url is now "+_www.url);
		// you can see that the url choke on the first space character...
		// expects http://raw.github.com/jeanfabre/PlayMaker--Unity--UI/master/PlayMaker/Ecosystem/Custom%20Packages/uGui/uGuiProxyFull.unitypackage?uid=1
	}
}
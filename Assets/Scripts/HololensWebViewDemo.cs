using UnityEngine;
using System;
using Vuplex.WebView;

class HololensWebViewDemo : MonoBehaviour {

    WebViewPrefab _webViewPrefab;

    void Start() {

        // Create a 0.6 x 0.3 instance of the prefab.
        _webViewPrefab = WebViewPrefab.Instantiate(0.6f, 0.3f);
        _webViewPrefab.transform.parent = transform;
        _webViewPrefab.transform.localPosition = new Vector3(0, 0.2f, 1);
        _webViewPrefab.transform.localEulerAngles = new Vector3(0, 180, 0);
        _webViewPrefab.Initialized += (sender, e) => {
            _webViewPrefab.WebView.LoadUrl("https://bing.com");
        };

        // Add an on-screen keyboard under the main webview.
        var keyboard = Keyboard.Instantiate();
        keyboard.transform.parent = _webViewPrefab.transform;
        keyboard.transform.localPosition = new Vector3(0, -0.31f, 0);
        keyboard.transform.localEulerAngles = new Vector3(0, 0, 0);
        keyboard.InputReceived += (sender, e) => {
            _webViewPrefab.WebView.HandleKeyboardInput(e.Value);
        };
    }
}

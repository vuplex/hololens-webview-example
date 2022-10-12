using UnityEngine;
using Vuplex.WebView;

class HololensWebViewDemo : MonoBehaviour {

    WebViewPrefab _webViewPrefab;

    async void Start() {

        // Create a 0.6 x 0.3 instance of the prefab.
        // https://developer.vuplex.com/webview/WebViewPrefab#Instantiate
        _webViewPrefab = WebViewPrefab.Instantiate(0.6f, 0.3f);
        _webViewPrefab.transform.parent = transform;
        _webViewPrefab.transform.localPosition = new Vector3(0, 0.2f, 1);
        _webViewPrefab.transform.localEulerAngles = new Vector3(0, 180, 0);

        // Add an on-screen keyboard under the webview.
        // https://developer.vuplex.com/webview/Keyboard
        var keyboard = Keyboard.Instantiate();
        keyboard.transform.parent = _webViewPrefab.transform;
        keyboard.transform.localPosition = new Vector3(0, -0.31f, 0);
        keyboard.transform.localEulerAngles = Vector3.zero;

        // Wait for the prefab to initialize because its WebView property is null until then.
        // https://developer.vuplex.com/webview/WebViewPrefab#WaitUntilInitialized
        await _webViewPrefab.WaitUntilInitialized();

        // After the prefab has initialized, you can use the IWebView APIs via its WebView property.
        // https://developer.vuplex.com/webview/IWebView
        _webViewPrefab.WebView.LoadUrl("https://bing.com");
    }
}

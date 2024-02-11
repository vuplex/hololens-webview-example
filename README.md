# Hololens WebView Example

This Unity project demonstrates how to use the [Vuplex 3D WebView asset](https://developer.vuplex.com/webview/overview) with Hololens. It includes Microsoft's [Mixed Reality Toolkit (MRTK)](https://github.com/microsoft/MixedRealityToolkit-Unity), so the only thing you must import [3D WebView for UWP / Hololens](https://store.vuplex.com/webview/uwp).

<p align="center">
  <img alt="demo" src="./demo.gif" width="640">
</p>

## Building for Hololens 1 and 2

- The project is already set up for Hololens 2 by default. So, if you're targeting Hololens 2, all you need to do is import [3D WebView for UWP / Hololens](https://store.vuplex.com/webview/uwp) and then build the HololensWebViewDemo scene.
- If you're targeting Hololens 1 instead, you must also do the following:
    - Change the project architecture from ARM64 to x86
    - Update the HololensWebViewDemo scene's MixedRealityToolkit object to use a Hololens 1 configuration profile (e.g. DefaultHololens1ConfigurationProfile).
- For tips on deploying the project to a headset, see [this Microsoft article](https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio).

## Steps taken to create this project

1. Created a new project with Unity 2020.3.24.
2. [Installed MRTK v2.8.0](https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/new-openxr-project-with-mrtk).
3. Imported [3D WebView for UWP / Hololens](https://store.vuplex.com/webview/uwp) ([.gitignore](./.gitignore#L74)).
4. Created a new scene named HololensWebViewDemoScene that combines 3D WebView's [WebViewPrefab](https://developer.vuplex.com/webview/WebViewPrefab) and [Keyboard](https://developer.vuplex.com/webview/Keyboard) components with the needed components from MRTK.
5. Applied the following settings to the scene's MixedRealityToolkit object:
    - Cloned the DefaultHololens2ConfigurationProfile profile in order to disable the diagnostics overlay
6. UWP Build Settings:
    - Architecture: ARM64
    - Build Type: XAML Project (this is required to support webviews)
    - Build and run on: USB Device
7. UWP Player Settings:
    - Other Settings:
        - Auto Graphics API: disabled
        - Graphics APIs: Direct3D11
        - Graphics Jobs: disabled (required for Hololens 2)
        - Active Input Handling: Both
    - Publishing Settings:
        - Capabilities:
            - InternetClient
            - SpatialPerception
    - XR Plug-In Management:
        - Enable the OpenXR provider
        - Under the OpenXR provider, enable "Microsoft Hololens feature group"

## Using CanvasWebViewPrefab

The HololensWebViewDemo scene uses a [WebViewPrefab](https://developer.vuplex.com/webview/WebViewPrefab), but you can make the following modifications to the scene to make it use a [CanvasWebViewPrefab](https://developer.vuplex.com/webview/CanvasWebViewPrefab) instead:

1. Copy the Canvas object from 3D WebView's CanvasWorldSpaceDemo scene, paste it into the HololensWebViewDemo scene, and place it at the position (0, 0, 1).
2. Disable the scene's SceneManager game object (because it contains the script that instantiates a WebViewPrefab).
3. On the Canvas object, click the "Convert to MRTK Canvas" button.

After these modifications, you can build the scene and interact with the canvas's CanvasWebViewPrefab and CanvasKeyboard.

## License

The Mixed Reality Toolkit library located in the Assets/MRTK directory is Copyright © Microsoft Corporation and is licensed under the MIT License.

All other code and assets are Copyright © Vuplex, Inc and licensed under the MIT License.

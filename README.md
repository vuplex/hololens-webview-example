# Hololens WebView Example

This Unity project demonstrates how to use the [Vuplex 3D WebView asset](https://developer.vuplex.com/webview/overview) with Hololens. It includes Microsoft's [Mixed Reality Toolkit (MRTK)](https://github.com/microsoft/MixedRealityToolkit-Unity), so the only thing you must import is the [3D WebView for UWP / Hololens](https://developer.vuplex.com/webview/overview) asset.

## Steps taken to create this project

1. Created a new project with Unity 2019.3.4.
2. Installed [MRTK v2.3.0](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases).
3. Installed 3D WebView for UWP / Hololens ([.gitignore](./.gitignore#L74)).
4. Created a new scene named OculusWebViewDemoScene that combines 3D WebView's [WebViewPrefab](https://developer.vuplex.com/webview/WebViewPrefab) and [Keyboard](https://developer.vuplex.com/webview/Keyboard) components with the needed components from MRTK.
5. Applied the following settings to the scene's MixedRealityToolkit object:
    - Cloned the DefaultHololens1ConfigurationProfile profile in order to disable the diagnostics overlay
6. UWP Build Settings:
    - Architecture: x86
    - Build Type: XAML Project (this is required to support webviews)
    - Build and run on: USB Device
7. UWP Player Settings:
    - Other Settings:
        - Auto Graphics API: disabled
        - Graphics APIs: Direct3D11
        - Scripting Define Symbols: VUPLEX_MRTK (this enables 3D WebView's compatibility with MRTK's input system)
    - Publishing Settings:
        - Capabilities:
            - InternetClient
            - SpatialPerception
    - XR Settings:
        - Virtual Reality Supported: enabled
        - Virtual Reality SDKs: Windows Mixed Reality
        - Stereo Rendering Mode: Multi-Pass

## License

The Mixed Reality Toolkit library located in the Assets/MixedRealityToolkit* directories is Copyright © Microsoft Corporation and is licensed under the MIT License.

All other code and assets are Copyright © Vuplex, Inc and licensed under the MIT License.

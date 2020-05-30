# Hololens WebView Example

This Unity project demonstrates how to use the [Vuplex 3D WebView asset](https://developer.vuplex.com/webview/overview) with Hololens. It includes Microsoft's [Mixed Reality Toolkit (MRTK)](https://github.com/microsoft/MixedRealityToolkit-Unity), so the only thing you must import is the [3D WebView for UWP / Hololens](https://assetstore.unity.com/packages/tools/gui/3d-webview-for-uwp-hololens-166365) asset.

<p align="center">
  <img alt="demo" src="./demo.gif" width="640">
</p>

## Building for Hololens 1 and 2

- The project is already set up for Hololens 2 by default. So, if you're targeting Hololens 2, all you need to do is import 3D WebView for UWP / Hololens to the Assets/Vuplex directory and then build the HololensWebViewDemo scene.
- If you're targeting Hololens 1 instead, you must also do the following:
    - Change the project architecture from ARM to x86
    - Update the HololensWebViewDemo scene's MixedRealityToolkit object to use a Hololens 1 configuration profile (e.g. CustomHololens1ConfigurationProfile).
- For tips on deploying the project to a headset, see [this Microsoft article](https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio).

## Steps taken to create this project

1. Created a new project with Unity 2019.3.4.
2. Installed [MRTK v2.3.0](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases).
3. Installed 3D WebView for UWP / Hololens ([.gitignore](./.gitignore#L74)).
4. Created a new scene named OculusWebViewDemoScene that combines 3D WebView's [WebViewPrefab](https://developer.vuplex.com/webview/WebViewPrefab) and [Keyboard](https://developer.vuplex.com/webview/Keyboard) components with the needed components from MRTK.
5. Applied the following settings to the scene's MixedRealityToolkit object:
    - Cloned the DefaultHololens2ConfigurationProfile profile in order to disable the diagnostics overlay
6. UWP Build Settings:
    - Architecture: ARM
    - Build Type: XAML Project (this is required to support webviews)
    - Build and run on: USB Device
7. UWP Player Settings:
    - Other Settings:
        - Auto Graphics API: disabled
        - Graphics APIs: Direct3D11
        - Graphics Jobs: disabled (required for Hololens 2)
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

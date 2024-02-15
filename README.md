# Split CYMK
## About
Split CMYK allows for a user to get CMYK values from a Grasshopper Colour datatype (RGB). Also allows for "rich black" for darker results with certain materials.

![Static Badge](https://img.shields.io/badge/Build-v0.1.1-green)
![GitHub Release Date - Published_At](https://img.shields.io/github/release-date/dkeners/SplitCMYK?label=Last%20release%20date%3A%20)
 ![GitHub last commit (branch)](https://img.shields.io/github/last-commit/dkeners/SplitCMYK/develop?label=Lastest%20development:)

 ![Static Badge](https://img.shields.io/badge/-4.8-blue?logo=csharp) ![Static Badge](https://img.shields.io/badge/--%23512BD4?logo=dotnet)
 ![Static Badge](https://img.shields.io/badge/-Rhino%207,%208-black?logo=rhinoceros)

![CMYKSplit](https://github.com/dkeners/SplitCMYK/assets/25158625/22e03386-c897-4244-b04b-b752e6ac5c3c)

## Installation
### PackageManager
1. In Rhino run the PackageManager command
2. Search for SplitCMYK
3. Select version and install
4. Restart Grasshopper
### Food4Rhino
Navigate to [Split CMYK](https://www.food4rhino.com/en/app/split-cmyk) on Food4Rhino.
1. Log in using your Rhino account and download the version you would like
2. In Grasshopper go to `File->Special Folders->Components Folder`
3. Unzip the downloaded folder to the Grasshopper Plugin folder
### GitHub Releases
SplitCMYK can be installed by going to [Releases](https://github.com/dkeners/SplitCMYK/releases) and downloading the version you would like.
1. In Grasshopper go to `File->Special Folders->Components Folder`
2. Unzip the `SplitCMYK-X-X-X.zip` folder to the Grasshopper Plugin folder

## Usage
Refer to the file [Example.gh](https://github.com/dkeners/SplitCMYK/blob/main/SplitCMYK/Tests/Example.gh) for an example of the component.

Rich black sets C = .6, M and Y = .4, and K = 1. This absorbs more wavelengths of light with some materials and provides an objectively richer, darker black. To use, right click the component and click *Toggle Rich Black*. To turn off click the button again. The message below the component will indicate the state of the component.

## License
See [LICENSE](LICENSE.txt) for details.

## Feedback & Contributing
Feel free to provide feedback, suggestions, or report issues. Please reach out about contributing. 

## Change Log
### [0.1.1] - 2024-02-10
#### Changed
- Targeted Rhinocommon SDK is 7.0 now instead of 8.0

### [0.1.0] - 2024-02-10
#### Added
- Split CMYK Component
- Split CMYK Info

# GateSwitchWay

GateSwitchWay is a simple Windows desktop application that allows users to switch their network gateway with a single click. The application provides the following features:

- **One-Click Gateway Switching**: Easily switch between your native and alternative network gateway settings.
- **Auto-Start**: Option to enable the application to start automatically with Windows.
- **Start Hidden**: Option to start the application minimized to the system tray.
- **Auto Alter**: Automatically switch to the alternative network settings on startup.
- **System Tray Integration**: Control the application from the system tray with single and double-click actions.
- **Dark Mode Support**: Context menu adapts to the system's light or dark theme.

> Note: This fork is an experiment to have the repository largely maintained by a supervised Copilot (AI-assisted). Human reviewers will supervise and review changes before merging. Contributions are welcome; please follow the contribution guidelines.

## Settings

The application allows users to configure the following settings:
- **StartHidden**: Start the application minimized to the system tray.
- **AutoAlter**: Automatically switch to the alternative network settings on startup.
- **Alternative Network Settings**: Configure alternative IPv4/IPv6 gateway and DNS settings.
- **Native Network Settings**: Configure native IPv4/IPv6 gateway and DNS settings.

## Usage

1. **Switch Gateway**: Click the system tray icon to toggle between native and alternative network settings.
2. **Open Main Window**: Double-click the system tray icon to open the main window.
3. **Auto-Start**: Enable or disable auto-start from the context menu.
4. **Start Hidden**: Enable or disable starting the application hidden from the context menu.
5. **Auto Alter**: Enable or disable auto alter from the context menu.

## Requirements

- Windows operating system
- .NET 8 (for update packages only - full install includes .NET runtime)

## Installation

Choose the appropriate package based on your needs:

### Full Install (New Installation)
**Size:** ~60MB | **Requirements:** None

1. Go to [`Actions`](https://github.com/lsd-techno/GateSwitchWay/actions) page
2. Click on the latest successful workflow run
3. Download the `full-install` artifact
4. Extract and run `GateSwitchWay-{version}-full.exe` as Administrator

*Use this option if you don't have .NET 8 installed or for clean installations.*

### Update Package (Existing Installation)
**Size:** ~0.5MB | **Requirements:** .NET 8 runtime pre-installed

1. Go to [`Actions`](https://github.com/lsd-techno/GateSwitchWay/actions) page
2. Click on the latest successful workflow run
3. Download the `update-package` artifact
4. Extract and run `GateSwitchWay-{version}-update.exe` as Administrator

*Use this option for updates if you already have .NET 8 installed. Downloads 120x faster than full install.*

### .NET 8 Runtime Installation
If you choose the update package but don't have .NET 8 installed:
1. Download .NET 8 Runtime from [Microsoft's official site](https://dotnet.microsoft.com/download/dotnet/8.0)
2. Install the **Desktop Runtime** (not just the runtime)
3. Then use the update package for future updates

### Package Comparison

| Feature | Full Install | Update Package |
|---------|-------------|----------------|
| **Size** | ~60MB | ~0.5MB |
| **Download Time** | Slower | 120x faster |
| **Requirements** | None | .NET 8 runtime |
| **Use Case** | New installations | Updates |
| **Includes .NET Runtime** | ✅ Yes | ❌ No |
| **Offline Installation** | ✅ Yes | ❌ Requires .NET 8 |

**Recommendation:** Use full install for your first installation, then switch to update packages for future updates to save bandwidth and time.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.txt) file for details.

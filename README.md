# 🧪 DotNet Learning Lab

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![CI](https://github.com/millenniumsingha/dotnet-learning-lab/actions/workflows/ci.yml/badge.svg)
![License](https://img.shields.io/badge/license-MIT-blue)
![Status](https://img.shields.io/badge/status-active-green)

> **Download Demos:** Want to try these apps without installing .NET?  
> 👉 [**Download the latest playable demos here!**](https://github.com/millenniumsingha/dotnet-learning-lab/releases/latest)
> *(Look for `WeatherTrend-Demo.zip`, `MusicalInstrument-Demo.zip`, etc.)*

**DotNet Learning Lab** is a unified playground for modern .NET 10 development, consolidating legacy experiments into a clean, structured monorepo. It serves as a reference implementation for migrating Windows desktop apps (WPF, WinForms) and console tools to the latest .NET ecosystem.

---

## 📚 Documentation
- **[🏗️ Architecture](ARCHITECTURE.md)**: Overview of the solution structure and key technologies.
- **[🤝 Contributing](CONTRIBUTING.md)**: Guide for developers.
- **[📝 Changelog](CHANGELOG.md)**: Release history.

---

## 🚀 Projects

| Project | Type | Description | State |
|:---|:---|:---|:---|
| **[Chess](src/Chess)** | Library | Core chess logic and move validation. | ✅ v1.2 |
| **[EightQueens](src/EightQueens)** | Console | Recursive backtracking solver for the 8-Queens problem. | ✅ v1.2 |
| **[GeoLocator](src/GeoLocator)** | WinForms | GPS coords via `Windows.Devices.Geolocation` & HERE Maps. | ✅ v1.1 |
| **[MusicalInstrument](src/MusicalInstrument)** | WinForms | Audio synthesis using `NAudio` sine wave generator. | ✅ v1.1 |
| **[WeatherTrend](src/WeatherTrend)** | WPF | Historical temp analysis using `LiveCharts2` visualization. | ✅ v1.2 |

---

## 📁 Project Structure

```
DotNetLearningLab/
├── src/                 # Source code for all apps
│   ├── Chess/           # .NET 10 Library
│   ├── WeatherTrend/    # WPF App
│   └── ...
├── tests/               # xUnit test projects
├── docs/                # Project documentation
├── .github/workflows/   # CI/CD pipelines
└── Directory.Build.props # Shared configuration
```

## 🧪 Testing

```powershell
# Run all tests
dotnet test

# Run specific project
dotnet test tests/EightQueens.Tests
```

## 🗺️ Roadmap

- **v1.0.0 (Current):** Migration to .NET 10, CI/CD setup, legacy cleanup.
- **Future:**
  - MAUI migration for cross-platform support.
  - Blazor implementation for Chess UI.
  - gRPC integration between components.

---

*Built with ❤️ for .NET enthusiasts*
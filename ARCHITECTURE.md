# Architecture Overview

## Solution Structure

The solution follows a standard .NET 10 structure with Central Package Management (CPM).

```mermaid
graph TD
    User([End User])

    subgraph Solution [DotNet Learning Lab]
        subgraph Apps [Applications - Desktop]
            WT[WeatherTrend<br/>WPF]
            MI[MusicalInstrument<br/>WinForms]
            GL[GeoLocator<br/>WinForms]
            EQ[EightQueens<br/>Console]
        end

        subgraph Libs [Core Libraries]
            Chess[Chess Logic]
        end
    end
    
    subgraph External [External Dependencies]
        LC[LiveCharts.Wpf]
        NA[NAudio]
        GPS[System.Device - Legacy]
    end

    %% Dependencies
    WT -->|Uses| LC
    MI -->|Uses| NA
    GL -.->|Migrated From| GPS
    EQ -->|Uses| Chess
    
    %% User Flows
    User -->|Runs| WT
    User -->|Runs| MI
    User -->|Runs| GL
    User -->|Runs| EQ
```

```
DotNetLearningLab/
├── src/
│   ├── Chess/               # .NET 10 Class Library (Game Logic)
│   ├── EightQueens/         # Console App (Backtracking Algorithm)
│   ├── GeoLocator/          # WinForms App (Windows.Devices.Geolocation)
│   ├── MusicalInstrument/   # WinForms App (NAudio)
│   └── WeatherTrend/        # WPF App (LiveCharts)
├── tests/
│   ├── Chess.Tests/         # xUnit Tests for Chess
│   ├── EightQueens.Tests/   # xUnit Tests for EightQueens
│   └── ...
├── docs/                    # Documentation
├── Directory.Build.props    # Shared Build Properties
├── Directory.Packages.props # CPM Dependencies
└── DotNetLearningLab.sln    # Solution File
```

## Key Technologies

- **Core:** .NET 10 (C# 14)
- **UI Frameworks:** WPF, WinForms
- **Libraries:**
  - `LiveCharts.Wpf` (Charting)
  - `NAudio` (Sound Generation)
  - `Windows.Devices.Geolocation` (GPS/Location)
- **Testing:** xUnit, Coverlet

## Design Principles

- **modernization:** All legacy .NET Framework code has been ported to .NET 10.
- **Dependency Management:** Centralized via `Directory.Packages.props`.
- **Quality Assurance:** CI/CD pipeline enforces build, test, and CodeQL security analysis.

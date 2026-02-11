# DotNet Learning Lab

[![CI](https://github.com/millenniumsingha/dotnet-learning-lab/actions/workflows/ci.yml/badge.svg)](https://github.com/millenniumsingha/dotnet-learning-lab/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/10.0)

A collection of legacy C# projects migrated to modern **.NET 10**.

## Projects

| Project | Type | Description | Status |
| :--- | :--- | :--- | :--- |
| **Chess** | Library | Core chess logic and board representation. | ✅ Migrated |
| **EightQueens** | Console | Solves the Eight Queens puzzle using the Chess library. | ✅ Migrated |
| **GeoLocator** | Console | Fetches maps using HERE Maps API (replacing `System.Device`). | ✅ Migrated |
| **MusicalInstrument** | WinForms | Generates sine waves using `NAudio` and mouse input. | ✅ Migrated |
| **WeatherTrend** | WPF | Visualizes barometric pressure using `LiveCharts` (v0.9.7 compat). | ✅ Migrated |

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Windows (for WinForms/WPF apps)

### Build
```bash
dotnet build
```

### Test
```bash
dotnet test
```

## Migration Notes
This repository was consolidated from multiple legacy projects.
- **Legacy Code:** `old_projects_migration/` (Deleted after migration).
- **Architecture:** Centralized solution with shared logic where applicable.
- **Tooling:** GitHub Actions for CI, CodeQL for security, Renovate/Dependabot for dependencies.
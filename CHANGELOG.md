# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v1.2.1] - 2026-02-19

### Fixed
- **WeatherTrend:** Fixed blank chart in published builds by removing conflicting `UnitWidth` and `MinStep` axis properties (#63).
- **WeatherTrend:** Fixed date format typo in X-axis labels (`MM:dd` → `MM-dd`).
- **CI/CD:** Added `IncludeAllContentForSelfExtract` to single-file publish for reliable SkiaSharp native library bundling.

## [v1.2.0] - 2026-02-19

### Added
- **Refactor:** Modernized `ChessBoard.cs` with file-scoped namespaces, XML documentation, and collection expressions.

### Changed
- **WeatherTrend:** Migrated from legacy `LiveCharts` (v0.9) to `LiveCharts2` (v2.0.0-rc4.5) for improved performance and modern API usage.
- **Build:** Enforced strict code style and analysis (`<AnalysisLevel>latest-recommended</AnalysisLevel>`) in `Directory.Build.props`.

### Fixed
- **Chess:** Corrected validation logic in `ChessBoard.cs` to properly detect invalid board configurations (#52).

## [v1.1.4] - 2026-02-15

### Fixed
- **CI/CD:** Release demo zips now include companion files (e.g. `pond_data/`) alongside the `.exe`, fixing WeatherTrend runtime file-not-found errors.

## [v1.1.3] - 2026-02-15

### Fixed
- **WeatherTrend:** Fixed single-file path resolution by using `Environment.ProcessPath` instead of `AppContext.BaseDirectory`, which incorrectly resolves to a temp extraction folder.

## [v1.1.2] - 2026-02-13

### Fixed
- **WeatherTrend:** Resolved startup crash in single-file builds by using `AppContext.BaseDirectory` for reliable path resolution.
- **WeatherTrend:** Added global exception handler to catch and display startup errors.

## [v1.1.1] - 2026-02-13

### Fixed
- **EightQueens:** Added pause on exit so results are visible in console.
- **GeoLocator:** Changed map save location to `%TEMP%` to fix `Access Denied` crashes.
- **WeatherTrend:** Fixed missing content files in single-file (`.exe`) builds.

## [v1.1.0] - 2026-02-13

### Added
- **Automated Demos:** Implemented "Click-to-Run" release workflow (`release_demos.yml`) that builds and attaches self-contained `.exe` files to GitHub Releases.
- **Documentation:** Added Architecture Diagram to `ARCHITECTURE.md` visualizing solution structure and dependencies.
- **Documentation:** Added "Download Demos" section to `README.md`.

### Fixed
- **GeoLocator:** Replaced deprecated HERE Maps API with functional placeholder service to prevent crashes.
- **GeoLocator:** Fixed crash on `Console.ReadKey` in non-interactive environments.
- **Cleanup:** Removed stale branches and legacy build artifacts.

## [v1.0.0] - 2026-02-11

### Added
- **Repository:** Established .NET 10 solution structure with Central Package Management (`Directory.Packages.props`) and shared build props (`Directory.Build.props`).
- **CI/CD:** Added GitHub Actions workflows for Windows build, test, and CodeQL analysis.
- **Chess:** Migrated `Chess` class library to .NET 10.
- **EightQueens:** Migrated console application solving the 8-Queens problem.
- **GeoLocator:** Migrated WinForms application to use `System.Net.Http` and HERE Maps API (replacing deprecated `System.Device`).
- **MusicalInstrument:** Migrated WinForms application to `NAudio` for sine wave generation.
- **WeatherTrend:** Migrated WPF application to .NET 10 using `LiveCharts` (v0.9.7 compatible).
- **Documentation:** Added comprehensive `README.md` and `DATASET_INFO.md`.

### Removed
- **Legacy Code:** Deleted `old_projects_migration/` directory containing the original unmigrated source code.

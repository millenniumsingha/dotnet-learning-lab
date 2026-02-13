# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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

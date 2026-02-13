## Summary

Fix reliability issues in `v1.1.0` playable demos.

## Bugs

1.  **EightQueens:** Console app exits immediately, making results invisible.
2.  **GeoLocator:** Attempts to write to `System32` (restricted), causing `Access Denied` crash.
3.  **WeatherTrend:** Fails to start, likely due to missing content files in single-file bundle.

## Fixes

- **EightQueens:** Add `Console.ReadLine()` or specific "Press Enter to Exit" logic.
- **GeoLocator:** Save image to `%TEMP%` instead of relative path.
- **WeatherTrend:** Ensure `pond_data` is correctly embedded/extracted.

## Verification

- `dotnet publish` locally (single-file).
- Run `.exe` files in a clean environment.

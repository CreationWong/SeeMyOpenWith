# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```powershell
# Build (Debug)
dotnet build

# Build (Release)
dotnet build -c Release

# Run (requires admin — will prompt for elevation)
dotnet run

# Publish as self-contained single-file executable
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# Run tests — none exist (no test project)
```

## CI/CD

Defined in `.github/workflows/build.yml`:
- Triggers: push/PR to `main`/`master` on .cs/.csproj/.sln changes, plus manual `workflow_dispatch`
- Runs on `windows-latest`
- Uses MSBuild (not `dotnet build`) with NuGet restore
- Manual runs can optionally create a GitHub Release with build artifacts
- Build badge: `[![Build](https://github.com/CreationWong/SeeMyOpenWith/actions/workflows/build.yml/badge.svg?branch=main)](...)`

## Architecture Overview

**SeeMyOpenWith** is a Windows Forms app (.NET 9.0, C#) that reads and deletes "Open With" entries from `HKEY_CLASSES_ROOT\Applications`.

### Entry Flow (`src/Program.cs`)
1. Configures Serilog logging (console in Debug, rolling file to `logs/runLog.log`)
2. Checks if running as Administrator via `WindowsPrincipal`
3. If admin → launches `Main` form; if not → prompts to re-launch with `runas` verb

### Form Layer (`src/Main.cs` + `src/Main.Designer.cs`)
- `TabControl` with 3 tabs: **编辑** (Edit — main ListView), **设置** (Settings — open log folder), **关于** (About)
- ListView `listViewReg` has 4 columns: Program, Name, Description, Command
- Context menu: Refresh (F5), Modify (not implemented), Search with Bing, Delete
- Method name note: `FefreshListView` is a misspelling of "Refresh" — keep the existing name for consistency unless explicitly refactoring

### Module Layer (`src/module/`)
- **`ListViewDispose.cs`** — reads all subkeys under `HKCR\Applications`, retrieves `FriendlyAppName`, shell open description, and open command for each. Populates the ListView.
- **`RegIO.cs`** — deletes a subkey under `HKCR\Applications\<appName>` via `DeleteSubKeyTree()`

### Key Constraints
- **Requires Administrator privileges** for registry read/write on `HKEY_CLASSES_ROOT\Applications`
- All registry reads use `using` blocks for proper disposal
- The app uses Serilog for logging (file sink with hourly rolling, 5 retained files, console in Debug)
- App icon source is in `img/SeeMyOpenWith.aseprite` (Aseprite format)
- Solution targets `net9.0-windows10.0.17763.0` (requires Windows SDK 10.0.17763.0+)

### Obsolete/Vestigial Files
- `App.config` — .NET Framework 4.8 assembly binding redirects (leftover from earlier .NET Framework version)
- `packages.config` — legacy NuGet references (actual package refs are in `.csproj` now)
- `.csproj` explicitly removes any `src/Class/` paths — that directory was removed

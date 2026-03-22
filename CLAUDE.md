# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**docmgt** is a document management application built with:
- **Framework**: .NET Framework 4.5
- **Language**: C#
- **UI Technology**: WPF (Windows Presentation Foundation)

**Repository**: https://github.com/kimgong/docmgt.git

## Build & Run Commands

```bash
# Build the solution (Debug)
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" "E:\workspace\myrepo\docmgt\DocMgt.csproj" /t:Build /p:Configuration=Debug

# Build Release version
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" "E:\workspace\myrepo\docmgt\DocMgt.csproj" /t:Build /p:Configuration=Release

# Open in Visual Studio
DocMgt.sln
```

## Architecture

### Project Structure
```
DocMgt/
├── App.xaml / App.xaml.cs      # Application entry point
├── MainWindow.xaml / .cs       # Main window
├── Models/                     # Data models (Document, User, Category)
├── ViewModels/                 # MVVM ViewModels (ViewModelBase, RelayCommand, MainViewModel)
├── Views/                      # WPF Views (LoginView, DocumentListView)
├── Services/                   # Service layer (IApiService, ApiService)
├── Converters/                 # Value converters (InverseBooleanConverter, DateFormatConverter)
├── Helpers/                    # Helper classes (MessageBoxHelper)
├── Properties/                 # Assembly info
└── Resources/                  # Application resources
```

### MVVM Pattern
- **ViewModelBase**: Base class implementing `INotifyPropertyChanged`
- **RelayCommand**: `ICommand` implementation for binding commands
- Views use code-behind for event handling; can be migrated to full MVVM with bindings

### Related Documents
- `req.md` - Functional requirements
- `api.md` - Backend API interface definitions

## Development Notes

- Target framework: .NET Framework 4.5 (Windows only)
- UI components use WPF controls and XAML
- Follow WPF best practices for data binding and command patterns

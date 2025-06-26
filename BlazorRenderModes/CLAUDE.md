# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

### CSS Development
```bash
npm run build-css    # Compile SCSS to CSS for production
npm run watch-css    # Watch for SCSS changes during development
```

### .NET Development  
```bash
dotnet run          # Start the application (ports 5137 HTTP, 7108 HTTPS)
dotnet build        # Build the project
```

## Architecture Overview

This is a **Blazor Server-Side Rendering (SSR) application** on **.NET 9** that demonstrates different Blazor render modes. The application showcases three distinct rendering approaches:

### Render Mode Patterns

1. **Static SSR** (`TodoSsr.razor` at `/todo-ssr`)
   - No `@rendermode` directive
   - Server-side only rendering with form submissions
   - Use for SEO-optimized, content-heavy pages

2. **Interactive Server** (`Counter.razor` at `/counter`) 
   - `@rendermode InteractiveServer`
   - Real-time SignalR connection for dynamic interactions
   - Use for components requiring server-side state management

3. **Stream Rendering** (`Weather.razor` at `/weather`)
   - `@attribute [StreamRendering]`
   - Progressive rendering with loading states
   - Use for async data loading scenarios

### Component Architecture

- **Parameter-driven design**: Components use `[Parameter]` attributes for props
- **Event-based communication**: Parent-child interactions via `EventCallback<T>`
- **Conditional behavior**: Components adapt based on `IsReadOnly` and similar parameters
- **Bootstrap integration**: Heavy use of Bootstrap 5.3.3 classes and components

### Asset Management

- **SCSS Pipeline**: Source files in `Styles/app.scss` compile to `wwwroot/app.css`
- **Bootstrap**: Managed via npm (5.3.3), not CDN
- **Static Assets**: Uses .NET 9's `MapStaticAssets()` approach
- **Optimization**: Bootstrap files selectively excluded via .csproj to reduce bundle size

### Key Files Structure

```
Components/
├── App.razor           # Root HTML template with asset references
├── Layout/MainLayout   # Contains NavMenu, minimal container layout
├── Pages/              # Route components demonstrating different render modes
└── Todo/               # Reusable todo components for composition

Models/TodoItem.cs      # Simple POCO: Id, Title, IsCompleted, CreatedAt
Program.cs              # Configures Razor Components + Interactive Server mode
Styles/app.scss         # Custom SCSS with Bootstrap imports
```

### Development Workflow

1. **CSS Changes**: Run `npm run watch-css` to automatically recompile SCSS
2. **Component Development**: Components are designed to work across render modes
3. **Bootstrap Dependencies**: Bootstrap JS is included via `@Assets` in App.razor
4. **Asset Pipeline**: New .NET 9 static asset management handles optimization

### Navigation and Bootstrap

The `NavMenu.razor` uses Bootstrap 5 navbar with hamburger menu functionality. Bootstrap JavaScript is required for mobile menu toggle behavior and is included via the asset pipeline.

## Technical Notes

- **No README**: Codebase structure serves as primary documentation
- **Minimal Dependencies**: Only essential Blazor SSR packages
- **Component-First**: Emphasizes reusable, parameterized components over page-specific logic
- **Render Mode Strategy**: Different modes chosen based on interactivity requirements, not arbitrary decisions

## Project Challenges and Insights

- **Todo List Render Mode Exploration**
  - Attempting to build a todo list app across all render modes
  - Challenge: Static Server-Side Rendering (SSR) requires form submission for DELETE actions for each list item
  - Goal: Develop components that can be shared between different render modes while addressing SSR interaction limitations
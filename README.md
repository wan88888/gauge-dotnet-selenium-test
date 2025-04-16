# Gauge .NET Selenium Test Framework

[![.NET Selenium Tests](https://github.com/username/gauge-dotnet-selenium-test/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/username/gauge-dotnet-selenium-test/actions/workflows/dotnet-test.yml)

This is a web automation testing framework built with Gauge, .NET, and Selenium WebDriver. The framework demonstrates automated testing of the [SauceDemo](https://www.saucedemo.com/) website.

## Features

- Page Object Model (POM) design pattern for better maintainability
- Multi-browser support (Chrome, Firefox, Edge)
- Selenium WebDriver for browser automation
- Gauge for behavior-driven development and readable test specifications
- FluentAssertions for readable assertions
- Test categorization with tags
- Continuous Integration with GitHub Actions
- Headless browser testing support
- HTML test reports

## GitHub Actions Workflow

This project includes an optimized CI/CD pipeline using GitHub Actions for automated building and testing:

1. **build-and-test job**: A comprehensive job responsible for:
   - Building the project and verifying successful compilation
   - Running smoke tests to verify core functionality
   - Running regression tests in headless mode
   - Saving both test reports as artifacts

2. **deploy-docs job**:
   - Triggered only on pushes to main or master branches
   - Publishes test reports to GitHub Pages for team review

This pipeline design reduces duplicate work and improves efficiency while maintaining comprehensive testing.

You can view the latest test reports on GitHub Pages (once configured).

## Prerequisites

- .NET SDK 8.0 or later
- Gauge (https://gauge.org/get-started/)
- Chrome, Firefox, or Edge browser

## Setup

1. Clone this repository:
   ```
   git clone https://github.com/username/gauge-dotnet-selenium-test.git
   cd gauge-dotnet-selenium-test
   ```

2. Install Gauge:
   ```
   npm install -g @getgauge/cli
   gauge install dotnet
   gauge install html-report
   ```

3. Build the project:
   ```
   dotnet build
   ```

## Running Tests

Run all tests:
```
gauge run specs
```

Run only smoke tests:
```
gauge run --tags smoke specs
```

Run regression tests:
```
gauge run --tags regression specs
```

Run with a specific browser:
```
browser=firefox gauge run specs
```

Run in headless mode:
```
headless=true gauge run specs
```

## Project Structure

- `Framework/`: Core framework components
  - `Config/`: Configuration management
  - `Driver/`: WebDriver management
  - `Pages/`: Page Object classes (POM pattern)
- `Steps/`: Step implementation classes organized by functionality
- `Hooks/`: Gauge hooks for setup/teardown
- `specs/`: Gauge specification files
- `.github/workflows/`: GitHub Actions workflow files

## Configuration

Browser and other settings can be configured in `env/default/driver.properties`:

```
# Browser configuration
browser=chrome  # Options: chrome, firefox, edge
headless=false  # Run in headless mode

# URLs
baseUrl=https://www.saucedemo.com

# Timeout settings
elementTimeout=30
pageLoadTimeout=60
scriptTimeout=30
```

## Test Categories

- **smoke**: Critical path tests that verify core functionality
- **regression**: Comprehensive tests that verify the entire application
- **cart**: Tests related to shopping cart functionality
- **sorting**: Tests related to product sorting functionality
- **user-accounts**: Tests related to different user account types

## Contributing

1. Fork the project
2. Create your feature branch: `git checkout -b feature/my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin feature/my-new-feature`
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 
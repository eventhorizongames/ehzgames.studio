param(
    [string]
    [ValidateSet(
        "clean",
        "restore",
        "build",
        "watch",
        "run",
        "format",
        "check",
        "test",
        "publish",
        "publish:serve"
    )]
    $Command,
    [string] $PactUrl,
    [string] $Configuration = "Release"
)

# Base Env Varaiables - Override with .entry-env file
$serverProject = "./Server/Server.csproj"

switch ($Command) {
    "clean" {
        dotnet clean
    }
    "restore" {
        dotnet restore --no-cache
    }
    "build" {
        dotnet build
    }
    "watch" {
        dotnet watch --project $serverProject
    }
    "run" {
        dotnet run --project $serverProject
    }
    "format" { 
        dotnet csharpier .
    }
    "check" {
        dotnet build --no-incremental -c $Configuration
        dotnet csharpier --check .
    }
    "test" { 
        # dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info $testsProject
    }
    "publish" { 
        ./publish.ps1
    }
    "publish:serve" {
        ./entry.ps1 publish
        dotnet serve -d="./output/wwwroot"
    }
    Default {
        Write-Output "Invalid Command"
    }
}
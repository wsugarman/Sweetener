param
(
    [Parameter(Mandatory=$True)]
    [string]
    $ProjectName,

    [Parameter(Mandatory=$True)]
    [string]
    $BuildConfiguration,

    [Parameter(Mandatory=$True)]
    [string]
    $PackageVersion,

    [Parameter(Mandatory=$True)]
    [string]
    $KeyVaultUrl,

    [Parameter(Mandatory=$True)]
    [string]
    $KeyVaultCertificateName,

    [Parameter(Mandatory=$True)]
    [string]
    $KeyVaultTenantId,

    [Parameter(Mandatory=$True)]
    [string]
    $KeyVaultClientId,

    [Parameter(Mandatory=$True)]
    [string]
    $KeyVaultClientSecret,

    [Parameter(Mandatory=$False)]
    [string]
    $TimestampUrl = "http://timestamp.digicert.com",

    [Parameter(Mandatory=$False)]
    [string]
    $DotNetTools = "tools",

    [Parameter(Mandatory=$False)]
    [string]
    $NuGetConfig = "NuGet.config"
)

# Turn off trace and stop on any error
Set-PSDebug -Off
$ErrorActionPreference = "Stop"

# Sign Package using NuGetKeyVaultSignTool
& dotnet tool install "NuGetKeyVaultSignTool" --version "3.1.6" --tool-path $DotNetTools --configfile $NuGetConfig

$nuGetKeyVaultSignTool = [System.IO.Path]::Combine($DotNetTools, "NuGetKeyVaultSignTool.exe")
$package               = [System.IO.Path]::Combine("src", $ProjectName, "bin", $BuildConfiguration, "$ProjectName.$PackageVersion.nupkg")

if (![System.IO.File]::Exists($package))
{
    throw [System.IO.FileNotFoundException]::new("Cannot find '$package'")
}

& $nuGetKeyVaultSignTool sign $package `
  -fd sha256 `
  -tr $TimestampUrl `
  -td sha256 `
  -kvu $KeyVaultUrl `
  -kvt $KeyVaultTenantId `
  -kvi $KeyVaultClientId `
  -kvs $KeyVaultClientSecret `
  -kvc $KeyVaultCertificateName

if (!$?)
{
    throw [Exception]::new("NuGetKeyVaultSignTool returned exit code '$LastExitCode'")
}
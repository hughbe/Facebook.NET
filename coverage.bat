set packages=%userprofile%\.nuget\packages
set opencover=%packages%\opencover\4.6.519\tools\OpenCover.Console.exe
set xunit=%packages%\xunit.runner.console\2.2.0\tools\xunit.console.exe
set tests_project=%cd%\src\Facebook.NET.Tests\Facebook.NET.Tests.csproj
set tests=%cd%\src\Facebook.NET.Tests\bin\Debug\netcoreapp1.1\Facebook.NET.Tests.dll
set report_generator=%packages%\reportgenerator\2.5.7\tools\ReportGenerator.exe

set coverage_directory=%cd%\resources\coverage
mkdir coverage_directory

set report_name=resources\coverage\coverage.xml
set report_path=resources\coverage

%opencover% -target:"C:/Program Files/Dotnet/dotnet.exe" -output:"%report_name%" -targetargs:"test %tests_project%" -filter:"+[*]* -[*.Tests]* -[xunit.*]*" -register:user
%report_generator% -reports:"%report_name%" -targetdir:"%report_path%"

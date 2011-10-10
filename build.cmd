%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild Library\Recurly.csproj /p:Configuration=Release
%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild Test\Recurly.Test.csproj /p:Configuration=Release

Dependencies\NUnit\nunit-console /fixture:Recurly.Test.VerificationTest Test\bin\Release\Recurly.Test.dll

SET RDIR=%~dp0

ECHO Your Recurly library is located at %RDIR%Library\bin\Release\Recurly.dll
PAUSE
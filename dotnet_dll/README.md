build
※cmdかpwshで実行(bashやshではエラーで実行不可)
```
dotnet publish /p:NativeLib=Shared /p:SelfContained=true -r win-x64 -c Release
```

参考情報

Compiling with Native AOT
https://github.com/dotnet/runtime/blob/main/src/coreclr/nativeaot/docs/compiling.md

Building Native Libraries with NativeAOT
https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary
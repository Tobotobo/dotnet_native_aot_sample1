# .NET 7 Preview 3 Native AOT Sample1

## 概要
- NativeAOTとはCやGo、Rustなどと同様にネイティブのdllやexeをC#のソースから作る技術のこと
- .NET 7 Preview 2 で実験的なプロジェクトからメインラインに移行した
- 本リポジトリでは、以下のサンプルを作成している
  1. NativeAOTを使ってC#からネイティブのdllを作成
  2. C#のDLLImportで作成したdllの関数を呼び出し
  3. GoのLoadDllで作成したdllの関数を呼び出し

## 実行手順

1. dotnet_dll の build.md に従いdllを作成  
   ※bin/Release/net7.0/win-x64/native に作成される
2. dotnet_console の bin/Debug/net7.0 に1.のdllをコピーし ```dotnet run``` する  
   ※3と出力されたら成功
3. go_console の直下に1.のdllをコピーし ```go run main.go``` する  
   ※3と出力されたら成功

## 対象のプロジェクトでNativeAOTを有効にする手順
※ほとんどブログの内容ままです。  
1. nuget.config ファイルを作成
```
dotnet new nugetconfig
```
2. add key の部分に以下を追加 ※元々あるnugetのものと2行になる
```xml
<add key="dotnet7" value="https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet7/nuget/v3/index.json" />
```
3. ILCompilerを追加
```
dotnet add package Microsoft.DotNet.ILCompiler -v 7.0.0-*
```
4. ビルド  
コンソールアプリの場合
```
dotnet publish -r win-x64 -c Release
```
クラスライブラリの場合
```
dotnet publish /p:NativeLib=Shared /p:SelfContained=true -r win-x64 -c Release
```
5.クラスライブラリで公開する関数の書き方
```cs
using System.Runtime.InteropServices;

namespace dotnet_dll;

public class Class1
{
    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
```
※文字列を返す方法はまだ調べてない。

## 環境
```
>ver
Microsoft Windows [Version 10.0.19043.1645]

>dotnet --version
7.0.100-preview.3.22179.4

>go version
go version go1.17.2 windows/amd64
```

## 参考情報
Announcing .NET 7 Preview 3  
https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-3/

Announcing .NET 7 Preview 2 – The New, ‘New’ Experience  
https://devblogs.microsoft.com/dotnet/announcing-dotnet-7-preview-2/

Compiling with Native AOT  
https://github.com/dotnet/runtime/blob/main/src/coreclr/nativeaot/docs/compiling.md

Building Native Libraries with NativeAOT  
https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary

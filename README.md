# .NET 7 Preview 3 Native AOT Sample1

## 概要
- NativeAOTとはCやGo、Rustなどと同様にネイティブのdllやexeをC#のソースから作る技術のこと
- .NET 7 Preview Preview 2 で実験的なプロジェクトからメインラインに移行した
- 本リポジトリでは、以下のサンプルを作成している
  1. NativeAOTを使ってC#からネイティブのdllを作成
  2. C#のDLLImportで作成したdllの関数を呼び出し
  3. GoのLoadDllで作成したdllの関数を呼び出し

## 実行手順

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
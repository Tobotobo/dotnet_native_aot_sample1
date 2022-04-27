package main

import (
	"fmt"
	"syscall"
)

func main() {
	dotnet_dll, err := syscall.LoadDLL("dotnet_dll.dll")
	if err != nil {
		panic(err)
	}
	defer dotnet_dll.Release()

	add, err := dotnet_dll.FindProc("add")
	if err != nil {
		panic(err)
	}
	ret, _, _ := add.Call(1, 2)

	fmt.Println(ret)
}

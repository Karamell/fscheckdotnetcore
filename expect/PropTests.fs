module PropTests

// the ExpectoFsCheck module is auto-opened by this
// the configuration record is in the Expecto namespace in the core library
open Expecto

let config = { FsCheckConfig.defaultConfig with maxTest = 10000 }
[<Tests>]
let properties =
  testList "FsCheck samples" [
    testProperty "Addition is commutative" <| fun a b ->
      a + b = b + a

    testProperty "Reverse of reverse of a list is the original list" <|
      fun (xs:list<int>) -> List.rev (List.rev xs) = xs

    // you can also override the FsCheck config
    testPropertyWithConfig config "Product is distributive over addition" <|
      fun a b c ->
        a * (b + c) = a * b + a * c
  ]

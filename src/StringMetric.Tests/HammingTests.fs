module StringMetric.Tests.HammingTests

open NUnit.Framework
open StringMetric

let (==>) actual expected =
    match actual = expected with
    | true -> ()
    | false -> failwithf "\nactual: %A\nexpected: %A" actual expected


[<Test>]
let ``preconditions``() =
   Hamming.compare null null ==> None
   Hamming.compare "" "" ==> None
   Hamming.compare "abc" "xy" ==> None

[<Test>]
let ``metric``() =
    Hamming.compare "0000000" "0101010" ==> Some 3
    Hamming.compare "0000000" "1111111" ==> Some 7
    Hamming.compare "0000000" "0000000" ==> Some 0

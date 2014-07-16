module StringMetric.Tests.HammingTests

open NUnit.Framework
open StringMetric

let (==>) actual expected =
    match actual = expected with
    | true -> ()
    | false -> failwithf "\nactual: %A\nexpected: %A" actual expected


[<Test>]
let ``preconditions``() =
   Hamming.metric null null ==> None
   Hamming.metric "" "" ==> None
   Hamming.metric "abc" "xy" ==> None

[<Test>]
let ``metric``() =
    Hamming.metric "0000000" "0101010" ==> Some (4.0 / 7.0)
    Hamming.metric "0000000" "1111111" ==> Some 0.0
    Hamming.metric "0000000" "0000000" ==> Some 1.0

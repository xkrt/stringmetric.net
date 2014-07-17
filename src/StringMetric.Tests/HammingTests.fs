module StringMetric.Tests.HammingTests

open NUnit.Framework
open StringMetric

let private testPreconditions fn =
    fn null null ==> (None, "null arguments")
    fn "" "" ==> (None, "empty strings")
    fn "abc" "xy" ==> (None, "strings different lengths")

[<Test>]
let ``preconditions``() =
    testPreconditions Hamming.distance
    testPreconditions Hamming.metric

[<Test>]
let ``distanсe``() =
    Hamming.distance "0000000" "0101010" ==> (Some 3, "3 different characters")
    Hamming.distance "0000000" "1111111" ==> (Some 7, "all 7 characters are different")
    Hamming.distance "0000000" "0000000" ==> (Some 0, "same strings")

[<Test>]
let ``metric``() =
    Hamming.metric "0000000" "0000000" ==> (Some 1.0, "same strings")
    Hamming.metric "0000000" "1111111" ==> (Some 0.0, "strings completly different")
    Hamming.metric "0101010" "0000000" ==> (Some (4.0 / 7.0), "4 characters are equal")

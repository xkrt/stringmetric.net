module StringMetric.Tests.HammingTests

open NUnit.Framework
open StringMetric

[<Test>]
let ``preconditions``() =
    Hamming.distance null null ==> (None, "null arguments")
    Hamming.distance "" "" ==> (None, "empty strings")
    Hamming.distance "abc" "xy" ==> (None, "strings different lengths")        

[<Test>]
let ``distanсe``() =
    Hamming.distance "0000000" "0101010" ==> (Some 3, "3 different characters")
    Hamming.distance "0000000" "1111111" ==> (Some 7, "all 7 characters are different")
    Hamming.distance "0000000" "0000000" ==> (Some 0, "same strings")

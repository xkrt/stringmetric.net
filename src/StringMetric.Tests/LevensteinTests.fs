module StringMetric.Tests.LevensteinTests

open NUnit.Framework
open StringMetric

[<Test>]
let ``preconditions``() =
    Levenstein.distance null null ==> (None, "null not allowed")
    Levenstein.distance "" "" ==> (None, "empty strings not allowed")

[<Test>]
let ``distance``() =
    Levenstein.distance "hello"
                        "hello" ==> (Some 0, "equal strings")
    Levenstein.distance "abc"
                        "xyz" ==> (Some 3, "completly different strings")
    Levenstein.distance "Kitten"
                        "Sitten" ==> (Some 1, "one replacement")
    Levenstein.distance "sittin"
                        "SittinG" ==> (Some 2, "one replacement + one delete/insert")

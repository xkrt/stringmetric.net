module StringMetric.Tests.Hamming

open NUnit.Framework
open StringMetric

let (==>) actual expected =
    match actual = expected with
    | true -> ()
    | false -> failwithf "\nactual: %A\nexpected: %A" actual expected


[<Test>]
let ``preconditions``() =
   Ham


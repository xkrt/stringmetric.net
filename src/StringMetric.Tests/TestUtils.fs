[<AutoOpen>]
module StringMetric.Tests.TestUtils

let (==>) actual (expected, description) =
    match actual = expected with
    | true -> ()
    | false -> failwithf "\nactual: %A\nexpected: %A\ntest description:%s" actual expected description

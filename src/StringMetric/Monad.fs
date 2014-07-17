[<AutoOpen>]
module internal StringMetric.Monad

let inline (<!>) o f = Option.map f o

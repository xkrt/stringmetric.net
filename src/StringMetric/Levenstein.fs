module StringMetric.Levenstein

open System

// Wagner–Fischer algorithm

let distance (str1: string) (str2: string): int option =
    if String.IsNullOrEmpty str1 || String.IsNullOrEmpty str2
    then None
    else
        let inline min3 one two three =
            if one < two && one < three then one
            elif two < three then two
            else three

        let m = str1.Length
        let n = str2.Length
        let d = Array2D.create (m + 1) (n + 1) 0

        for i = 0 to m do d.[i, 0] <- i
        for j = 0 to n do d.[0, j] <- j

        for j = 1 to n do
            for i = 1 to m do
                if str1.[i-1] = str2.[j-1]
                then d.[i, j] <- d.[i-1, j-1]
                else
                    d.[i, j] <- min3 (d.[i-1, j  ] + 1) // deletion
                                     (d.[i  , j-1] + 1) // insertion
                                     (d.[i-1, j-1] + 1) // substitution
        Some d.[m,n]

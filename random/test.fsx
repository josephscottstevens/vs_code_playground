let x =
    [1, "bob"; 1, "steve"; 2, "jill";]
    |> List.groupBy fst
    |> List.map (fun (a, b) -> a, b)
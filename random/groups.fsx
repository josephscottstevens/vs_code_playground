let data = [1, "bob", "boberson"; 1, "steve", "steverson"; 2, "jill", "steverson";]

let x =
    data
    |> List.groupBy (fun (a, _, _) -> a)
    
let y = 
    data
    |> List.groupBy (fun (a, _, _) -> a)
    |> List.map (fun (a, b) -> b)
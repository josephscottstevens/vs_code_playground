let fizzBuzz t =
    match t with 
    | t when t % 15 = 0 -> "FizzBuzz"
    | t when t % 5 = 0  -> "Fizz"
    | t when t % 3 = 0  -> "Buzz"
    | _                 -> t.ToString()

[1..16]
|> List.map fizzBuzz
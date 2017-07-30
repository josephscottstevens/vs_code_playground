let getGridStr m n =
    let addTab x y = x + "\t" + y                            // Takes in two strings, add's a "\t" between them
    let addNewLine x y = x + "\n" + y                        // Takes in two strings, add's a "\n" between them
    let formatInnerString (x: string) =                      // Takes a string, makes a new string prepends the first character of the original string, 
        string (x.[0]) + "| " + x                            //  and a "| " to the original string

    let createInnerString x =                                // Creates a sequence from an integer, ie
        [x .. x .. n * x]                                    // Given 1, return: [1; 2; 3; 4; 5;] 
                                                             // Or Given 2, return [2; 4; 6; 8; 10;]
        |> List.map string                                   // Maps the above list of ints, to strings
        |> List.reduce addTab                                // reduces them together with a tab between each string

    let gridStrMain = 
        [1..m]                                               // Creates a list of ints from 1 to m
        |> List.map (createInnerString >> formatInnerString) // Maps the composition of make createInnerList and formatInnerList
        |> List.reduce addNewLine                            // Reduces them together with newlines between each string

    let header =                                             // Creates the header row for the output
        [1..n]                                               // Creates a list of ints from 1 to n
        |> Seq.map string                                    // Maps each Int to a string
        |> Seq.reduce addTab                                 // Reduces them together with a tab between each character

    "X  " + header + "\n\n" + gridStrMain

let get12X12GridStr() =
    printfn "%s" (getGridStr 12 12)    

let getManualGridString() =
    printfn "Please enter height of grid: "
    let mValue = System.Console.ReadLine() |> int
    printfn "Please enter width of grid: "
    let nValue = System.Console.ReadLine() |> int
    printfn "%s" (getGridStr mValue nValue)    

let getHelp() =
    printfn "Here is some help messages"
    printfn "They are very helpful"
    printfn "I am sure you can agree\n"

let unknownCommand() =
    printfn "Unknown command, please try entering a valid command"

let rec main() =
    printfn "Type 1 for a 12 x 12 grid"
    printfn "Type 2 for a custom grid"
    printfn "Type 3 for help"
    printfn "Type 4 to quit"
    let input = System.Console.ReadLine() |> string
    let result =
        match input with
        | "1" -> get12X12GridStr()
        | "2" -> getManualGridString()
        | "3" -> getHelp()
        | "4" -> System.Environment.Exit(0)
        | _ -> unknownCommand()
    (main():unit)
main()
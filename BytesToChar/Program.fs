[<EntryPoint>]
let main _ =
    let stdin = System.Console.OpenStandardInput()
    let stdout = System.Console.OpenStandardOutput()
    Common.parseNumeralStream stdin |> Common.printBytes stdout
    0



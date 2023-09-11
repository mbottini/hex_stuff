[<EntryPoint>]
let main _ =
    let stdin = System.Console.OpenStandardInput()
    Common.getBytes 4096 stdin |> 
    Seq.map string |>
    Seq.chunkBySize 20 |>
    Seq.map (fun arr -> System.String.Join (" ", arr)) |>
    Seq.iter (printf "%s\n")
    0
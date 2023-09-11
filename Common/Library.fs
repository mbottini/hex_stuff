module Common

let rec repeatedly f = seq {
    yield f ();
    yield! repeatedly f
}

let getBytes (chunkSize: int) (stream: System.IO.Stream) =
    let arr = Array.create chunkSize 0uy
    let reader = new System.IO.BinaryReader(stream)
    let rec helper () = 
        let bytesRead = reader.Read(arr, 0, chunkSize)
        if bytesRead = 0 
            then Seq.empty 
            else seq {yield! Seq.take bytesRead arr; yield! helper ()}
    helper ()

let parseNumeralStream (s: System.IO.Stream) =
    let reader = new System.IO.StreamReader(s)
    repeatedly reader.ReadLine |> 
    Seq.takeWhile (fun x -> x <> null) |>
    Seq.collect (fun s -> s.Split(" ")) |>
    Seq.map byte


let printBytes (s: System.IO.Stream) (bs: seq<byte>) =
    let writer = new System.IO.BinaryWriter(s)
    Seq.chunkBySize 4096 bs |>
    Seq.iter writer.Write
open System.IO

type Customer = {
	CustomerId : string
	Email : string
	IsEligible : string
	IsRegistered : string
	DateRegistered : string
	Discount : string
}

type FileReader = string -> Result<string seq,exn>

let readFile : FileReader =
	fun path ->
    	try
        	seq { use reader = new StreamReader(File.OpenRead(path))
              	while not reader.EndOfStream do
                  	yield reader.ReadLine() }
        	|> Ok
    	with
    	| ex -> Error ex

let parseLine (line:string) : Customer option =
	match line.Split('|') with
	| [| customerId; email; eligible; registered; dateRegistered; discount |] ->
    	Some {
        	CustomerId = customerId
        	Email = email
        	IsEligible = eligible
        	IsRegistered = registered
        	DateRegistered = dateRegistered
        	Discount = discount
    	}
	| _ -> None

let parse (data:string seq) =
	data
	|> Seq.skip 1
	|> Seq.map parseLine
	|> Seq.choose id

let output data =
	data
	|> Seq.iter (fun x -> printfn "%A" x)

let import (fileReader:FileReader) path =
	match path |> fileReader with
	| Ok data -> data |> parse |> output
	| Error ex -> printfn "Error: %A" ex.Message

[<EntryPoint>]
let main argv =
	import readFile @"customers.csv"
	0


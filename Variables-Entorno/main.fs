open System
open System.Text.RegularExpressions

/// Load .env file
let loadDotEnv() =
  let envFile = ".env"
  if IO.File.Exists(envFile)
  then
	IO.File.ReadAllLines(envFile)
	|> Array.iter (fun line ->
  	// Remove comments
  	let line' = Regex.Replace(line, "#.*", "")

  	// Split into <key>=<value>
  	let parts = line'.Split([|'='|]) |> Array.map (fun x -> x.Trim())
  	if Array.length parts = 2
  	then
    	let (key, value) = (parts.[0], parts.[1])

    	// Only add key if not already there
    	if String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(key))
    	then Environment.SetEnvironmentVariable(key, value)
    	else ()
  	else ())

loadDotEnv()

printfn "foo: %A" (Environment.GetEnvironmentVariable("FOO"))
printfn "bar: %A" (Environment.GetEnvironmentVariable("BAR"))


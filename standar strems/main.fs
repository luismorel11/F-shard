open System

[<EntryPoint>]

let main() =
   Console.Write("What's your name? ")
   let name = Console.ReadLine()
   Console.Write("Hello, {0}\n", name)
   Console.WriteLine(System.String.Format("Big Greetings from {0} and {1}", "TutorialsPoint", "Absoulte Classes"))
   Console.WriteLine(System.String.Format("|{0:yyyy-MMM-dd}|", System.DateTime.Now))
main()





//estandar error.
let main argv =
	printfn ("Hello World from F#!")
	eprintf "Write five = %d" (3+2)

	0 // return an integer exit code

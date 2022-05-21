open System.Net;

[<EntryPoint>]
let main argv = 
    let wc = new WebClient()
    wc.DownloadFile("https://www.redeszone.net/app/uploads-redeszone.net/2018/11/lugares-esconde-malware.jpg?x=480&y=375&quality=40", @"bg.png")
    0




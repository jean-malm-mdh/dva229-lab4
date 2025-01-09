namespace Lab3
open TermGui
open EventHandling
module Program = 
    let runProgram () = 
        // Creates the components. Returns the components and the observable events
        let components, ActionMessageProducers = TermGui.makeBtns BtnGridStartX BtnGridStartY
        
        // Merge all observables to one stream
        let observables = 
            List.map (fun (e, a) -> Observable.map e a) ActionMessageProducers
            |> (List.reduce Observable.merge)
        
        // Creates the window
        let myWindow = TermGui.makeApp components

        // Starts the application and the reactive loop
        Async.StartImmediate(loop myWindow observables []); TermGui.runApp myWindow

    [<EntryPoint>]
    let main argv =
        runProgram () |> ignore    
        0 // return an integer exit code
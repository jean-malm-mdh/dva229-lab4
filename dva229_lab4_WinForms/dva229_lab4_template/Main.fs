// Project $safeprojectname$
// Created by Björn Dagerman 2015/05 (dagerman@kth.se)
// Fixed typo (changed FSharp -> FSharpx), Björn L 2017-02-27
// Changed the types from events from ints to UserAction. Jean M 2021-01-20
// Main
namespace Lab4
open FSharpx.Control.Observable // Fsharpx
open EventHandling
module Main =

    // We provide you a simple type alias for the program state, to start with
    // TODO: Update the type for the state, based on your implementation
    type State = int list        

    // This main function loops using async and Async.Await. See lecture F13 for alternatives.
    // The loop implements a basic view-input-update behaviour.
    let rec loop observable (state : State) = async{
        
        // At the start we do the computations that we can do with the inputs we have, just as in a regular application
        // In this case, we simply update the view (we print the state)
        printfn "%A" state
    
        // Next, since we don't have all inputs (yet) we need to wait for them to become available (Async.Await)
        // let! (bang) enables execution to continue on other computations and threads.
        let! somethingObservable = Async.AwaitObservable(observable) 

        // Now that we have recieved a new input we can perform the rest of our computations
        // Here we do the conversion from the GuiInterface type to the one we want for the program's logic.
        // Please note that using integers here is just done as an example. 
        // TODO: Replace integers with some more informative type. We leave the design up to you!
        match somethingObservable with
            | UserAction.Zero     -> return! loop observable (0::state)
            | UserAction.One     -> return! loop observable (1::state)
            | UserAction.Two     -> return! loop observable (2::state)
            | UserAction.Three     -> return! loop observable (3::state)
            | _     -> failwith "Not implemented yet!"
        // The last thing we do is a recursive call to ourselves, thus looping
    }

   let StartProgram () =
        let form, subscribableEventActionPairs = Gui.createCalculatorGUI "Lab4 Calculator"
        let observables = 
            (List.map (fun e, a -> Observable.map a e) subscribableEventActionPairs)
            |> Observable.merge
            |> List.reduce 
        // Starts the main loop and opens the Gui 
        Async.StartImmediate(loop observables []); System.Windows.Forms.Application.Run(form)



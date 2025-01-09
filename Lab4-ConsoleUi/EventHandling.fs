namespace Lab3
    module EventHandling = 
        open FSharpx.Control.Observable

        // We provide you a very simple model for user actions to start with.
        // TODO: Update and refactor the model as needed by your application
        type UserAction = 
        | Zero
        | One
        | Two 
        | Three

        // We provide you a simple type alias for the program state, to start with
        // TODO: Update and refactor the state as needed by your application
        type State = int list        

        // Defines an interface for state renderers
        type IRenderable =
            abstract member renderState : State -> unit

        // This main function loops using async and Async.Await. See lecture F13 for alternatives.
        // The loop implements a basic view-input-update behaviour.
        let rec loop (myView : IRenderable) observable (state : State) = async{
            
            // We first update the view
            myView.renderState state

            // Next, since we don't have all inputs (yet) we need to wait for them to become available (Async.Await)
            // let! (bang) enables execution to continue on other computations and threads.
            let! somethingObservable = Async.AwaitObservable(observable) 

            // Now that we have recieved a new input we can perform the rest of our computations
            // TODO: This is where you should add your logic to update the state
            match somethingObservable with
                | Zero     -> return! loop myView observable (0::state) 
                | One     -> return! loop myView observable (1::state) 
                | Two     -> return! loop myView observable (2::state) 
                | Three     -> return! loop myView observable (3::state) 
            
            // The last thing we do is a recursive call to ourselves, thus looping
        }
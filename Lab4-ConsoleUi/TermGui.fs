//Project $safeprojectname$
//Created by Björn Dagerman 2015/05 (dagerman@kth.se)
// 2023-01-03: Added a few more buttons (jean.malm#mdu.se)
// 2025-01-09: Rewrote skeleton code to use Terminal.Gui as WinForms support is decreasing. (jean.malm#mdu.se)
//Gui: Creates a simple Terminal GUI with four buttons
namespace Lab3
module TermGui = 
    open EventHandling
    open Terminal.Gui
    open FSharpx.Control.Observable // Fsharpx
    
    /// Some GUI constants related to positioning
    let BtnGridStartX = 5
    let BtnGridStartY = 5
    let viewLabelPos = (0,1)

    /// Helper function to print a string at a given cursor position 
    /// and then move the cursor back
    let printAtNewPositionThenReset (x, y) s = 
        let struct (currPosX, currPosY) = System.Console.GetCursorPosition()
        System.Console.SetCursorPosition(x, y)
        printfn "%A" s
        System.Console.SetCursorPosition(currPosX, currPosY)
    
    type ExampleWindow (buttons : Button list) as this =
        inherit Window()

        // F# constructor
        do
            this.Title <- sprintf "Calculator App (%O to quit)" Application.QuitKey
            let valueLabel = new Label(Text = "<0>")
            this.Add(valueLabel) |> ignore
            for b in buttons do 
                this.Add(b) |> ignore
            
        // Implementation of the interface
        interface IRenderable with
            member this.renderState (state : State) = 
                //TODO: This you may need to update to render state in different ways
                printAtNewPositionThenReset viewLabelPos (sprintf "%A" state)
        end


    let makeBtns startX startY =
        // Makes one horizontal row of buttons, given the starting position of the leftmost one
        // TODO: you should complete the creation of the components here        
        
        /// Note: This is a good place to practice your refactoring skills. 
        /// You should for instance consider creating suitable helper functions
        /// Also, the solution is needlessly hardcoded. Parametrise!
        let btn1 = new Button(Text = "1", Y = Pos.op_Implicit(startY), X = Pos.op_Implicit(startX))
        let btn2 = new Button(Text = "2", Y = Pos.op_Implicit(startY), X = Pos.Right(btn1) + Pos.op_Implicit(1))
        let btn3 = new Button(Text = "3", Y = Pos.op_Implicit(startY), X = Pos.Right(btn2) + Pos.op_Implicit(1))
        let btn0 = new Button(Text = "0", Y = Pos.Bottom(btn3) + Pos.op_Implicit(1), X = Pos.X(btn2))
        
        // Gathers all created components in a list, then combines them with the relevant UserAction producers 
        let components = 
            [
                btn1
                btn2
                btn3
                btn0
            ]
        let actionProducers = [
            (fun _ -> One)
            (fun _ -> Two)
            (fun _ -> Three)
            (fun _ -> Zero)
        ]

        // Button.Accept is the click event for Terminal.Gui.Button
        let InteractionEvents = List.map (fun (btn : Button) -> btn.Accept) components
        
        // Finally, we return the list of components and data required to build observable streams.
        components, List.zip actionProducers InteractionEvents

    
    // Initialises and runs the application
    let makeApp components =
        new ExampleWindow(components)

    let runApp (view : ExampleWindow) =
        Application.Init()
        Application.Run(view)    
        // Before the application exits, reset Terminal.Gui for clean shutdown
        Application.Shutdown()
            
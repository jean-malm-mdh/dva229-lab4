//Project $safeprojectname$
//Created by Björn Dagerman 2015/05 (dagerman@kth.se)
// 2023-01-03: Added a few more buttons (jean.malm#mdu.se)
//Gui: Creates a simple form with four buttons
namespace Lab4
module Gui = 
    open System.Windows.Forms
    open EventHandling

    let createCalculatorGUI heading =
        let form = new Form(Text=heading, TopMost=true)
        let btnAdd0 = new Button(Text="Add 0")
        let btnAdd1 = new Button(Text="Add 1", Top=20)
        let btnAdd2 = new Button(Text="Add 2", Top=40)
        let btnAdd3 = new Button(Text="Add 3", Top=60)
        // TODO: Extend with additional GUI components.

        form.Controls.AddRange [| btnAdd0 ; btnAdd1; btnAdd2; btnAdd3 |]
        
        let SubscribableHandlers = [btnAdd0.Click; btnAdd1.Click; btnAdd2.Click; btnAdd3.Click]
        let ActionGenerators = [for e in [Zero; One; Two; Three] do yield (fun _ -> e)]

        let subscribableEventActionPairs = List.zip SubscribableHandlers ActionGenerators

        (form, subscribableEventActionPairs)
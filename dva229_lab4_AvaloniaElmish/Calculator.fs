
namespace DVA229_Lab4_AvaloniaElmish

module Calculator =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout    

    type UserAction = Zero | One | Two | Three
    type State = int list

    let init : State = []

    let update (msg : UserAction) (state : State) =
        match msg with
        | Zero -> 0::state
        | One -> 1::state
        | Two -> 2::state
        | Three -> 3::state
        | _ -> failwith "TODO: Not implemented yet"
    
    let view (state : State) (dispatch) =
        printfn "%A" state
        let btnWidth = 70.0
        let buttonsInColumn = 3.0
        DockPanel.create [
            DockPanel.children [
                TextBlock.create [
                    TextBlock.dock Dock.Top
                    TextBlock.fontSize 42.0
                    TextBlock.verticalAlignment VerticalAlignment.Center
                    TextBlock.horizontalAlignment HorizontalAlignment.Center
                    TextBlock.text (sprintf "%A" state)
                ]
                WrapPanel.create [
                    WrapPanel.dock Dock.Bottom
                    WrapPanel.itemWidth btnWidth
                    WrapPanel.maxWidth (btnWidth * buttonsInColumn)
                    WrapPanel.children [
                        Button.create [
                            Button.onClick (fun _ -> dispatch One)
                            Button.content "Add 1"
                        ]
                        Button.create [
                            Button.onClick (fun _ -> dispatch Two)
                            Button.content "Add 2"
                        ]
                        Button.create [
                            Button.onClick (fun _ -> dispatch Three)
                            Button.content "Add 3"
                        ]
                        Button.create [
                            Button.width (btnWidth * buttonsInColumn)
                            Button.onClick (fun _ -> dispatch Zero)
                            Button.content "Add 0"
                            Button.horizontalContentAlignment HorizontalAlignment.Center
                            Button.verticalAlignment VerticalAlignment.Center
                        ]                
                    ]
                ]
            ]
        ]

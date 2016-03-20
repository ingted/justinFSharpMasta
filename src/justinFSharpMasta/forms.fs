module forms

open Suave.Model.Binding
open Suave.Form
open Suave.ServerErrors
open Microsoft.FSharp.Reflection

let fromString<'a> s =
  match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    | [|case|] -> FSharpValue.MakeUnion(case,[||]) :?> 'a
    | _ -> failwith <| sprintf "Can't convert %s to DU" s

let logAndShow500 error =
  printfn "%A" error
  INTERNAL_ERROR "ERROR"

let bindToForm form handler =
  bindReq (bindForm form) handler logAndShow500


type Visibility =
  | Public
  | Private

type StuffForm =
  {
    Visiblity : string
    Count : decimal
  }

type Stuff =
  {
    Visibility : Visibility
    Count : int
  }

let defaultStuff = { Count = 1; Visibility = Private }

let convertStuff (stuffForm : StuffForm) =
  {
    Visibility = fromString<Visibility> stuffForm.Visiblity
    Count = int stuffForm.Count
  }

let stuffForm : Form<StuffForm> = Form ([],[])

module Main

open Suave
open Suave.Web
open Suave.Filters
open Suave.Operators
open Suave.Successful
open forms

let hello =
  //a warbler will make it re-rerun the function on every page load, so that it is not static
  warbler (fun _ ->
    let now = System.DateTime.Now
    OK <| pages.hello now)

let form =
  choose [
    GET >=> warbler (fun _ -> OK "A Form")
    POST >=> bindToForm stuffForm (fun stuffForm ->
      let form = forms.convertStuff stuffForm
      OK "A Form")
  ]

let grid =
  warbler (fun _ ->
    let cars = database.getCars()
    OK <| pages.grid cars)

let routes =
  choose
    [
      GET >=> choose [
        path paths.root >=> OK pages.root
        path paths.hello >=> hello
        path paths.grid >=> grid
      ]

      path paths.form >=> warbler (fun _ -> OK pages.form)

      pathRegex "(.*)\.(css|png|gif|js|ico|woff|tff)" >=> Files.browseHome
    ]

startWebServer defaultConfig routes

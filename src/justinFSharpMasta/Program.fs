module Main

open Suave
open Suave.Web
open Suave.Filters
open Suave.Operators
open Suave.Successful
open forms

let form =
  choose [
    GET >=> warbler (fun _ -> OK "A Form")
    POST >=> bindToForm stuffForm (fun stuffForm ->
      let form = forms.convertStuff stuffForm
      OK "A Form")
  ]

let routes =
  choose
    [
      GET >=> choose [
        path paths.root >=> OK pages.root
        path paths.hello >=> warbler (fun _ -> OK pages.hello)
      ]

      path paths.form >=> warbler (fun _ -> OK pages.form)
      path paths.grid >=> warbler (fun _ -> OK pages.grid)

      pathRegex "(.*)\.(css|png|gif|js|ico|woff|tff)" >=> Files.browseHome
    ]

startWebServer defaultConfig routes

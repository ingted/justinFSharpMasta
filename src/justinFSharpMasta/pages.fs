module pages

open Suave.Html
open htmlHelpers
open bootstrapHelpers
open forms

//A simples static page
let root =
  base_html
    "Home"
    [
      base_header
      container [
        row [ h3 "this is your home" ]
      ]
    ]
    scripts.common

let hello time =
  base_html
    "Hello"
    [
      base_header
      container [
        row [
          h3 (sprintf "Hello at %A" time)
          h6 "refresh to see a new time"
        ]
      ]
    ]
    scripts.common

let form =
  base_html
    "Form"
    [
      base_header
      container [
        row [ h3 "a form" ]
      ]
    ]
    scripts.common

let carsTable cars =
  let toTd car =
    [
      td [ text car.Make ]
      td [ text car.Model ]
      td [ text (string car.Year) ]
      td [ text (sprintf "$%i" car.Price) ]
    ]
  block_flat [
    content [
      table_bordered
        [
          "Make"
          "Model"
          "Year"
          "Price"
        ]
        cars toTd
    ]
  ]

let grid cars =
  base_html
    "Grid"
    [
      base_header
      container [
        row [ carsTable cars ]
      ]
    ]
    scripts.common

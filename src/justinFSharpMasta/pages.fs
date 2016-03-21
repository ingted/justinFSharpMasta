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

let private common_table decription formElements =
  container [
    row [
      block_flat [
        header [ h3 decription ]
        div [
          form_horizontal [
            content (formElements @ [form_group [ sm12 [ pull_right [ button_submit ] ] ] ])
          ]
        ]
      ]
    ]
  ]

let visibilityOptions = ["Public","Public"; "Private","Private"]

let form =
  base_html
    "Form"
    [
      base_header
      common_table
        "Register"
        [
          label_text "First Name" ""
          label_text "Last Name" ""
          label_text "Email" ""
          label_text "Password" ""
          label_text "Repeat Password" ""
          label_text "Age" ""
          label_select_selected "Visibility" visibilityOptions ""
        ]
    ]
    scripts.common

let private carsTable cars =
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

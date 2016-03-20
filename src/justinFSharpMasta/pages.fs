module pages

open Suave.Html
open htmlHelpers
open bootstrapHelpers
open forms

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

let hello =
  base_html
    "Hello"
    [
      base_header
      container [
        row [ h3 "this is hello" ]
      ]
    ]
    scripts.common

let form =
  base_html
    "Form"
    [
      base_header
      container [
        row [ h3 "this is a form" ]
      ]
    ]
    scripts.common

let grid =
  base_html
    "Grid"
    [
      base_header
      container [
        row [ h3 "this is a grid" ]
      ]
    ]
    scripts.common

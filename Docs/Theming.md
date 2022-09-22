# Theming

**Goal:** Be able to change any control's properties dynamically without having to write specialized controls or specialized theming code.

**Design/Structure:** I use YAML files for styles that are inspired by CSS, e.g.

CSS:
```css
/* Comment */
div#page-tweaks > input[type=button].btn-small:hover {
    background-color: "#555";
}
```

YAML theme file:
```yaml
# Comment
UserControlTweaks > Button.SmallButton:
    MouseOverBackColor: "#555"
```

It certainly isn't as powerful and versatile as CSS, but it's enough for my purposes.

## Structure

The structure is as follows:

```
[ParentType{.ParentName or .ParentTag} >] ControlType[.ControlName or .ControlTag], selector2, selector3, ...:
    Property: Value
    and more rules...
```

You can have multiple selectors delimited with commas, specify a parent, and select controls using their type (class name), name, or tag.

Rules are declared by a key/value pair. You can change the value of any property of the selected control(s).

## Values

You can use the following values to assign them to properies:

| String value                             | Converted to type                          |
| ---------------------------------------- | ------------------------------------------ |
| `rgb(255, 255, 255)`                     | System.Drawing.Color                       |
| `#ffffff`                                | System.Drawing.Color                       |
| `RoyalBlue`                              | System.Drawing.Color                       |
| `github_16`                              | (from Resources) System.Drawing.Image      |
| ~~`github-16.png`~~                      | ~~(from disk) System.Drawing.Image~~ (tbd) |
| `42`                                     | System.Int32                               |
| any                                      | System.String                              |
| `Standard` / `Flat` / `Popup` / `System` | System.Windows.Forms.FlatStyle             |

The conversion depends on the property's type.

## Features

### Wildcards

There are two wildcards that can be used in selectors:
- `?` - any character (one and only one)
- `*` - any characters (zero or more)

```yaml
UserControl*:
    ForeColor: "black"

PictureBox.*Spacer?:
    BackColor: "#555"
```

### Variables

Variables work in a similar way to CSS:

CSS:
```css
:root {
    --my-var: "#222";
}

button {
    color: var(--my-var);
}
```

YAML theme file:
```yaml
VARS:
    MyVar: "#222"

Button:
    ForeColor: "var(MyVar)"
```

### Parent

You can select controls by specifying a parent. It doesn't have to be a direct parent, just a control "higher-up" in the hierachy:

```yaml
UserControlTweaks > Panel:
    BackColor: "#555"
```
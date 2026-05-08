# Weekly Mini Project 1 - Product List

A C# console application for managing a list of products with a structured format, built as a learning exercise covering CRUD operations, validation, LINQ, and file handling.

---

## Format

Products follow a strict format:

```
LETTERS-NUMBER
```

- **Left side** — letters only (A–Z)
- **Right side** — number between 200 and 500
- **Exactly one dash**

**Valid:** `AB-300`, `CE-400`, `XYZ-250`  
**Invalid:** `123-300`, `AB-999`, `A-200-300`, `AB300`

---

## Features

- **Add Product** — validates format and prevents duplicates
- **View Products** — displays all products sorted alphabetically
- **Search Products** — search by name or number
- **Delete Product** — shows a product list, delete by writing name of product
- **Statistics** — total, highest, lowest, and average product number
- **Save to File** — saves the current list to `products.txt`

---

## Validation Errors

| Input | Error |
|---|---|
| *(empty)* | Input cannot be empty |
| `AB300` | Product must contain a dash (-) |
| `A-200-300` | Product must have exactly one dash (-) |
| `123-300` | The left side must contain letters only |
| `AB-abc` | The right side must contain numbers only |
| `AB-100` | The numeric part must be between 200 and 500 |
| `AB-300` *(exists)* | WARNING: Product already exists |

---

## Concepts Practiced

- Classes & static methods
- LINQ (`Where`, `Max`, `Min`, `Average`)
- Input validation without Regex
- CRUD operations
- File handling (`File.WriteAllLines`)
- Menu-driven console UI

---

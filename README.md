# DeepEqual Library

## Overview

The `DeepEqual` library in C# allows deep comparison of objects by checking each property and field recursively. Unlike the standard equality checks, which often compare object references or perform shallow comparisons, `DeepEqual` inspects the values of nested objects, collections, dictionaries, and other complex data types, ensuring that objects are deeply equal.

## Features

- **Deep comparison** of objects, including nested objects, collections, and dictionaries.
- **Ignore specific properties or fields** in comparisons.
- **Custom rules** for comparison, allowing more flexibility when needed.
- **Handles circular references** safely without causing stack overflow errors.

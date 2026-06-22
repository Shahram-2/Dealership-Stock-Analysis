# Example Program Outputs and Function Visualisations

## Example 1: Function with Local Maximum and Minimum

Function:

```text
f(x) = x³ - 6x² + 9x + 2
```

**Program Output**

```text
--- Cubic Function Local Min/Max Finder ---
Function form: f(x) = ax³ + bx² + cx + d

Enter coefficient a (must not be 0): 1
Enter coefficient b: -6
Enter coefficient c: 9
Enter coefficient d: 2

Critical point 1 → Local Minimum: x = 3.00, f(x) = 2.00
Critical point 2 → Local Maximum: x = 1.00, f(x) = 6.00
```

<img width="366" height="224" alt="Local Maximum and Minimum Graph" src="https://github.com/user-attachments/assets/0d6389a8-b125-4276-833a-a680f6485ed8" />

---

## Example 2: Function with No Local Minimum or Maximum

Function:

```text
f(x) = x³ + x
```

**Program Output**

```text
--- Cubic Function Local Min/Max Finder ---
Function form: f(x) = ax³ + bx² + cx + d

Enter coefficient a (must not be 0): 1
Enter coefficient b: 0
Enter coefficient c: 1
Enter coefficient d: 0

No real critical points found – the function has no local minimum or maximum.
```

<img width="367" height="218" alt="No Local Min Max Graph" src="https://github.com/user-attachments/assets/d7f5ad35-549e-4109-b625-461f8389ac1f" />

---

## Example 3: Function with an Inflection Point Only

Function:

```text
f(x) = x³ + 5
```

**Program Output**

```text
--- Cubic Function Local Min/Max Finder ---
Function form: f(x) = ax³ + bx² + cx + d

Enter coefficient a (must not be 0): 1
Enter coefficient b: 0
Enter coefficient c: 0
Enter coefficient d: 5

Only one critical point exists at x = 0.00, f(x) = 5.00.
This is an inflection point – no local minimum or maximum.
```

<img width="368" height="220" alt="Inflection Point Graph" src="https://github.com/user-attachments/assets/b6c0b02c-ede5-47ef-99ac-098e5936dbff" />

---

## Example 4: Stock Analysis

```text
--- Stock Analysis ---

========== OVERALL STATISTICS ==========
Opening price (first trading day 02/01/2024): 105.50
Closing price (last trading day 31/12/2024): 159.60
Total trading days  : 252
Lowest trading price: 96.80
Highest trading price: 164.50
Highest volume day   : 17/06/2024 (Volume: 4,920,000)
Closing price that day: 149.30 | Change vs prev day: +3.75%
```

### Monthly Statistics Example

```text
Enter a month for detailed stats (MM/YYYY, e.g. 06/2022): 06/2024

========== June 2024 STATISTICS ==========
Opening price (first day 03/06/2024): 142.60
Closing price (last day 28/06/2024): 151.20
Total trading volume : 58,420,000
Highest trading price: 154.70
Lowest trading price : 140.10
```

### Invalid Month Example

```text
Enter a month for detailed stats (MM/YYYY, e.g. 06/2022): June

Invalid month format. Please use MM/YYYY.
```

### Exit Example

```text
========== MAIN MENU ==========
1. Find Local Min/Max of a Cubic Function
2. Stock Analysis
3. Exit
================================
Enter your choice (1-3): 3

Exiting the program. Goodbye!
```

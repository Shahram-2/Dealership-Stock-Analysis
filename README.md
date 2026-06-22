# Car Dealership Stock Prediction and Analysis System

## Project Overview

This project is a **C# Console Application** designed to analyse stock trading data from a car dealership using information stored in a **CSV file**. The application provides a menu-driven interface that allows users to access different features of the program, including mathematical analysis of cubic functions and stock data analysis.

The program demonstrates the use of:

* File handling and CSV processing
* Object-oriented programming principles
* Mathematical computations
* Input validation and error handling
* Data analysis and statistical calculations
* Menu-driven user interfaces

---

# Project Objectives

The system aims to:

1. Read stock trading data from a CSV file.
2. Analyse trading information and display useful statistics.
3. Predict and analyse trends based on historical stock data.
4. Provide mathematical tools for finding local minimum and maximum points of cubic functions.
5. Demonstrate robust input validation and user interaction through a console menu system.

---

# Features

## Main Menu System

The application presents a menu with the following options:

1. Find Local Minimum and Maximum of a Cubic Function
2. Stock Analysis
3. Exit Program

The menu:

* Continuously redisplays after each operation.
* Validates user input.
* Displays error messages for invalid selections.
* Allows users to exit safely.

If a feature has not been implemented, the program should display:

```text
Feature not implemented.
```

---

# Feature 1: Cubic Function Analysis

## Description

This module finds the **local minimum** and **local maximum** of a cubic function in the form:

```text
f(x) = ax³ + bx² + cx + d
```

The program:

1. Prompts the user to enter coefficients:

   * a
   * b
   * c
   * d

2. Calculates the derivative:

```text
f'(x) = 3ax² + 2bx + c
```

3. Uses the quadratic formula to find critical points.

4. Uses the second derivative:

```text
f''(x) = 6ax + 2b
```

to determine whether each critical point is:

* Local Maximum
* Local Minimum

5. Displays results to **2 decimal places**.

6. Displays appropriate messages when:

* No real critical points exist.
* Only an inflection point exists.
* No local minimum or maximum can be found.

---

# Feature 2: Stock Analysis

## Description

This module reads stock trading data from a **CSV file** and performs statistical analysis.

## Expected CSV Format

```csv
Date,Open,High,Low,Close,Adj Close,Volume
2024-01-02,100.50,105.20,99.80,104.50,104.50,2500000
```

## Data Fields

| Column    | Description            |
| --------- | ---------------------- |
| Date      | Trading date           |
| Open      | Opening price          |
| High      | Highest trading price  |
| Low       | Lowest trading price   |
| Close     | Closing price          |
| Adj Close | Adjusted closing price |
| Volume    | Trading volume         |

---

## Overall Statistics Displayed

The program displays:

* Opening price of the first trading day
* Closing price of the last trading day
* Total number of trading days
* Lowest trading price
* Highest trading price
* Date with the highest trading volume
* Closing price percentage change compared with the previous trading day

---

## Monthly Statistics

The user can specify a month using:

```text
MM/YYYY
```

Example:

```text
06/2024
```

The program displays:

* Opening price of the first trading day of the month
* Closing price of the last trading day of the month
* Total trading volume
* Highest trading price
* Lowest trading price

---

# Input Validation

The application performs validation for:

## Menu Selection

* Accepts only valid menu options.
* Displays an error message for invalid choices.

## Numeric Inputs

* Ensures coefficients are valid numbers.
* Ensures coefficient `a` is not zero.

## File Validation

* Verifies that the CSV file exists.
* Displays an error if the file cannot be found.

## Date Validation

* Ensures the month is entered in:

```text
MM/YYYY
```

format.

---

# Project Structure

```text
Project
│
├── Program.cs
├── stocks.csv
├── OUTPUTS.md
└── README.md
```

---

# Class Structure

## Program Class

Responsible for:

* Displaying the main menu
* Handling user interaction
* Performing cubic calculations
* Reading CSV files
* Calculating stock statistics
* Input validation

## StockRecord Class

Represents a single stock trading record.

### Properties

```csharp
DateTime Date
double Open
double High
double Low
double Close
long Volume
```

---

# Technologies Used

* C#
* .NET Console Application
* System.IO
* System.Linq
* System.Collections.Generic
* System.Globalization

---

# Example Program Flow

```text
========== MAIN MENU ==========
1. Find Local Min/Max of a Cubic Function
2. Stock Analysis
3. Exit
================================
Enter your choice:
```

After completing an operation, the menu is displayed again until the user selects:

```text
3. Exit
```

---

# Future Enhancements

Possible improvements include:

* Stock price prediction using machine learning
* Data visualisation and charts
* Multiple CSV file support
* Search and filtering options
* Exporting reports to CSV or PDF
* Advanced forecasting algorithms
* Database integration

---

# Conclusion

The Car Dealership Stock Prediction and Analysis System is a menu-driven C# application that demonstrates file processing, mathematical analysis, input validation, and stock market data analysis. The project provides a solid foundation for future enhancements such as predictive analytics and machine learning-based stock forecasting.
